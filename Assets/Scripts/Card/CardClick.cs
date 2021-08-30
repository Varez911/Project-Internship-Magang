using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityTemplateProjects.Card;

public class CardClick : MonoBehaviour
{
    private CardData _cardData;
    public void ShowObject()
    {
        GameObject _card = EventSystem.current.currentSelectedGameObject;
        
        _cardData = _card.GetComponent<CardDisplay>().cardData;

        // StartCoroutine(LoadYourAsyncScene());
        
        CardRender.cardData = _cardData;
        SceneManager.LoadScene("Main");
    }
    
}
