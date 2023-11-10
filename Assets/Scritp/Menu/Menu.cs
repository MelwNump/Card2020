using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    public string play;
    public string deck;
    public string collection;
    public string setting;

    public string menu;
    public string shop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadPlay()
    {
        SceneManager.LoadScene(play);
    }
    public void LoadDeck()
    {
        SceneManager.LoadScene(deck);
    }
    public void LoadCollection()
    {
        SceneManager.LoadScene(collection);
    }
    public void LoadShop()
    {
        SceneManager.LoadScene(shop);
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(menu);
    }
   
}
