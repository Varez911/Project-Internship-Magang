using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTouchManager : MonoBehaviour
{
    private static readonly float PanSpeed = 20f;
    private static readonly float ZoomSpeedTouch = 0.1f;
    private static readonly float ZoomSpeedMouse = 0.5f;
    
    private static readonly float[] BoundsX = new float[]{-10f, 5f};
    private static readonly float[] BoundsZ = new float[]{-18f, -4f};
    private static readonly float[] ZoomBounds = new float[]{10f, 85f};
    
    private Camera cam;
    
    private Vector3 lastPanPosition;
    private int panFingerId; // Touch mode only
    
    private bool wasZoomingLastFrame; // Touch mode only
    private Vector2[] lastZoomPositions; // Touch mode only

    private void Awake() 
    {
        cam = GetComponent<Camera>();
    }
    
    private void Update() 
    {
        if (Input.touchSupported && Application.platform != RuntimePlatform.WebGLPlayer) {
            HandleTouch();
        }
    }
    
    private void HandleTouch() {
        switch(Input.touchCount) {
    
        case 2: // Zoom
            Vector2[] newPositions = new Vector2[]{Input.GetTouch(0).position, Input.GetTouch(1).position};
            if (!wasZoomingLastFrame) {
                lastZoomPositions = newPositions;
                wasZoomingLastFrame = true;
            } else {
                float newDistance = Vector2.Distance(newPositions[0], newPositions[1]);
                float oldDistance = Vector2.Distance(lastZoomPositions[0], lastZoomPositions[1]);
                float offset = newDistance - oldDistance;
    
                ZoomCamera(offset, ZoomSpeedTouch);
    
                lastZoomPositions = newPositions;
            }
            break;
            
        default: 
            wasZoomingLastFrame = false;
            break;
        }
    }
    
    void PanCamera(Vector3 newPanPosition) {
        // Determine how much to move the camera
        Vector3 offset = cam.ScreenToViewportPoint(lastPanPosition - newPanPosition);
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
    
    void ZoomCamera(float offset, float speed) {
        if (offset == 0) {
            return;
        }
    
        cam.fieldOfView = Mathf.Clamp(cam.fieldOfView - (offset * speed), ZoomBounds[0], ZoomBounds[1]);
    }
}
