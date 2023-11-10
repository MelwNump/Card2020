using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;


public class ThisCard : MonoBehaviour
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
    public Image frame;

   

    public bool cardBack;
    public static bool staticCardBack;
    public GameObject Hand;
    public int numberOfCardInDeck;

    public bool canBeSummon;
    public bool summoned;
    public GameObject battleZone;

    public static int drawX;
    public int drawXcards;
    public int addXmaxMana;


    public GameObject attackBorder;
    public GameObject Target;
    public GameObject Enemy;

    public bool summoningSickness;
    public bool cantAttack;
    public bool canAttack;

    public static bool staticTargeting;
    public static bool staticTargetingEnemy;
    //target
    public bool targeting;
    public bool targetingEnemy;

    public bool onlyThisCardAttack;

    public GameObject summonBorder;
    //destory
    public bool canBeDestory;
    public GameObject Graveyard;
    public bool beInGraveyard;
    public int Powers;
    //return
    public int hurted;
    public int actuallPower;
    public int returnXcards;
    public bool useReturn;

    public static bool UcanReturn;

    //heal
    public int healXpower;
    public bool canHeal;

    //attack
    public GameObject EnemyZone;
    public AICardToHand aicardToHand;

    //Spell
    public bool spell;
    public int damageDealtBySpell;

    public bool dealDamage;

    public bool stopDealDamage;



    void Start()
    {
        thisCard[0] = CardDataBase.cardList[thisId];

        numberOfCardInDeck = PlayerDeck.deckSize;
        
        canBeSummon = false;
        summoned = false;
        drawX = 0;

        canAttack = false;
        summoningSickness = true;

        Enemy = GameObject.Find("Hp Enemy");

        targeting = false;
        targetingEnemy = false;
        
        canHeal = true;
        //attack
        EnemyZone = GameObject.Find("MyEnemyZone");
       
       

    }

    void Update()
    {
        Hand = GameObject.Find("Hand");
        if (this.transform.parent == Hand.transform.parent)
        {
            cardBack = false;
        }




        id = thisCard[0].id;
        cardName = thisCard[0].cardName;
        cost = thisCard[0].cost;
        power = thisCard[0].power;
        cardDescription = thisCard[0].cardDescription;
        thisSprite = thisCard[0].thisImage;

        drawXcards = thisCard[0].drawXcards;
        addXmaxMana = thisCard[0].addXmaxMana;

        returnXcards = thisCard[0].returnXcard;
        
        healXpower = thisCard[0].healXpower;

        //spell
        spell= thisCard[0].spell;
        damageDealtBySpell = thisCard[0].damageDealtBySpell;

        nameText.text = "" + cardName;
        costText.text = "" + cost;


        powerText.text = "" + power;
        descriptionText.text = " " + cardDescription;
        thatImage.sprite = thisSprite;

        Powers = power - hurted;


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

        staticCardBack = cardBack;

        // CardBack();

        if (this.tag == "Clone")
        {
            thisCard[0] = PlayerDeck.staticDeck[numberOfCardInDeck - 1];
            numberOfCardInDeck -= 1;
            PlayerDeck.deckSize -= 1;
            cardBack = false;
            this.tag = "Untagged";

        }

        //Summon
        if (TurnSystem.currentMana >= cost && summoned == false && beInGraveyard == false && TurnSystem.isYourTurn == true)
        {
            canBeSummon = true;
        }
        else
        {
            canBeSummon = false;
        }

        if (canBeSummon == true)
        {
            gameObject.GetComponent<Draggable>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<Draggable>().enabled = false;
        }

        battleZone = GameObject.Find("Zone");

        if (summoned == false && this.transform.parent == battleZone.transform)
        {
            Summon();
        }


        if (canAttack == true&&beInGraveyard == false)
        {
            attackBorder.SetActive(true);
        }
        else
        {
            attackBorder.SetActive(false);
        }

        if (TurnSystem.isYourTurn == false && summoned == true)
        {
            summoningSickness = false;
            cantAttack = false;
        }

        if (TurnSystem.isYourTurn == true && summoningSickness == false && cantAttack == false)
        {
            canAttack = true;
        }
        else
        {
            canAttack = false;
        }

        targeting = staticTargeting;
        targetingEnemy = staticTargetingEnemy;
        //attack Ai
        if (targetingEnemy == true)
        {
            Target = Enemy;
        }
        else
        {
            Target = null;
        }
        if (targeting == true  && onlyThisCardAttack == true)
        {
            Attack();
        }
        //summonBorder
        if (canBeSummon == true || UcanReturn == true && beInGraveyard == true)
        {
            summonBorder.SetActive(true);
        }
        else
        {
            summonBorder.SetActive(false);
        }
        //Destory //Spell
        if (Powers <= 0 && spell == false)
        {
            DestoryT();
        }
        

        //reTurn
        if (returnXcards > 0 && summoned == true && useReturn == false && TurnSystem.isYourTurn == true)
        {
            Return(returnXcards);
            useReturn = true;
        }
        if (TurnSystem.isYourTurn == false)
        {
            UcanReturn = false;
        }
        //heal
        if (canHeal == true && summoned == true)
        {
            Heal();
            canHeal = false;

        }
        //Spell
        if(damageDealtBySpell >0)
        {
            dealDamage = true;
        }
        if(dealDamage == true&&this.transform.parent == battleZone.transform )
        {
            attackBorder.SetActive(true);
        }
        else
        {
            attackBorder.SetActive(false);
        }

        if(dealDamage==true&&this.transform.parent == battleZone.transform)
        {
            dealxDamage(damageDealtBySpell);
        }

        if(stopDealDamage == true)
        {
            attackBorder.SetActive(false);
            dealDamage = false;
        }

        if(this.transform.parent == battleZone.transform &&spell ==true &&dealDamage == false)
        {
            DestoryT(); 
        }
       
    }
    public void Summon()
    {
        TurnSystem.currentMana -= cost;
        summoned = true;
        MaxMana(addXmaxMana);
        drawX = drawXcards;

    }
    public void MaxMana(int x)
    {
        TurnSystem.maxMana += addXmaxMana;
    }

    public void Attack()
    {
        if (canAttack == true && summoned == true)
        {
            if (Target != null)
            {
                if (Target == Enemy)
                {
                    EnemyHp.staticHp -= power;
                    targeting = false;
                    cantAttack = true;
                }
                
            }
            else
            {
                foreach(Transform child in EnemyZone.transform)
                {
                    if(child.GetComponent<AICardToHand>().isTarget == true)
                    {
                        child.GetComponent<AICardToHand>().hurted = power;
                        hurted = child.GetComponent<AICardToHand>().power;
                        cantAttack = true;
                    }
                }
            }
        }
    }
    //attackHp
    public void UntargetEnemy()
    {
        staticTargetingEnemy = false;
    }
    public void TargetEnemy()
    {
        staticTargetingEnemy = true;
    }
    public void StartAttack()
    {
        staticTargeting = true;
    }
    public void StopAttack()
    {
        staticTargeting = false;
    }
    public void OneCardAttack()
    {
        onlyThisCardAttack = true;
    }
    public void OneCardAttackStop()
    {
        onlyThisCardAttack = false;
    }
    //DestoryCard
    public void DestoryT()
    {
        Graveyard = GameObject.Find("MyGraveyard");
        canBeDestory = true;
        if (canBeDestory == true)
        {
            this.transform.SetParent(Graveyard.transform);
            canBeDestory = false;
            summoned = false;
            beInGraveyard = true;

            hurted = 0;
        }
    }

    //Return
    public void Return(int x)
    {
        for (int i = 0; i <= x; i++)
        {
            ReturnCard();
        }
    }
    public void ReturnCard()
    {
        UcanReturn = true;
    }

    public void returnThis()
    {
        if (beInGraveyard == true && UcanReturn == true)
        {
            this.transform.SetParent(Hand.transform);
            UcanReturn = false;
            beInGraveyard = false;
            summoningSickness = true;
        }
    }
    public void Heal()
    {
        PlayerHp.staticHp += healXpower;
    }

    //Spell
    public void dealxDamage(int x)
    {
        if(Target != null)
        {
            if(Target == Enemy && stopDealDamage == false&& Input.GetMouseButton(0))
            {
                EnemyHp.staticHp -= damageDealtBySpell;
                stopDealDamage = true;
            }
            else
            {
                 foreach(Transform child in EnemyZone.transform)
                 {
                    if(child.GetComponent<AICardToHand>().isTarget == true && Input.GetMouseButton(0))
                    {
                        child.GetComponent<AICardToHand>().hurted += damageDealtBySpell;
                        stopDealDamage=true;
                         
                      
                    }
                 }
            }
        }
    }

}