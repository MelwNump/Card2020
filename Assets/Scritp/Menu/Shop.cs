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

    // Start is called before the first frame update
    void Start()
    {
        gold = 1000;

        gold = PlayerPrefs.GetInt("gold", 1000);
    }

    // Update is called once per frame
    void Update()
    {
        GoldText.text = "Money" +"  "+ gold+"$";
    }
    
    public void BuyPack()
    {
        gold -= 100;
        SceneManager.LoadScene("OpenPack");

        PlayerPrefs.SetInt("gold", gold);

        SceneManager.LoadScene("OpenPack");
    }
}
