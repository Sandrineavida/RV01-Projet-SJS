using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereBoundary : MonoBehaviour
{
    public Transform sphereCenter; // ���ĵ�Transform
    public float sphereRadius = 10f; // ���α߽�İ뾶

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Interactive"))
        {
            Debug.Log("11111");
            Vector3 toObject = other.transform.position - sphereCenter.position;
            if (toObject.magnitude > sphereRadius)
            {
                // ����Գ�λ��
                Vector3 newPosition = sphereCenter.position - toObject.normalized * sphereRadius;
                other.transform.position = newPosition;
                // �ٶȱ��ֲ���
            }
        }
    }
}
