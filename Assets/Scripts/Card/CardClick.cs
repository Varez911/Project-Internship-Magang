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
    private ChangeScene _changeScene;
    private void Start()
    {
        _changeScene = GameObject.Find("App Manager").GetComponent<ChangeScene>();
    }

    public void ShowObject()
    {
        GameObject _card = EventSystem.current.currentSelectedGameObject;
        
        _cardData = _card.GetComponent<CardDisplay>().cardData;

        CardRender.cardData = _cardData;
        _changeScene.ChangeToMain();
    }
    
}
