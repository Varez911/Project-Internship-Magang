using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 5f;
    public float zoomOutMin = 1;
    public float zoomOutMax = 8;

    private static readonly float PanSpeed = 10f;

    private static readonly float[] BoundsX = new float[]{-10f, 5f};
    private static readonly float[] BoundsZ = new float[]{-18f, -4f};
    private static readonly float[] ZoomBounds = new float[]{10f, 85f};

    private Camera _mainCamera;
    private Vector3 lastPanPosition;
    private int panFingerId; // Touch mode only
    
    private bool wasZoomingLastFrame; // Touch mode only
    private Vector2[] lastZoomPositions; // Touch mode only
    
    
    void Awake() 
    {
        _mainCamera = GetComponent<Camera>();
    }

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
            else if (Input.touchCount == 2)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began) {
                    lastPanPosition = touch.position;
                    panFingerId = touch.fingerId;
                } else if (touch.fingerId == panFingerId && touch.phase == TouchPhase.Moved) {
                    PanCamera(touch.position);
                }
            }
        }
    }
    
    void PanCamera(Vector3 newPanPosition) {
        // Determine how much to move the camera
        Vector3 offset = _mainCamera.ScreenToViewportPoint(lastPanPosition - newPanPosition);
        Vector3 move = new Vector3(offset.x * PanSpeed, 0, offset.y * PanSpeed);
        
        // Perform the movement
        transform.Translate(move, Space.World);  
        
        // Ensure the camera remains within bounds.
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(transform.position.x, BoundsX[0], BoundsX[1]);
        pos.z = Mathf.Clamp(transform.position.z, BoundsZ[0], BoundsZ[1]);
        transform.position = pos;
    
        // Cache the position
        lastPanPosition = newPanPosition;
    }
}
