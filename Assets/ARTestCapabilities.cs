using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARTestCapabilities : MonoBehaviour
{

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
    }

    public void RenderObject()
    {
        GameObject arObject = GameObject.FindWithTag("ARObject");
        arObject.SetActive(true);
    }
}
