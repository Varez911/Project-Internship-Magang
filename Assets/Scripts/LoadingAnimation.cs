using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingAnimation : MonoBehaviour
{
    public Image loadingIcon;
    public float rotationTime;  
    private float rotationDegree;
    
    // Start is called before the first frame update
    void Start()
    {
        rotationDegree = 0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rotationDegree += 12f;
        loadingIcon.transform.rotation = Quaternion.Euler(0, 0, rotationDegree % 360);
    }
}
