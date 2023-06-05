using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReflexMode : MonoBehaviour
{
    [SerializeField] GameObject clickedObject;
    [SerializeField] Text clickCounterText;
    [SerializeField] Text countDownText;

    public float clickedCounter = 0;
    float currentClickedObject;

    [SerializeField] float totalTimer;
    [SerializeField] float totalSpawnClickedObject;


    bool gameOver = false;
    bool win = false;
    bool lose = false;
    void Start()
    {
        CreateClickedObjectOnTheScreen();
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

        var spawnedClickedObject = Instantiate(clickedObject, Vector3.zero, Quaternion.identity);
        spawnedClickedObject.transform.parent = gameObject.transform;

        float randomPositionX = Random.Range(-200, 200);
        float randomPositionY = Random.Range(-700, 700);
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
    }

    void CountdownFunction()
    {
       
        if (!gameOver)
        {
            totalTimer -= Time.deltaTime;
        }
       

        if (totalTimer <= 0)
        {
            totalTimer = 0;
            gameOver = true;
            lose = true;
            GameFinished();
        }
    }

    void GameFinished()
    {
  
        if (win)
        {
       
            UIController.WinScreen();
        }
        else if (lose)
        {
            UIController.LoseScreen();
        }

        KillCurrentLevel();
    }

    void KillCurrentLevel()
    {
        Destroy(gameObject);
    }

  
}
