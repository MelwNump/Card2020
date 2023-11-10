
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDataBase : MonoBehaviour
{
    public static List<Card> cardList = new List<Card>();
    void Awake()
    {
        cardList.Add(new Card(0, "None", 0, 0, "None ", Resources.Load<Sprite>("0"), "None", 0, 0, 0, 0, false, 0));
        cardList.Add(new Card(1, "NuNU", 2, 1000, "DrawCards 2", Resources.Load<Sprite>("1"), "Red", 2, 0, 0,0, false, 0));
        cardList.Add(new Card(2, "MaMa", 3, 2000, "Mana 3", Resources.Load<Sprite>("2"), "Blue", 0, 3, 0,0, false, 0));
        cardList.Add(new Card(3, "Rara", 4, 2000, "Heal 1000", Resources.Load<Sprite>("3"), "Yellow", 0, 0, 0,1000, false, 0));
        cardList.Add(new Card(4, "GG", 5, 1000, "DrawCards 1,Return 1 Card", Resources.Load<Sprite>("4"), "Purple", 1, 0, 1,0, false, 0));
        cardList.Add(new Card(5, "GGO", 6, 1000, "Return 1 Card and Heal 1000", Resources.Load<Sprite>("5"), "Purple", 0, 0, 1,1000, false, 0));
        
        cardList.Add(new Card(8, "Hoster", 1, 1500, "Monster", Resources.Load<Sprite>("8"), "Red", 0, 0, 0, 0, false, 0));
        //cardList.Add(new Card(8, "Oowe", 2, 2000, "Monster", Resources.Load<Sprite>("9"), "Red", 0, 0, 0, 0, false, 0));


        //spell
        cardList.Add(new Card(6, "FireBall", 7, 0, "Deal 2500", Resources.Load<Sprite>("6"), "Purple", 1, 0, 0, 0, true, 2500));
        cardList.Add(new Card(7, "Heal", 8, 0, "Heal", Resources.Load<Sprite>("7"), "Purple", 1, 0, 0, 2500, true, 0));


    }
}