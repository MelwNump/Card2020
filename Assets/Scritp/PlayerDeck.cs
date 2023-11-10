using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerDeck : MonoBehaviour
{
    public List<Card> deck = new List<Card>();
    public List<Card> container = new List<Card>();
    public static List<Card> staticDeck = new List<Card>();

    public int x;

    public static int deckSize;

    public GameObject cardInDeck1;
    public GameObject cardInDeck2;
    public GameObject cardInDeck3;
    public GameObject cardInDeck4;

    public GameObject CardToHand;

    public GameObject CardBack;
    public GameObject Deck;

    public GameObject[] Clones;

    public GameObject Hand;

    //Deck Out
    public  TextMeshProUGUI LoseText;
    public  GameObject LoseTextGameObject;
    //Gg
    public GameObject concedeWindo;
    public string menu = "Menu";


    private void Awake()
    {
        Shuffle();
    }


    // Start is called before the first frame update
    void Start()
    {

        
        deckSize = 40;
        x = 0;
      
        //for (int i = 0; i < deckSize; i++)
        //{
        //    x = Random.Range(1, 8);
        //    deck[i] = CardDataBase.cardList[x];
        //}

        StartCoroutine(StartGame());
        //newDeck
        for(int i=1;i<=8;i++)
        {
            if(PlayerPrefs.GetInt("deck" + i, 0)>0)
            {
                for(int j=1;j<=PlayerPrefs.GetInt("deck"+i,0);j++)
                {
                    deck[x] = CardDataBase.cardList[i];
                    x++;
                }
            }
        }
        Shuffle();

    }

    // Update is called once per frame
    void Update()
    {
        //Deck Out
        if (deckSize <= 0)
        {
            LoseTextGameObject.SetActive(true);
            LoseText.text = "You Lose";
        }

        //Deck Side
        staticDeck = deck;

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

        if (ThisCard.drawX > 0)
        {
            StartCoroutine(Draw(ThisCard.drawX));
            ThisCard.drawX = 0;

        }

        if (TurnSystem.startTurn == true)
        {

            //Limit
            if(CardsTnHand.howMany<10)
            {
                StartCoroutine(Draw(1));
            }
            else
            {

            }
           
            TurnSystem.startTurn = false;
        }
    }
    IEnumerator StartGame()
    {
        for (int i = 0; i <= 4; i++)
        {
            yield return new WaitForSeconds(1);
            Instantiate(CardToHand, transform.position, transform.rotation);

        }
    }
    public void Shuffle()
    {
        for (int i = 0; i < deckSize; i++)
        {
            container[0] = deck[i];
           int randomIndex = Random.Range(i, deckSize);
            deck[i]=deck[randomIndex];
            deck[randomIndex] = container[0];
        }
        Instantiate(CardBack, transform.position, transform.rotation);
        StartCoroutine(Example());
    }
    IEnumerator Example()
    {
        yield return new WaitForSeconds(1.5f);
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
    public void OpenWindow()
    {
        concedeWindo.SetActive(true);
    }
    public void CloseWindow()
    {
        concedeWindo.SetActive(false);
    }

    public void ConcedeDefeat()
    {
        StartCoroutine(EndGames());
    }
    IEnumerator EndGames()
    {
       LoseTextGameObject.SetActive(true);
       LoseText.text = "You Lose";
       concedeWindo.SetActive(false);

        yield return new WaitForSeconds(2.5f);

        SceneManager.LoadScene(menu);

    }

}
