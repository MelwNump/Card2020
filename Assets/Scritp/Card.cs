using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Card
{
    public int id;
    public string cardName;
    public int cost;
    public int power;

    public int drawXcards;
    public int addXmaxMana;

    public string cardDescription;
    public Sprite thisImage;
    public string color;
    public int returnXcard;
    public int healXpower;

    //spell
    public bool spell;
    public int damageDealtBySpell;


    

    public Card(int Id, string CardName, int Cost, int Power, string CardDescription, Sprite ThisImage, string Color, int DrawXcards, int AddXmaxMana, int ReturnXcard,int HealXpower,bool Spell,int DamageDealyBySpell)
    {
        id = Id;
        cost = Cost;
        power = Power;
        cardName = CardName;
        cardDescription = CardDescription;

        thisImage = ThisImage;
        color = Color;

        drawXcards = DrawXcards;
        addXmaxMana = AddXmaxMana;

        returnXcard = ReturnXcard;

        healXpower = HealXpower;

        spell = Spell;
        damageDealtBySpell = DamageDealyBySpell;


        


       


    }
}