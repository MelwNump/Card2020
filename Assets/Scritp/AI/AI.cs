using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AI : MonoBehaviour
{
    public List<Card> deck = new List<Card>();
    public List<Card> container = new List<Card>();
    public static List<Card> staticEnemyDeck = new List<Card>();

    //AI Hand
    public List<Card> cardsInHand = new List<Card>();

    //Ai Attack
    public List<Card> cardsInZone = new List<Card>();




    public GameObject Hand;
    public GameObject Zone;
    public GameObject Graveyard;

    public int x;
    public static int deckSize;

    public GameObject cardInDeck1;
    public GameObject cardInDeck2;
    public GameObject cardInDeck3;
    public GameObject cardInDeck4;

    public GameObject CardToHand;

    public GameObject[] Clones;

    public static bool draw;

    public GameObject CardBack;

    //Summon
    public int currentMana;

    public bool[] AiCanSummon;

    public bool drawPhase;
    public bool summonPhase;
    public bool attackPhase;
    public bool endPhase;

    public int[] cardsID;

    public int summonThisId;

    public AICardToHand aicardToHand;

    public int summonID;

    public int howmanyCards;

    // attack ai
    public bool[] canAttack;
    public static bool AiEndPhase;

    //ChooseEnemy
    public static int whichEnemy;



    // Start is called before the first frame update
    void Start()
    {
        //handAi
        //StartCoroutine(WaitFiveSeconds());

        // StartCoroutine(StartGame());

        Hand = GameObject.Find("EnemyHand");
        Zone = GameObject.Find("MyEnemyZone");
        Graveyard = GameObject.Find("Enemy Graveyard");

        x = 0;
        deckSize = 40;

        draw = true;

        //for(int i=0; i < deckSize; i++)
        //{
        //    x = Random.Range(1, 5);
        //    deck[i] = CardDataBase.cardList[x];
        //}
        if (whichEnemy == 1)
        {
            for (int i = 0; i < deckSize; i++)
            {
                if (i <= 19)
                {
                    deck[i] = CardDataBase.cardList[2];
                }
                else
                {
                    deck[i] = CardDataBase.cardList[3];
                }
            }

        }
        if (whichEnemy == 2)
        {
            for (int i = 0; i < deckSize; i++)
            {
                if (i <= 19)
                {
                    deck[i] = CardDataBase.cardList[1];
                }
                else
                {
                    deck[i] = CardDataBase.cardList[4];
                }
            }

        }

        Shuffle();
        StartCoroutine(StartGame());
    }

    // Update is called once per frame
    void Update()
    {
        //deckEnemy
        staticEnemyDeck = deck;

        //CardDeck
        if (deckSize < 30)
        {
            cardInDeck1.SetActive(false);
        }
        if (deckSize < 20)
        {
            cardInDeck2.SetActive(false);
        }
        if (deckSize < 2)
        {
            cardInDeck3.SetActive(false);
        }
        if (deckSize < 1)
        {
            cardInDeck4.SetActive(false);
        }

        //draw Ai Ef
        if (AICardToHand.DrawX > 0)
        {
            StartCoroutine(Draw(AICardToHand.DrawX));
            AICardToHand.DrawX = 0;
        }

        if (TurnSystem.startTurn == false && draw == false)
        {
            StartCoroutine(Draw(1));
            draw = true;
        }

        //summon
        currentMana = TurnSystem.currentEnemyMana;

        if (0 == 0)
        {
            int j = 0;
            howmanyCards = 0;
            foreach (Transform child in Hand.transform)
            {
                howmanyCards++;

            }
            foreach (Transform child in Hand.transform)
            {
                cardsInHand[j] = child.GetComponent<AICardToHand>().thisCard[0];
                j++;
            }

            for (int i = 0; i < 40; i++)
            {
                if (i >= howmanyCards)
                {
                    cardsInHand[i] = CardDataBase.cardList[0];
                }
            }
            j = 0;
        }
        //summon cost
        if (TurnSystem.isYourTurn == false)
        {
            for (int i = 0; i < 40; i++)
            {
                if (cardsInHand[i].id != 0)
                {
                    if (currentMana >= cardsInHand[i].cost)
                    {
                        AiCanSummon[i] = true;
                    }
                }
            }
        }
        else
        {
            for (int i = 0; i < 40; i++)
            {
                AiCanSummon[i] = false;
            }
        }

        if (TurnSystem.isYourTurn == false)
        {
            drawPhase = true;
        }

        if (drawPhase == true && summonPhase == false && attackPhase == false)
        {
            StartCoroutine(WaitForSummonPhase());
        }


        if (TurnSystem.isYourTurn == true)
        {
            drawPhase = false;
            summonPhase = false;
            attackPhase = false;
            endPhase = false;
        }




        //summonTrue
        if (summonPhase == true)
        {
            summonID = 0;
            summonThisId = 0;

            int index = 0;
            for (int i = 0; i < 40; i++)
            {
                if (AiCanSummon[i] == true)
                {
                    cardsID[index] = cardsInHand[i].id;
                    index++;
                }
            }

            for (int i = 0; i < 40; i++)
            {
                if (cardsID[i] != 0)
                {
                    if (cardsID[i] > summonID)
                    {
                        summonID = cardsID[i];
                    }
                }
            }
            //MoveCardAiSummonTrue
            summonThisId = summonID;

            foreach (Transform child in Hand.transform)
            {
                if (child.GetComponent<AICardToHand>().id == summonThisId && CardDataBase.cardList[summonThisId].cost <= currentMana)
                {
                    child.transform.SetParent(Zone.transform);
                    TurnSystem.currentEnemyMana -= CardDataBase.cardList[summonThisId].cost;
                    break;
                }
            }
            //summonReset
            summonPhase = false;
            attackPhase = true;

        }

        //attack ai
        if (0 == 0)
        {

            int k = 0;
            int howmanyCards2 = 0;
            foreach (Transform child in Zone.transform)
            {
                howmanyCards2++;

            }
            foreach (Transform child in Zone.transform)
            {
                canAttack[k] = child.GetComponent<AICardToHand>().canAttack;
                k++;
            }

            for (int i = 0; i < 40; i++)
            {
                if (i >= howmanyCards2)
                {
                    canAttack[i] = false;
                }
            }
            k = 0;
        }

        if (0 == 0)
        {

            int l = 0;
            int howmanyCards3 = 0;
            foreach (Transform child in Zone.transform)
            {
                howmanyCards3++;

            }
            foreach (Transform child in Zone.transform)
            {
                cardsInZone[l] = child.GetComponent<AICardToHand>().thisCard[0];
                l++;
            }

            for (int i = 0; i < 40; i++)
            {
                if (i >= howmanyCards3)
                {
                    cardsInHand[i] = CardDataBase.cardList[0];
                }
            }
            l = 0;
        }

        if (attackPhase == true && endPhase == false)
        {
            for (int i = 0; i < 40; i++)
            {
                if (canAttack[i] == true)
                {
                    PlayerHp.staticHp -= cardsInZone[i].power;
                }
            }
            endPhase = true;
        }

        if (endPhase == true)
        {
            AiEndPhase = true;
        }




    }


    public void Shuffle()
    {
        for (int i = 0; i < deckSize; i++)
        {
            container[0] = deck[i];
            int randomIndex = Random.Range(i, deckSize);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = container[0];

        }

        //CardbackAi
        // Instantiate(CardBack, transform.position, transform.rotation);

        //StartCoroutine(ShuffleNow());

    }

    IEnumerator StartGame()
    {
        //CardToHandAi
        for (int i = 0; i <= 4; i++)
        {
            yield return new WaitForSeconds(1);
            Instantiate(CardToHand, transform.position, transform.rotation);
        }

    }

    IEnumerator ShuffleNow()
    {
        yield return new WaitForSeconds(1);
        Clones = GameObject.FindGameObjectsWithTag("CloneP");

        foreach (GameObject Clone in Clones)
        {
            Destroy(Clone);
        }
    }

    IEnumerator Draw(int x)
    {
        for (int i = 0; i < x; i++)
        {
            yield return new WaitForSeconds(1);
            Instantiate(CardToHand, transform.position, transform.rotation);
        }
    }

    //Aihand
    IEnumerator WaitFiveSeconds()
    {
        yield return new WaitForSeconds(5);

    }

    IEnumerator WaitForSummonPhase()
    {
        yield return new WaitForSeconds(5);
        summonPhase = true;
    }
}