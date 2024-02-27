﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
    
{
    public Transform CameraAxisTransform;
    public float RotationSpeed;
    public float MinAngle;
    public float MaxAngle;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y + Time.deltaTime * RotationSpeed * Input.GetAxis("Mouse X"), 0);

        var NewAngleX = CameraAxisTransform.localEulerAngles.x - Time.deltaTime * RotationSpeed * Input.GetAxis("Mouse Y");
        if (NewAngleX > 180)
            NewAngleX -= 360;
        
        NewAngleX = Mathf.Clamp(NewAngleX, MinAngle, MaxAngle);


        CameraAxisTransform.localEulerAngles = new Vector3(NewAngleX, 0, 0);
    }

    
  
}
