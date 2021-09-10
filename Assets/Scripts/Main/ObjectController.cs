using System;
using System.Collections;
using System.Collections.Generic;
using DigitalRubyShared;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 5f;

    private static readonly float PanSpeed = 10f;

    private Vector3 lastPanPosition;
    private int panFingerId; // Touch mode only
    
    private bool wasZoomingLastFrame; // Touch mode only
    private Vector2[] lastZoomPositions; // Touch mode only
    private PanGestureRecognizer panGesture;

    private void PanGestureCallback(GestureRecognizer gesture)
    {
        if (gesture.State == GestureRecognizerState.Executing)
        {
            // DebugText("Panned, Location: {0}, {1}, Delta: {2}, {3}", gesture.FocusX, gesture.FocusY, gesture.DeltaX, gesture.DeltaY);

            float deltaX = panGesture.DeltaX / 25.0f;
            float deltaY = panGesture.DeltaY / 25.0f;
            Vector3 pos = transform.position;
            pos.x += deltaX;
            pos.y += deltaY;
            transform.position = pos;
        }
    }

    private void CreatePanGesture()
    {
        panGesture = new PanGestureRecognizer();
        panGesture.MinimumNumberOfTouchesToTrack = 2;
        panGesture.StateUpdated += PanGestureCallback;
        FingersScript.Instance.AddGesture(panGesture);
    }

    private void Start()
    {
        CreatePanGesture();
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
        }
    }
    
}
