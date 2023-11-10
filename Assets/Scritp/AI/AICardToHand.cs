using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AICardToHand : MonoBehaviour
{
    public List<Card> thisCard = new List<Card>();
    
    //Hand Ai

    public int thisId;

    public int id;
    public string cardName;
    public int cost;
    public int power;
    public string cardDescription;
    
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI costText;
    public TextMeshProUGUI powerText;
    public TextMeshProUGUI descriptionText;

    public Sprite thisSprite;
    public Image thatImage;

    public Image frame;

    //DrawXAi
    public static int DrawX;
    public int drawXcards;
    public int addXmaxMana;

    //return Ai
    public int hurted;
    public int actuallPower;
    public int returnXcards;

    public GameObject Hand;

    public int z = 0;
    public GameObject It;

    public int numberOfCardInDeck;

    //AttackCard
    public bool isTarget;
    public GameObject Graveyard;

    public bool thisCardCanBeDestroyed;

    //CardBack
    public GameObject cardBack;
    public GameObject AiZone;

    //AttackAi
    public bool canAttack;
    public bool sumoningSickness;

    //Fix
    public bool isSummoned;
    public GameObject battleZone;


    // Start is called before the first frame update
    void Start()
    {
        //Hand AI
      


        thisCard[0] = CardDataBase.cardList[thisId];
        Hand = GameObject.Find("EnemyHand");

        z = 0;
        numberOfCardInDeck = AI.deckSize;

        //Attack
        Graveyard = GameObject.Find("Enemy Graveyard");
        StartCoroutine(AfterVoidStart());

        //cardBack
        AiZone = GameObject.Find("MyEnemyZone");

        //attackAi
        sumoningSickness = true;

        //
        battleZone = GameObject.Find("MyEnemyZone");

    }

    // Update is called once per frame
    void Update()
    {
        if(z==0)
        {          
            It.transform.SetParent(Hand.transform);
            It.transform.localScale = Vector3.one;
            It.transform.position = new Vector3(transform.position.x, transform.position.y, -48);
            It.transform.eulerAngles = new Vector3(25, 0, 0);
            z = 1;
        }
        //load CardData Ai
        id = thisCard[0].id;
        cardName = thisCard[0].cardName;
        cost = thisCard[0].cost;
        power = thisCard[0].power;
        cardDescription = thisCard[0].cardDescription;
        thisSprite = thisCard[0].thisImage;

        drawXcards = thisCard[0].drawXcards;
        addXmaxMana = thisCard[0].addXmaxMana;

        returnXcards = thisCard[0].returnXcard;


        nameText.text = "" + cardName;
        costText.text = "" + cost;


        powerText.text = "" + actuallPower;
        descriptionText.text = " " + cardDescription;
        thatImage.sprite = thisSprite;

        actuallPower = power - hurted;

        //Color
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
        //PutData
        if(this.tag == "Clone")
        {
           
            thisCard[0] = AI.staticEnemyDeck[numberOfCardInDeck - 1];
            numberOfCardInDeck -= 1;
            AI.deckSize -= 1;
            this.tag = "Untagged";
        }

        //Attack
        if(hurted >= power && thisCardCanBeDestroyed == true)
        {
            this.transform.SetParent(Graveyard.transform);
            hurted = 0;
        }
        
        //CardBack
        if(this.transform.parent == Hand.transform)
        {
            cardBack.SetActive(true);
        }

        if(this.transform.parent == AiZone.transform)
        {
            cardBack.SetActive(false);
        }

        //attackAi
        if(TurnSystem.isYourTurn == false&& sumoningSickness == false)
        {
            canAttack = true;
        }
        else
        {
            canAttack = false;
        }

        if(TurnSystem.isYourTurn == true&& this.transform.parent == AiZone.transform)
        {
            sumoningSickness = false;
        }

        if(this.transform.parent == battleZone.transform && isSummoned == false)
        {
            if (drawXcards > 0)
            {
                DrawX = drawXcards;
                isSummoned = true;
            }
           
            if(id==2)
            {
                TurnSystem.maxEnemyMana += 3;
                isSummoned = true;
            }
        }

        
    }
    //void Attack
    public void BeingTarget()
    {
        isTarget = true;
    }
    public void DontBeingtarget ()
    {
        isTarget = false;
    }


    //CoutAttack
    IEnumerator AfterVoidStart()
    {
        yield return new WaitForSeconds(1);
        thisCardCanBeDestroyed = true;
    }

}
