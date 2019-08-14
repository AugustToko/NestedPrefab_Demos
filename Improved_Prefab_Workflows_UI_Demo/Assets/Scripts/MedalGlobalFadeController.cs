using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 勋章全局渐控制器
/// </summary>
[ExecuteAlways]
public class MedalGlobalFadeController : Singleton<MedalGlobalFadeController>
{
    public float fadeMultiplierValue;
    public Transform fadeReferenceTransform;
}
