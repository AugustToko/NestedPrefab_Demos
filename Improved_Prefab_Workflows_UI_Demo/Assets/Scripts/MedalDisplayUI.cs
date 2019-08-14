using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
public class MedalDisplayUI : MonoBehaviour
{
    /// <summary>
    /// 是否启用Alpha淡化
    /// </summary>
    [Header("Settings")] public bool enableAlphaFading = false;

    /// <summary>
    /// 淡化点变换
    /// </summary>
    private Transform _fadePointTransform;

    /// <summary>
    /// 距离渐近点
    /// </summary>
    private float _distanceFromFadePoint;

    /// <summary>
    /// 淡出距离乘数
    /// </summary>
    private float _fadeDistanceMultiplier;

    /// <summary>
    /// 需要进行 Alpha 动画的图片数组
    /// </summary>
    [Header("Visuals")] public Image[] medalImages;

    /// <summary>
    /// 动画管理器
    /// </summary>
    public Animator medalAnimator;

    /// <summary>
    /// 激活后的爆发粒子系统
    /// </summary>
    public ParticleSystem activateBurstParticleSystem;

    /// <summary>
    /// 激后的连续粒子系统
    /// </summary>
    public ParticleSystem activateContinuousParticleSystem;

    /// <summary>
    /// 初始化
    /// </summary>
    private void OnEnable()
    {
        _fadePointTransform = MedalGlobalFadeController.Instance.fadeReferenceTransform;
    }

    private void Update()
    {
        if (enableAlphaFading)
        {
            if (_fadePointTransform)
            {
                // 全局Alpha更改时更新
                if (_fadeDistanceMultiplier != MedalGlobalFadeController.Instance.fadeMultiplierValue)
                {
                    _fadeDistanceMultiplier = MedalGlobalFadeController.Instance.fadeMultiplierValue;
                    UpdateAllMedalImageAlphas();
                }


                // 更新位置更改
                float currentDistance = Vector3.Distance(_fadePointTransform.position, transform.position);

                if (currentDistance != _distanceFromFadePoint)
                {
                    _distanceFromFadePoint = currentDistance;
                    UpdateAllMedalImageAlphas();
                }
            }
        }
    }

    /// <summary>
    /// 更新所有奖牌图像Alpha
    /// </summary>
    private void UpdateAllMedalImageAlphas()
    {
        float newAlphaValue = _distanceFromFadePoint / _fadeDistanceMultiplier;

        for (int i = 0; i < medalImages.Length; i++)
        {
            var currentMedalImageColor = medalImages[i].color;
            currentMedalImageColor.a = 1 - newAlphaValue;
            medalImages[i].color = currentMedalImageColor;
        }
    }
    
    /// <summary>
    /// 设置视觉效果 (动画)
    /// </summary>
    /// <param name="newActivatedState"></param>
    public void UpdateActivatedVisuals(bool newActivatedState)
    {
        if (newActivatedState)
        {
            activateBurstParticleSystem.Play();
            activateContinuousParticleSystem.Play();
            medalAnimator.SetTrigger("Activating");
        }
        else
        {
            activateContinuousParticleSystem.Stop();
            medalAnimator.SetTrigger("Deactivating");
        }
    }
}