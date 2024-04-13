using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour 
{
    public float RotationAngleX;
    public float RotationAngleY;
    private Rigidbody Player;

    void Start()
    {
        Player = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        RotationAngleX += Input.GetAxis("Mouse X");
        RotationAngleY -= Input.GetAxis("Mouse Y");     
        RotationAngleY = Mathf.Clamp(RotationAngleY, -90f, 90f);
        Player.MoveRotation(Quaternion.Euler(RotationAngleY, RotationAngleX, 0));
    }
}