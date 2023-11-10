using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardInCollecTion : MonoBehaviour
{
    public List<Card> thisCard = new List<Card>();
    public int thisId;


    public int id;
    public string cardName;
    public int cost;
    public int power;
    public string cardDescription;
    public Sprite thisSprite;


    public TextMeshProUGUI nameText;
    public TextMeshProUGUI costText;
    public TextMeshProUGUI powerText;
    public TextMeshProUGUI descriptionText;
    public Image thatImage;
    

    public bool beGrey;
    public GameObject frame;

    // Start is called before the first frame update
    void Start()
    {
        thisCard[0] = CardDataBase.cardList[thisId];
    }

    // Update is called once per frame
    void Update()
    {
        thisCard[0] = CardDataBase.cardList[thisId];
        
        id = thisCard[0].id;
        cardName = thisCard[0].cardName;
        cost = thisCard[0].cost;
        power = thisCard[0].power;
        cardDescription = thisCard[0].cardDescription;
        thisSprite = thisCard[0].thisImage;

        nameText.text = "" + cardName;
        costText.text = "" + cost;


        powerText.text = "" + power;
        descriptionText.text = " " + cardDescription;
        thatImage.sprite = thisSprite;

        

        if(beGrey == true)
        {
            frame.GetComponent<Image>().color = new Color32(155, 155, 155, 255);
        }
        else
        {
            if (thisCard[0].color == "Red")
            {
                frame.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
            }
            if (thisCard[0].color == "Blue")
            {
                frame.GetComponent<Image>().color = new Color32(0, 0, 255, 255);
            }
            if (thisCard[0].color == "Yellow")
            {
                frame.GetComponent<Image>().color = new Color32(255, 255, 0, 255);
            }
            if (thisCard[0].color == "Purple")
            {
                frame.GetComponent<Image>().color = new Color32(255, 0, 255, 255);
            }
        }
    }
}
