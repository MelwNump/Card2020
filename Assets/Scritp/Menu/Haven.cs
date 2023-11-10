using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Haven : MonoBehaviour
{
    public GameObject backGround;
    public float x;
    public GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        x = 250;
        backGround = GameObject.Find("BackGround");
        this.transform.SetParent(backGround.transform);
        this.transform.localScale = new Vector3(1.5f,1.5f,1.5f);
        StartCoroutine(Die());

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name != "GameCard")
        {
            this.transform.position = new Vector3(transform.position.x, x += 500 * Time.deltaTime, transform.position.z);
        }

    }
    IEnumerator Die()
    {
        yield return new WaitForSeconds(5f);
        Destroy(obj);
    }
}
