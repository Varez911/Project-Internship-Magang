using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityTemplateProjects.Card;

public class CardDisplay : MonoBehaviour
{
    [Header("Card Data")]
    public CardData cardData;

    [Header("Card Reference")]
    public TMP_Text textCard;

    public Image imageThumbnail;
    // Start is called before the first frame update
    void Start()
    {
        imageThumbnail.sprite = cardData.cardThumbnail;
        textCard.text = cardData.cardName;
    }
}
