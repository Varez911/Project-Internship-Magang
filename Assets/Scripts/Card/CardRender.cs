using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityTemplateProjects.Card;

public class CardRender : MonoBehaviour
{
    public static CardData cardData;

    [Header("Description")] 
    public TMP_Text objectName;
    public TMP_Text description;
    
    // Start is called before the first frame update
    void Start()
    {
        // Render Card Object to Scene
        GameObject cardObject =Instantiate(cardData.cardObject, new Vector3(0,1,-1.5f), Quaternion.identity);
        cardObject.name = cardData.cardName;
        cardObject.AddComponent<ObjectController>();
        
        // Set Description from Card Data
        objectName.text = cardData.cardName;
        description.text = cardData.description;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
