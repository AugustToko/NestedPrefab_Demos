using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// 档案面板
/// </summary>
public class ProfilePanelUI : MonoBehaviour
{
    /// <summary>
    /// 标题文本
    /// </summary>
    [Header("UI Displays")]
    public TextMeshProUGUI profileDisplayName;
    
    /// <summary>
    /// 图片, 图标
    /// </summary>
    public Image profileDisplayIcon;
    
    /// <summary>
    /// 描述文本
    /// </summary>
    public TextMeshProUGUI profileDescriptionText;
    
    /// <summary>
    /// 用于展示技能图标
    /// </summary>
    public SkillDisplayUI[] skillDisplays;

    /// <summary>
    /// 传递数据
    /// </summary>
    /// <param name="newProfileName">.</param>
    /// <param name="newProfileIcon">.</param>
    /// <param name="newDescriptionText">.</param>
    /// <param name="newSkillData">.</param>
    public void SetNewCardData(string newProfileName, Sprite newProfileIcon, string newDescriptionText, SkillData[] newSkillData)
    {
        profileDisplayName.text = newProfileName;
        profileDisplayIcon.sprite = newProfileIcon;
        profileDescriptionText.text = newDescriptionText;

        for(int i = 0; i < skillDisplays.Length; i++)
        {
            skillDisplays[i].SetNewSkillDisplayData(newSkillData[i]);
        }
    }



}
