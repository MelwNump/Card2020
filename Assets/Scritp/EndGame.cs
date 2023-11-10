using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndGame : MonoBehaviour
{
    public TextMeshProUGUI victoryText;
    public GameObject textOject;
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
        }
        if (EnemyHp.staticHp <= 0)
        {
            textOject.SetActive(true);
            victoryText.text = "Victory";
        }
    }
}
