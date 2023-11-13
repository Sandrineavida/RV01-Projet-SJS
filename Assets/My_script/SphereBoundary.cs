using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereBoundary : MonoBehaviour
{
    public Transform sphereCenter; // 球心的Transform
    public float sphereRadius = 10f; // 球形边界的半径

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Interactive"))
        {
            Debug.Log("11111");
            Vector3 toObject = other.transform.position - sphereCenter.position;
            if (toObject.magnitude > sphereRadius)
            {
                // 计算对称位置
                Vector3 newPosition = sphereCenter.position - toObject.normalized * sphereRadius;
                other.transform.position = newPosition;
                // 速度保持不变
            }
        }
    }
}
