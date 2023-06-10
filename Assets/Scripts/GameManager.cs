using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    [Header("Game Finished")]
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject loseScreen;

    [Header("Level Controller")]
    [SerializeField] private ReflexLevelManager reflexLevelController;
    [SerializeField] private MemoryLevelManager memoryLevelController;
    [SerializeField] public LevelScriptableObject levelScriptableObject;



    public static int reflexLevelNumber;
    public static int memoryLevelNumber;

    public static bool isReflexLevelOpen;
    public static bool isMemoryLevelOpen;
 
    private void Start()
    {
        reflexLevelNumber = levelScriptableObject.reflexLevelNumber;
        memoryLevelNumber = levelScriptableObject.memoryLevelNumber;
    }
  

    public void ClickedTryAgain()
    {
        if (isReflexLevelOpen)
        {
            CleanEverythingBeforeLevelSpawn();
            reflexLevelController.CreateReflexLevel();

        }

        else if (isMemoryLevelOpen)
        {
            Debug.Log("Worked");
            CleanEverythingBeforeLevelSpawn();
            memoryLevelController.CreateMemoryLevel();
        }
    }


    public void ClickedNextLevel()
    {
        if (isReflexLevelOpen)
        {
            CleanEverythingBeforeLevelSpawn();
            IncreaseLevelNumber("reflexLevel");
            reflexLevelController.CreateReflexLevel();
        }

        else if (isMemoryLevelOpen)
        {
            CleanEverythingBeforeLevelSpawn();
            IncreaseLevelNumber("memoryLevel");
            memoryLevelController.CreateMemoryLevel();
        }
    }

    void IncreaseLevelNumber(string levelType)
    {

        switch (levelType)
        {
            case "reflexLevel":
                levelScriptableObject.reflexLevelNumber++;
                reflexLevelNumber = levelScriptableObject.reflexLevelNumber;
                break;
            case "memoryLevel":
                levelScriptableObject.memoryLevelNumber++;
                memoryLevelNumber = levelScriptableObject.memoryLevelNumber;
                break;
        }

     
    }

    void CloseWinAndLoseScreen()
    {
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
    }

    void CleanEverythingBeforeLevelSpawn()
    {
        CloseWinAndLoseScreen();
    }

   

  

}