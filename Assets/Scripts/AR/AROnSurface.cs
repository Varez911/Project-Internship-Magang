using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AROnSurface : MonoBehaviour
{
    private GameObject _arObject;
    public GameObject _loadingAR;
    

    public void SearchSurfaces(GameObject _placeButton)
    {
        Debug.Log("Surfaces Detected");
        _loadingAR.SetActive(false);
    }
    
    public void RenderObjectOnSurface(GameObject _arSurface)
    {
        foreach (Transform child in _arSurface.transform)
        {
            Debug.Log(child.name);
            if (child.tag == "ARObject")
                _arObject = child.gameObject;
        }
        
        Debug.Log("Placing Object on Surface");
        _arObject.SetActive(true);

    }
}
