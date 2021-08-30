using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARViewController : MonoBehaviour
{
    public Toggle toggleARView;

    public GameObject mainCamera;
    public GameObject ARCamera;
    private XRCameraController cameraARController;
    private GameObject arObject;

    private ObjectController arObjectController;

    private XRVideoController arCameraVideoController;
    private XRCameraController arCameraController;
    // Start is called before the first frame update
    void Start()
    {
        arObject = GameObject.FindWithTag("ARObject");
        arObjectController = arObject.GetComponent<ObjectController>();
        arCameraVideoController = ARCamera.GetComponent<XRVideoController>();
        arCameraController = ARCamera.GetComponent<XRCameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (toggleARView.isOn)
        {
            //ARCamera.SetActive(true); 
            mainCamera.SetActive(false);
            arObjectController.enabled = false;
            arCameraVideoController.enabled = true;
            arCameraController.enabled = true;
        }
        else
        {
            //ARCamera.SetActive(false);
            mainCamera.SetActive(true);
            arObject.transform.position = new Vector3(0, 1, -1.5f);
            arObjectController.enabled = true;
            arCameraVideoController.enabled = false;
            arCameraController.enabled = false;

        }
    }
}
