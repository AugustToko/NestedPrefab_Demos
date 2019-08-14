using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 卡片行为
/// </summary>
public class CardBehaviour : MonoBehaviour
{
    
    [Header("Card Data")]
    public CardData cardData;
    
    //Logic
    /// <summary>
    /// 目前是重点
    /// </summary>
    private bool _isCurrentlyFocused = false;
    
    /// <summary>
    /// 是否当前已激活
    /// </summary>
    private bool _isCurrentlyActivated = false;

    /// <summary>
    /// 卡显示隐藏和显示
    /// </summary>
    [Header("Card Display")]
    public GameObject[] cardDisplaysToHideAndShow;
    
    /// <summary>
    /// 展示 UI
    /// </summary>
    public MedalDisplayUI medalDisplayUI;

    private void Awake()
    {
        // 循环设置当前激活项目
        for(int i = 0; i < cardDisplaysToHideAndShow.Length; i++)
        {
            cardDisplaysToHideAndShow[i].SetActive(_isCurrentlyFocused);
        }

    }

    /// <summary>
    /// 设置新卡片文字状态, 然后循环设置激活
    /// </summary>
    /// <param name="newState">状态</param>
    public void SetNewCardTextState(bool newState)
    {
        _isCurrentlyFocused = newState;

        for(int i = 0; i < cardDisplaysToHideAndShow.Length; i++)
        {
            cardDisplaysToHideAndShow[i].SetActive(_isCurrentlyFocused);
        }
    }

    /// <summary>
    /// 设置激活状态
    /// </summary>
    /// <param name="newState"></param>
    public void SetActivatedState(bool newState)
    {
        _isCurrentlyActivated = newState;
        medalDisplayUI.UpdateActivatedVisuals(_isCurrentlyActivated);
    }

}
