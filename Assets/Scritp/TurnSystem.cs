using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class TurnSystem : MonoBehaviour
{
    public static bool isYourTurn;
    public int yourTurn;
    public int yourOponentTurn;
    public TextMeshProUGUI turnText;

    public static int maxMana;
    public static int currentMana;
    public TextMeshProUGUI manaText;

    public static bool startTurn;
    
    public int random;

    public bool turnEnd;
    public TextMeshProUGUI timerText;
    public int seconds;
    public bool timeStart;
    
    //EnemyMana

    public static int maxEnemyMana;
    public static int currentEnemyMana;
    public TextMeshProUGUI enemyManaText;

   


    // Start is called before the first frame update
    void Start()
    {

        StartGame();

        seconds = 60;
        timeStart = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isYourTurn == true)
        {
            turnText.text = "Your Turn";
        }
        else
        {
            turnText.text = "Oponent Turn";
        }
        //ManaPlayer
        manaText.text = currentMana + "/" + maxMana;
        //timecount
        if (isYourTurn == true && seconds > 0 && timeStart == true)
        {
            StartCoroutine(Timer());
            timeStart = false;
        }
        if (seconds == 0 && isYourTurn == true)
        {
            EndYourTurn();
            timeStart = true;
            seconds = 60;
        }
        timerText.text = seconds + "";
        //EnemyTime
        if(isYourTurn == false&& seconds > 0&&timeStart==true)
        {
            StartCoroutine(EnemyTimer());
            timeStart = false;
        }
        if(seconds == 0 && isYourTurn == false)
        {
            EndYourOponentTurn();
            timeStart=true;
            seconds = 60;
        }
        //EnemyMana
        enemyManaText.text = currentEnemyMana + "/" + maxEnemyMana;

        //attack
        if(AI.AiEndPhase == true)
        {
            EndYourOponentTurn();
            AI.AiEndPhase = false;
        }
    }

    public void EndYourTurn()
    {
        isYourTurn = false;
        yourOponentTurn += 1;

        //enemy
        maxEnemyMana += 1;
        currentEnemyMana += 1;
        currentEnemyMana = maxEnemyMana;

        //Ai Draw
        AI.draw = false;

        timeStart = true;
        seconds = 60;

    }
    public void EndYourOponentTurn()
    {
        isYourTurn = true;
        yourTurn += 1;

        maxMana += 1;
        currentMana = maxMana;

        startTurn = true;

        timeStart = true;
        seconds = 60;


    }
    public void StartGame()
    {
        random = Random.Range(0, 2);

        if (random == 0)
        {
            isYourTurn = true;
            yourTurn = 1;
            yourOponentTurn = 0;

            maxMana = 1;
            currentMana = 1;
            maxEnemyMana = 0;
            currentEnemyMana = 0;
            startTurn = false;

        }
        if (random == 1)
        {
            isYourTurn = false;
            yourTurn = 0;
            yourOponentTurn = 1;

            maxMana = 0;
            currentMana = 0;

            maxEnemyMana = 1;
            currentEnemyMana = 1;
        }
    }


    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1);
        if (isYourTurn == true && seconds > 0)
        {
           // yield return new WaitForSeconds(1);
            seconds--;
            StartCoroutine(Timer()); 
        }
    }
    IEnumerator EnemyTimer()
    {
        if (isYourTurn == false && seconds > 0)
        {
            yield return new WaitForSeconds(1);
            seconds--;
            StartCoroutine(EnemyTimer());
        }
    }
   
}