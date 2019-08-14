using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// 技能显示 UI
/// </summary>
public class SkillDisplayUI : MonoBehaviour
{

    /// <summary>
    /// 技能名称
    /// </summary>
    public TextMeshProUGUI skillDisplayName;
    
    /// <summary>
    /// 技能图标
    /// </summary>
    public Image skillDisplayIcon;

    public void SetNewSkillDisplayData(SkillData newSkillData)
    {
        skillDisplayName.text = newSkillData.skillName;
        skillDisplayIcon.sprite = newSkillData.skillIcon;
    }

}
