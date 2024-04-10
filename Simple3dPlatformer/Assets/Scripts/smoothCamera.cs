using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smoothCamera : MonoBehaviour
{
    Vector3 offset;
    [SerializeField] Transform target;
    [SerializeField] float smoothTime;
    private Vector3 moveVelocity = Vector3.zero;
    Vector3 targetPosition;

    private void Awake()
    {
        offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        targetPosition  = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref moveVelocity, smoothTime);
    }
}
