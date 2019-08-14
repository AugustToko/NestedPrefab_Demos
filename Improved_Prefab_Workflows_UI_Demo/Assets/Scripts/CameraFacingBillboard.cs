using UnityEngine;
using System.Collections;
 
[ExecuteAlways]
public class CameraFacingBillboard : MonoBehaviour
{
    public Camera m_Camera;
 
    /// <summary>
    /// 在此帧完成所有移动后确定相机的方向，以避免抖动
    /// </summary>
    void LateUpdate()
    {

        if(m_Camera)
        {
            transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.forward,
                m_Camera.transform.rotation * Vector3.up);
        }
    }
}