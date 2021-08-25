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
    public SceneAsset m_Scene;

    private CardData _cardData;
    public void ShowObject()
    {
        GameObject _card = EventSystem.current.currentSelectedGameObject;
        
        _cardData = _card.GetComponent<CardDisplay>().cardData;

        // StartCoroutine(LoadYourAsyncScene());
        
        CardRender.cardData = _cardData;
        SceneManager.LoadScene("Main");
    }
    
    IEnumerator LoadYourAsyncScene()
    {
        // Instantiate GameObject from Card Data
        GameObject cardObject = Instantiate(_cardData.cardObject, new Vector3(0, 1, 0), Quaternion.identity);
        cardObject.name = _cardData.cardName;
        
        // Set the current Scene to be able to unload it later
        Scene currentScene = SceneManager.GetActiveScene();

        // The Application loads the Scene in the background at the same time as the current Scene.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(m_Scene.name, LoadSceneMode.Additive);

        // Wait until the last operation fully loads to return anything
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // Move the GameObject (you attach this in the Inspector) to the newly loaded Scene
        SceneManager.MoveGameObjectToScene(cardObject, SceneManager.GetSceneByName(m_Scene.name));
        // Unload the previous Scene
        SceneManager.UnloadSceneAsync(currentScene);
    }
}
