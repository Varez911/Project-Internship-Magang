using System;
using UnityEngine;

namespace UnityTemplateProjects.Card
{
    
    [CreateAssetMenu(fileName = "New Card", menuName = "Cards")]
    public class CardData : ScriptableObject
    {
        public String cardName;
        [TextArea(15,10)]
        public String description;

        public Sprite cardThumbnail;

        public GameObject cardObject;
    }
}