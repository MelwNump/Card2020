using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public TextMeshProUGUI victoryText;
    public GameObject textOject;

    public GameObject money;
    public bool gotMoney;
    // Start is called before the first frame update
    void Start()
    {
        textOject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerHp.staticHp <= 0)
        {
            textOject.SetActive(true);
            victoryText.text = "You Lose";
            StartCoroutine(Wait());
            
        }
        if (EnemyHp.staticHp <= 0)
        {
            textOject.SetActive(true);
            victoryText.text = "Victory";

            if(gotMoney == false)
            {
                money.GetComponent<Shop>().gold += 100;
                gotMoney = true;
                StartCoroutine(Wait());
            }
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Menu");
    }
}
