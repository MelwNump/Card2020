using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour
{
    public TextMeshProUGUI GoldText;
    public int gold;
    public bool PlayDuel;

    // Start is called before the first frame update
    void Start()
    {
        gold = 1000;

        gold = PlayerPrefs.GetInt("gold", 1000);
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayDuel == false)
        {
            GoldText.text = "Money" + "  " + gold + "$";
        }
        else
        {
            PlayerPrefs.SetInt("gold", gold);
        }
        //GoldText.text = "Money" +"  "+ gold+"$";
    }
    
    public void BuyPack()
    {
        if(gold >= 100)
        {
            gold -= 100;

            PlayerPrefs.SetInt("gold", gold);
            SceneManager.LoadScene("OpenPack");

        }
        gold -= 100;
     
    }
}
