using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReflexMode : MonoBehaviour
{
    [Header("GameObjects")]
    [SerializeField] GameObject clickedObject;
    [SerializeField] GameObject currentClickedGameObject;

    [Header("UI")]
    [SerializeField] Text clickCounterText;
    [SerializeField] Text countDownText;
    [SerializeField] Text levelNumber;

    [Header("Values")]

    [SerializeField] float totalTimer;
    [SerializeField] float totalSpawnClickedObject;
    [SerializeField] float divideTotalTimerForKillTimer;
    public float clickedCounter = 0;
    float killClickedObjectTimer;
    float firstValueKillClickedObjectTimer;
    float currentClickedObject;


    [Header("Bools")]
    bool gameOver = false;
    bool win = false;
    bool lose = false;






    void Start()
    {
        CreateClickedObjectOnTheScreen();
        killClickedObjectTimer = totalTimer / divideTotalTimerForKillTimer;
        firstValueKillClickedObjectTimer = killClickedObjectTimer;
    }



    private void Update()
    {
        EditText();
        CountdownFunction();

    }
    public void CreateClickedObjectOnTheScreen()
    {
        if (currentClickedObject < totalSpawnClickedObject)
        {
            killClickedObjectTimer = firstValueKillClickedObjectTimer;
            var spawnedClickedObject = Instantiate(clickedObject, Vector3.zero, Quaternion.identity);
            currentClickedGameObject = spawnedClickedObject;
            spawnedClickedObject.transform.parent = gameObject.transform;

            float randomPositionX = Random.Range(-200, 200);
            float randomPositionY = Random.Range(-500, 500);
            spawnedClickedObject.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(randomPositionX, randomPositionY);
            currentClickedObject++;
        }
        else
        {
            gameOver = true;
            win = true;
            GameFinished();
        }

    }

    void EditText()
    {
        clickCounterText.text = "Clicked Counter = " + clickedCounter + " / " + totalSpawnClickedObject;
        countDownText.text = "Countdown = " + totalTimer.ToString("N0");
        UIController.SetLevelNumber();
    }

    void CountdownFunction()
    {

        if (!gameOver)
        {
            totalTimer -= Time.deltaTime;
            killClickedObjectTimer -= Time.deltaTime;

            if (killClickedObjectTimer <= 0)
            {
                Destroy(currentClickedGameObject);
                CreateClickedObjectOnTheScreen();
                currentClickedObject--;
                killClickedObjectTimer = firstValueKillClickedObjectTimer;
            }
        }


        if (totalTimer <= 0)
        {

            lose = true;
            GameFinished();
        }
    }

    void GameFinished()
    {
        totalTimer = 0;
        gameOver = true;
        if (win)
        {

            UIController.WinScreen();
        }
        else if (lose)
        {
            UIController.LoseScreen();
        }
        UIController.ResetLevelNumber();
        KillCurrentLevel();
    }

    void KillCurrentLevel()
    {
        Destroy(gameObject.transform.parent.gameObject);
    }


}
