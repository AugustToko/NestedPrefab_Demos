using UnityEngine;
using System.Collections;

/// <summary>
/// 技能数据
/// </summary>
[CreateAssetMenu(fileName = "New Skill", menuName = "Skill Asset", order = 1)]
public class SkillData : ScriptableObject {
    public string skillName;
    public Sprite skillIcon;
}