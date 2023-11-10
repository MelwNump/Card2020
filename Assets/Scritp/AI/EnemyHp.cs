using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class EnemyHp : MonoBehaviour
{
    public static float maxHp;
    public static float staticHp;
    public float hp;
    public Image Health;
    public TextMeshProUGUI hpText;
    // Start is called before the first frame update
    void Start()
    {
        maxHp = 25000;
        staticHp = 25000;
    }

    // Update is called once per frame
    void Update()
    {
        hp = staticHp;
        Health.fillAmount = hp / maxHp;
        if (hp >= maxHp)
        {
            hp = maxHp;
        }
        hpText.text = "HP" + hp;
    }
}
