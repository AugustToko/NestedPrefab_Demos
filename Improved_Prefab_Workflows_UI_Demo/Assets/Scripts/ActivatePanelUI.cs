using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// 激活的面板
/// </summary>
public class ActivatePanelUI : MonoBehaviour
{
    /// <summary>
    /// 激活后的文本
    /// </summary>
    [Header("Settings")] public string activatedText = "Activated";

    /// <summary>
    /// 激活前文本
    /// </summary>
    public string activateText = "Activate";

    /// <summary>
    /// 普通文本颜色
    /// </summary>
    public Color normalTextColor;

    /// <summary>
    /// 过度文本颜色
    /// </summary>
    public Color transitionTextColor;

    /// <summary>
    /// 用于显示文本的组件
    /// </summary>
    [Header("Visuals")] public TextMeshProUGUI activateDisplayText;


    /// <summary>
    /// 0 - Activated
    /// 1 - Activate
    /// 2 - disabled (During Transition)
    /// </summary>
    public void SetNewVisuals(int newState)
    {
        switch (newState)
        {
            case 0:
                activateDisplayText.text = activatedText;
                activateDisplayText.color = normalTextColor;
                break;

            case 1:
                activateDisplayText.text = activateText;
                activateDisplayText.color = normalTextColor;
                break;

            case 2:
                activateDisplayText.color = transitionTextColor;
                break;
            default:
                Debug.Log("State not exists.");
                break;
        }
    }
}