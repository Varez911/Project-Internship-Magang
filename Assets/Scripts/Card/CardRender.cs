using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityTemplateProjects.Card;

public class CardRender : MonoBehaviour
{
    public static CardData cardData;

    [Header("Camera")] public GameObject mainCamera;
    
    [Header("Description")] 
    public GameObject horizontalLayout;
    public TMP_Text descriptionText;
    
    // Start is called before the first frame update
    private void Awake()
    {
        // SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex((int)SceneList.MAIN));
    }

    void Start()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex((int)SceneList.MAIN));

        // Render Card Object to Scene
        GameObject cardObject = Instantiate(cardData.cardObject, new Vector3(0,1,0), Quaternion.identity);
        cardObject.name = cardData.cardName;
        cardObject.AddComponent<ObjectController>();
        // cardObject.transform.parent = mainCamera.transform;
        
        // Attach XRSurfaceController to Object
        XRSurfaceController objectSurface = cardObject.AddComponent<XRSurfaceController>();
        cardObject.tag = "ARObject";
        objectSurface.displayImmediately = true;
        // objectSurface.groundOnly = true;
        objectSurface.lockToFirstSurface = true;


        // Set Object Name
        for (int i = 0; i < horizontalLayout.transform.childCount; i++)
        {
            horizontalLayout.transform.GetChild(i).Find("Object Name").GetComponent<TMP_Text>().text = cardData.cardName;
        }
        
        // Set Description from Card Data
        descriptionText.text = cardData.description;
        

    }

}
