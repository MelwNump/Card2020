using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardToHand : MonoBehaviour
{
    public GameObject Hand;
    public GameObject It;

    public int x;
    // Start is called before the first frame update
    void Start()
    {
        x = 0;
       
    }

    // Update is called once per frame
    void Update()
    {
        if(x == 0)
        {
            Hand = GameObject.Find("Hand");
            It.transform.SetParent(Hand.transform);
            It.transform.localScale = Vector3.one;
            It.transform.position = new Vector3(transform.position.x, transform.position.y, -48);
            It.transform.eulerAngles = new Vector3(25, 0, 0);
            x = 1;
        }
       
    }
}
