using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// 转盘控制器
/// </summary>
public class CarouselController : MonoBehaviour
{
    /// <summary>
    /// 左右上下激活
    /// </summary>
    [Header("Inputs")] public KeyCode leftKey;

    public KeyCode rightKey;
    public KeyCode upKey;
    public KeyCode downKey;
    public KeyCode activateKey;

    /// <summary>
    /// 激活面板 (激活按钮)
    /// </summary>
    [Header("Logic")] public ActivatePanelUI activatePanelUI;
    
    /// <summary>
    /// 档案面板 UI (技能介绍)
    /// </summary>
    public ProfilePanelUI profilePanelUI;

    /// <summary>
    /// 卡片
    /// </summary>
    public CardBehaviour[] carouselCardBehaviours;
    
    /// <summary>
    /// 当前卡片
    /// </summary>
    private CardBehaviour _currentCard;
    
    /// <summary>
    /// 当前卡片 ID, 默认0
    /// </summary>
    private int _currentCardId = 0;
    
    /// <summary>
    /// 转盘是否在移动
    /// </summary>
    private bool _carouselIsMoving = false;
    
    /// <summary>
    /// 激活的卡片 ID
    /// </summary>
    private int _activatedCardId;

    /// <summary>
    /// 转盘根
    /// </summary>
    [Header("Carousel Movement Settings")] public Transform carouselRootTransform;
    
    /// <summary>
    /// 移动时间
    /// </summary>
    public float movementDuration;

    /// <summary>
    /// Init
    /// </summary>
    private void Start()
    {
        _currentCard = carouselCardBehaviours[_currentCardId];

        ActivateFirstCard();
        ShowCurrentCardTextInfo();
        SetNewCardProfilePanelUI();
    }

    private void Update()
    {
        if (!_carouselIsMoving)
        {
            if (Input.GetKeyDown(leftKey) || Input.GetKeyDown(upKey))
            {
                RotateCarousel(-1);
            }

            if (Input.GetKeyDown(rightKey) || Input.GetKeyDown(downKey))
            {
                RotateCarousel(1);
            }

            if (Input.GetKeyDown(activateKey))
            {
                if (_activatedCardId != _currentCardId)
                {
                    ActivateCurrentCard();
                }
            }
        }
    }

    /// <summary>
    /// 旋转转盘
    /// </summary>
    /// <param name="rotationDirection">距离</param>
    private void RotateCarousel(int rotationDirection)
    {
        _carouselIsMoving = true;

        HideCurrentCardTextInfo();
        
        CalculateActivatedPanelState();

        carouselRootTransform
            .DORotate(new Vector3(0, 90 * rotationDirection, 0), movementDuration, RotateMode.LocalAxisAdd)
            .SetRelative().OnComplete(() => CarouselMovementEnded(rotationDirection));
    }

    /// <summary>
    /// 转盘运动结束后
    /// </summary>
    /// <param name="newCurrentCardIntDifference">距离之前卡片的差值</param>
    private void CarouselMovementEnded(int newCurrentCardIntDifference)
    {
        _currentCardId -= newCurrentCardIntDifference;
        
        if (_currentCardId < 0)
        {
            _currentCardId = carouselCardBehaviours.Length - 1;
        }
        else if (_currentCardId > carouselCardBehaviours.Length - 1)
        {
            _currentCardId = 0;
        }

        _currentCard = carouselCardBehaviours[_currentCardId];

        SetNewCardProfilePanelUI();
        
        ShowCurrentCardTextInfo();

        _carouselIsMoving = false;

        CalculateActivatedPanelState();
    }

    /// <summary>
    /// 设置文档
    /// </summary>
    private void SetNewCardProfilePanelUI()
    {
        profilePanelUI.SetNewCardData(
            _currentCard.cardData.profileName,
            _currentCard.cardData.profileIcon,
            _currentCard.cardData.descriptionText,
            _currentCard.cardData.skills
        );
    }

    /// <summary>
    /// 显示当前卡片文字信息 <see cref="HideCurrentCardTextInfo"/>
    /// </summary>
    private void ShowCurrentCardTextInfo()
    {
        _currentCard.SetNewCardTextState(true);
    }

    /// <summary>
    /// 隐藏当前卡片文字信息 (未被激活, 卡片内的一些东西无需展示)
    /// </summary>
    private void HideCurrentCardTextInfo()
    {
        _currentCard.SetNewCardTextState(false);
    }

    /// <summary>
    /// 激活第一个卡片 (默认)
    /// </summary>
    private void ActivateFirstCard()
    {
        _activatedCardId = _currentCardId;
        carouselCardBehaviours[_activatedCardId].SetActivatedState(true);
        CalculateActivatedPanelState();
    }

    /// <summary>
    /// 激活当前卡片
    /// </summary>
    private void ActivateCurrentCard()
    {
        // 取消激活当前
        carouselCardBehaviours[_activatedCardId].SetActivatedState(false);
        
        // 更新 ID
        _activatedCardId = _currentCardId;
        
        // 激活当前
        carouselCardBehaviours[_activatedCardId].SetActivatedState(true);
        
        // 计算激活的面板状态
        CalculateActivatedPanelState();
    }

    /// <inheritdoc cref="ActivatePanelUI.SetNewVisuals"/>
    /// <summary>
    /// 计算激活的面板状态 (更新激活按钮) <see cref="ActivatePanelUI.SetNewVisuals"/>
    /// </summary>
    private void CalculateActivatedPanelState()
    {
        if (_carouselIsMoving)
        {
            activatePanelUI.SetNewVisuals(2);
            return;
        }

        if (_currentCardId == _activatedCardId)
        {
            activatePanelUI.SetNewVisuals(0);
            return;
        }

        if (_currentCardId != _activatedCardId)
        {
            activatePanelUI.SetNewVisuals(1);
            return;
        }
    }
}