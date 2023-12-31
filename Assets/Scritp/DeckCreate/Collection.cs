using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Collection : MonoBehaviour
{
    public GameObject CardOne;
    public GameObject CardTwo;
    public GameObject CardThree;
    public GameObject CardFour;
    public GameObject CardFive;

    public static int x;

    public int[] HowManyCards;

    public TextMeshProUGUI CardOneText;
    public TextMeshProUGUI CardTwoText;
    public TextMeshProUGUI CardThreeText;
    public TextMeshProUGUI CardFourText;

    //Open
    

    public bool openPack;

    public int[] o;

    public int oo;

    public int rand;

    public string card;

    public int cardInColltion;
    public int numberOfCardOnpage;


    // Start is called before the first frame update
    void Start()
    {
        x = 1;

        //Load
        for(int i=1;i<=8;i++)
        {
            HowManyCards[i] = PlayerPrefs.GetInt("x"+i,0);
        }

        //Open Pack
        if (openPack == true)
        {
            for(int i= 0;i<=4;i++)
            {
                getRandomCard();
            }
        }

        cardInColltion = 8;
        numberOfCardOnpage = 4;
    }

    // Update is called once per frame
    void Update()
    {
        //fixopen
        if (openPack == false)
        {
            CardOne.GetComponent<CardInCollecTion>().thisId = x;
            CardTwo.GetComponent<CardInCollecTion>().thisId = x + 1;
            CardThree.GetComponent<CardInCollecTion>().thisId = x + 2;
            CardFour.GetComponent<CardInCollecTion>().thisId = x + 3;

            CardOneText.text = "x" + HowManyCards[x];
            CardTwoText.text = "x" + HowManyCards[x + 1];
            CardThreeText.text = "x" + HowManyCards[x + 2];
            CardFourText.text = "x" + HowManyCards[x + 3];

            if (CardOneText.text == "x0")
            {
                CardOne.GetComponent<CardInCollecTion>().beGrey = true;
            }
            else
            {
                CardOne.GetComponent<CardInCollecTion>().beGrey = false;
            }
            if (CardTwoText.text == "x0")
            {
                CardTwo.GetComponent<CardInCollecTion>().beGrey = true;
            }
            else
            {
                CardTwo.GetComponent<CardInCollecTion>().beGrey = false;
            }
            if (CardThreeText.text == "x0")
            {
                CardThree.GetComponent<CardInCollecTion>().beGrey = true;
            }
            else
            {
                CardThree.GetComponent<CardInCollecTion>().beGrey = false;
            }
            if (CardFourText.text == "x0")
            {
                CardFour.GetComponent<CardInCollecTion>().beGrey = true;
            }
            else
            {
                CardFour.GetComponent<CardInCollecTion>().beGrey = false;
            }
        }
        //AutoSave
        for(int i=1; i<=8;i++)
        {
            PlayerPrefs.SetInt("x" + i, HowManyCards[i]);
        }
        //open
        if(openPack == true)
        {
            CardOne.GetComponent<CardInCollecTion>().thisId = o[0];
            CardTwo.GetComponent<CardInCollecTion>().thisId = o[1];
            CardThree.GetComponent<CardInCollecTion>().thisId = o[2];
            CardFour.GetComponent<CardInCollecTion>().thisId = o[3];
            CardFive.GetComponent<CardInCollecTion>().thisId = o[4];
        }

    }
    public void Card1Minus()
    {
        HowManyCards[x]--;
    }
    public void Card1Plus()
    {
        HowManyCards[x]++;
    }
    public void Card2Minus()
    {
        HowManyCards[x+1]--;
    }
    public void Card2Plus()
    {
        HowManyCards[x+1]++;
    }
    public void Card3Minus()
    {
        HowManyCards[x+2]--;
    }
    public void Card3Plus()
    {
        HowManyCards[x+2]++;
    }
    public void Card4Minus()
    {
        HowManyCards[x+3]--;
    }
    public void Card4Plus()
    {
        HowManyCards[x+3]++;
    }

    public void Left()
    {
      if(x != 1)
        {
            x -= numberOfCardOnpage;
        }
    }
    public void Right()
    {
        if (x != (cardInColltion - numberOfCardOnpage) + 1)
        {
            x += numberOfCardOnpage;
        }
    }

    public void getRandomCard()
    {
        rand = Random.Range(1, 9);
        PlayerPrefs.SetInt("x" + rand, (int)HowManyCards[rand]++);
        card = CardDataBase.cardList[rand].cardName;
        print("" + card);

        for(int i = 0; i < 8; i++)
        {
            PlayerPrefs.SetInt("x" + i, (int)HowManyCards[i]);
        }

        o[oo] = rand;
        oo++;

        print("card add");
    }
}
