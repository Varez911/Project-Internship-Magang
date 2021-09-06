using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARViewController : MonoBehaviour
{
    public Toggle toggleARView;

    public GameObject mainCamera;
    public GameObject ARCamera;
    public GameObject resetButton;
    public GameObject xrController;

    [Space] public GameObject surfaceAR;
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
            arObject.SetActive(false);
            ARCamera.SetActive(true); 
            mainCamera.SetActive(false);
            resetButton.SetActive(true);
            xrController.SetActive(true);
            

            //arObjectController.enabled = false;
        }
        else
        {
            ARCamera.SetActive(false);
            mainCamera.SetActive(true);
            resetButton.SetActive(false);
            xrController.SetActive(false);
            //arObjectController.enabled = true;
        }
    }
}
