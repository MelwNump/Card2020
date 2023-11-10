using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WindowInDeck : MonoBehaviour
{
    public GameObject Panel;
    public TextMeshProUGUI nameText;

    public int id;

    public int quanityOf;

    public GameObject Creator;
    // Start is called before the first frame update
    void Start()
    {
        Panel = GameObject.Find("Drop");
        Creator = GameObject.Find("UI");
        transform.SetParent(Panel.transform);
        transform.localScale = new Vector3(1,1,1);

        id = DeckCreator.lastAdded;
    }

    // Update is called once per frame
    void Update()
    {
        quanityOf = Creator.GetComponent<DeckCreator>().quanity[id];
        nameText.text = CardDataBase.cardList[id].cardName + " x " + quanityOf;
    }
}
