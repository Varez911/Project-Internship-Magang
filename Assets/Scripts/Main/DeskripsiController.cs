using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeskripsiController : MonoBehaviour
{
    public TMP_Text description;
    public GameObject nextButton, prevButton;
    
    private int pageCount
    {
        get { return description.textInfo.pageCount; }
    }

    public void NextText()
    {
        description.pageToDisplay += 1;
        if (pageCount > description.pageToDisplay)
        {
            prevButton.SetActive(true);
        }
        else
        {
            nextButton.SetActive(false);
        }
    }

    public void PrevText()
    {
        description.pageToDisplay -= 1;
        if (1 != description.pageToDisplay)
        {
            nextButton.SetActive(true);
        }
        else
        {
            prevButton.SetActive(false);
        }
    }
}
