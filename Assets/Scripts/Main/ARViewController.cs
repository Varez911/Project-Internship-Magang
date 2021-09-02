using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARViewController : MonoBehaviour
{
    public Toggle toggleARView;

    public GameObject mainCamera;
    public GameObject ARCamera;
    
    //==================================
    private GameObject arObject;
    private ObjectController arObjectController;
    private XRCameraController cameraARController;
    // Start is called before the first frame update
    void Start()
    {
        arObject = GameObject.FindWithTag("ARObject");
    }

    public void ViewUpdate()
    {
        if (toggleARView.isOn)
        {
            ARCamera.SetActive(true); 
            mainCamera.SetActive(false);
            arObjectController.enabled = false;
        }
        else
        {
            ARCamera.SetActive(false);
            mainCamera.SetActive(true);
            arObjectController.enabled = true;
        }
    }
}
