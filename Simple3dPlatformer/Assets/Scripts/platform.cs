using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    [SerializeField] Transform[] point;
    [SerializeField] float platformSpeed = 2.0f;

    int currentIndex = 0;

    void Update()
    {
        platformMove();
    }

    void platformMove()
    {
        transform.position = Vector3.MoveTowards(transform.position, point[currentIndex].position, platformSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, point[currentIndex].position) < 1.0f)
        {
            currentIndex = (currentIndex + 1) % point.Length;
        }
    }
}
