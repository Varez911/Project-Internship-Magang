using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARTestCapabilities : MonoBehaviour
{
    private static readonly float POINT_WIDTH = 0.04267f;  // Golf ball
    private static Color DARK_GREEN = new Color(5.0f/255, 106.0f/255, 50.0f/255);
    
    private XRController xr;
    private List<PointWithRenderer> points;

    private class PointWithRenderer {
        public readonly GameObject point;
        public readonly MeshRenderer renderer;
        public PointWithRenderer() {
            point = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            renderer = point.GetComponent<MeshRenderer>();
            renderer.material.color = DARK_GREEN;
            point.transform.localScale = new Vector3(POINT_WIDTH, POINT_WIDTH, POINT_WIDTH);
        }
        public void RenderPoint(Vector3 position) {
            point.transform.position = position;
            renderer.enabled = true;
        }
    }

    void RenderPoints(List<XRWorldPoint> pts) {
        int v = 0;
        foreach (var pt in pts) {
            // Center
            if (points.Count < v + 1) {
                points.Add(new PointWithRenderer());
            }

            points[v].RenderPoint(pt.position);
            ++v;
        }

        for (; v < points.Count; ++v) {
            points[v].renderer.enabled = false;
        }
    }
    private void Start()
    {
        switch (XRController.GetARCoreAvailability()) {
            case ARCoreAvailability.SUPPORTED_APK_TOO_OLD:
                Debug.Log("The Android device is supported by ARCore, ARCore is installed, but the installed version of ARCore is too old.");
                break;
            case ARCoreAvailability.SUPPORTED_INSTALLED:
                Debug.Log("The Android device is supported by ARCore, ARCore is installed, and is available for use.");
                break;
            case ARCoreAvailability.SUPPORTED_NOT_INSTALLED:
                Debug.Log("The Android device is supported by ARCore, but ARCore is not installed on the device.");
                break;
            case ARCoreAvailability.UNSUPPORTED_DEVICE_NOT_CAPABLE:
                Debug.Log("The Android device is not supported by ARCore.");
                break;
            case ARCoreAvailability.UNKNOWN:
                Debug.Log("The Android device does not have ARCore installed, and the query to check for availability has either: failed with an error, timed out or not completed.");
                break;
            default:
                // ARCoreAvailability.UNSPECIFIED
                Debug.Log("The device is non-Android, or unable to determine the availability of ARCore.");
                break;
        }
        
        xr = GameObject.FindWithTag("XRController").GetComponent<XRController>();
        points = new List<PointWithRenderer>();
    }

    private void Update()
    {
        Debug.Log(xr.GetWorldPoints()[0]);
        //RenderPoints(xr.GetWorldPoints());
    }

    public void RenderObject()
    {
        GameObject arObject = GameObject.FindWithTag("ARObject");
        
        arObject.SetActive(true);
    }
}
