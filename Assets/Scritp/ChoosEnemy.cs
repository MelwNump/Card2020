using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoosEnemy : MonoBehaviour
{
    public string play;
   
    public void ChooseEnemy1()
    {
        AI.whichEnemy = 1;

        SceneManager.LoadScene(play);
    }
    public void ChooseEnemy2()
    {
        AI.whichEnemy = 2;

        SceneManager.LoadScene(play);
    }


}
