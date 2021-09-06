using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 5f;

    private static readonly float PanSpeed = 10f;

    private Vector3 lastPanPosition;
    private int panFingerId; // Touch mode only
    
    private bool wasZoomingLastFrame; // Touch mode only
    private Vector2[] lastZoomPositions; // Touch mode only
    
    

    void Update()
    {
        if (Input.touchCount > 0)
        {
            if (Input.touchCount == 1)
            {
                float pointer_x = Input.touches[0].deltaPosition.x;
                float pointer_y = Input.touches[0].deltaPosition.y;
                transform.Rotate((pointer_y * rotationSpeed * Time.deltaTime),
                    (-pointer_x * rotationSpeed * Time.deltaTime), 0, Space.World);
            }
        }
    }
    
}
