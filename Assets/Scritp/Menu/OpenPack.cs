using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenPack : MonoBehaviour
{
    public float updeated;
    public float max;

    public Image Bar;

    public GameObject prefeb;
    public GameObject pack;

    public GameObject C1;
    public GameObject C2;
    public GameObject C3;
    public GameObject C4;
    public GameObject C5;
    // Start is called before the first frame update
    void Start()
    {
        max = 100;
        updeated = 0;

        StartCoroutine(Wait());
    }

    // Update is called once per frame
    void Update()
    {
        Bar.fillAmount = updeated/max;
        if(updeated < 0)
        {
            updeated = 0;
        }

        updeated += 50*Time.deltaTime;
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
        Instantiate(prefeb,pack.transform.position,Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Instantiate(prefeb, pack.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Instantiate(prefeb, pack.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Instantiate(prefeb, pack.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Instantiate(prefeb, pack.transform.position, Quaternion.identity);

        yield return new WaitForSeconds(1.5f);

        Destroy(pack);

        C1.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        C2.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        C3.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        C4.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        C5.SetActive(true);
        yield return new WaitForSeconds(0.5f);

    }
}





