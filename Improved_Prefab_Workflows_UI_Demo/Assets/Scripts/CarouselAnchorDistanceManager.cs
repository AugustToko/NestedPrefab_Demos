using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

/// <summary>
/// [ExecuteAlways]: 当你希望这个脚本能在 Editor 非player状态起作用, 加上这个标签
/// 旋转圆盘锚点距离管理
/// </summary>
[ExecuteAlways]
public class CarouselAnchorDistanceManager : MonoBehaviour
{
    /// <summary>
    /// 从 Pivot 到 Anchor 的距离
    /// </summary>
    public float anchorDistanceFromPivot = 500;
    
    /// <summary>
    /// 锚点数组
    /// </summary>
    public Transform[] anchorTransforms;

    /// <summary>
    /// 当前锚点距离
    /// </summary>
    private float _currentAnchorDistance;
    
    /// <summary>
    /// 新的距离
    /// </summary>
    private float _newDistance;

    // 0 = +z
    // 1 = +x
    // 2 = -z
    // 3 = -x

    [SuppressMessage("ReSharper", "CompareOfFloatsByEqualityOperator")]
    void Update()
    {
        if(_currentAnchorDistance != anchorDistanceFromPivot)
        {
            _currentAnchorDistance = anchorDistanceFromPivot;

            SetNewAnchorPositions();

        }
    }

    /// <summary>
    /// 设置锚点位置
    /// </summary>
    private void SetNewAnchorPositions()
    {
        anchorTransforms[0].localPosition = new Vector3(0, 0, _currentAnchorDistance);
        anchorTransforms[1].localPosition = new Vector3(_currentAnchorDistance, 0, 0);
        anchorTransforms[2].localPosition = new Vector3(0, 0, -_currentAnchorDistance);
        anchorTransforms[3].localPosition = new Vector3(-_currentAnchorDistance, 0, 0);
    }

}
