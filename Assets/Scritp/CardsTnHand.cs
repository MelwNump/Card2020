using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsTnHand : MonoBehaviour
{
    public GameObject Hand;
    public static int howMany;
    public  int howManyCard;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int x = 0;
        foreach(Transform child in Hand.transform)
        {
            x++;
        }
        if(x != howMany)
        {
            howMany = x;
        }
        howManyCard = howMany;
    }
}
