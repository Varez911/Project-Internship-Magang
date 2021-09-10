using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeskripsiController : MonoBehaviour
{
    public GameObject horizontalDescription;
    public GameObject nextButton, prevButton;
    public GameObject progressBar;
    
    private RectTransform _rectTransform;
    private int descriptionPage;
    
    private float lerpDuration = 2f; 
    private float moveValue = -662; 
    private void Start()
    {
        descriptionPage = 1;
        _rectTransform = horizontalDescription.GetComponent<RectTransform>();
    }

    public void NextText()
    {
        Vector3 from = _rectTransform.transform.localPosition;
        Vector3 to = new Vector3(_rectTransform.transform.localPosition.x + moveValue,
            _rectTransform.transform.localPosition.y, _rectTransform.transform.localPosition.z);
            
        StartCoroutine(MoveFromTo(from, to, lerpDuration, _rectTransform));
        descriptionPage++;
        FillProgressBar(descriptionPage);

        if (descriptionPage > 2)
        {
            nextButton.SetActive(false);
        }
        prevButton.SetActive(true);

    }

    public void PrevText()
    {
        Vector3 from = _rectTransform.transform.localPosition;
        Vector3 to = new Vector3(_rectTransform.transform.localPosition.x - moveValue,
            _rectTransform.transform.localPosition.y, _rectTransform.transform.localPosition.z);
            
        StartCoroutine(MoveFromTo(from, to, lerpDuration, _rectTransform));
        descriptionPage--;
        FillProgressBar(descriptionPage);
        
        if (descriptionPage < 2)
        {
            prevButton.SetActive(false);
        }
        nextButton.SetActive(true);

    }
    
    private IEnumerator MoveFromTo(Vector3 from, Vector3 to, float speed, Transform tra)
    {
        nextButton.GetComponent<Button>().interactable = false;
        prevButton.GetComponent<Button>().interactable = false;

        var t = 0f;
 
        while (t < 1f)
        {
            t += speed * Time.deltaTime;
            tra.localPosition = Vector3.Lerp(from, to, t);
            yield return null;
        }
        
        nextButton.GetComponent<Button>().interactable = true;
        prevButton.GetComponent<Button>().interactable = true;
    }

    private void FillProgressBar(int _descriptionPage)
    {
        for (int i = 0; i < progressBar.transform.childCount; i++)
        {
            if (i < _descriptionPage)
            {
                progressBar.transform.GetChild(i).GetComponent<Toggle>().isOn = true;
            }
            else
            {
                progressBar.transform.GetChild(i).GetComponent<Toggle>().isOn = false;
            }
        }
    }
    
}
