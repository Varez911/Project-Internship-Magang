using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARViewController : MonoBehaviour
{
    public Toggle toggleARView;


    [Space]
    [Header("3D Mode")]
    public GameObject _3DMode;
    public GameObject mainCamera;

    [Header("AR Mode")]
    public GameObject aRMode;

    [Header("UI")] public GameObject deskripsiPanel;
    //==================================
    private GameObject arObject;
    private ObjectController arObjectController;
    private XRCameraController cameraARController;
    
    // Start is called before the first frame update
    void Start()
    {
        

    }

    public void ViewUpdate()
    {
        foreach (Transform child in _3DMode.transform)
        {
            Debug.Log(child.name);
            if (child.tag == "ARObject")
                arObject = child.gameObject;
        }
        if (toggleARView.isOn)
        {
            mainCamera.SetActive(false);
            aRMode.SetActive(true);
            arObject.transform.parent = aRMode.transform.Find("ARSurface");
            arObject.SetActive(false);
            deskripsiPanel.SetActive(false);
        }
        else
        {
            mainCamera.SetActive(true);
            aRMode.SetActive(false);
            arObject.transform.parent = _3DMode.transform;
            arObject.SetActive(true);
            deskripsiPanel.SetActive(true);

        }
    }
}
