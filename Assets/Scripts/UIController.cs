using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject winScreenPrefab;
    public GameObject loseScreenPrefab;

    public Text levelNumberText;

    private static UIController uiController;

    private void Awake()
    {
        uiController = this;
    }


    public static void WinScreen()
    {
        uiController.winScreenPrefab.gameObject.SetActive(true);

    }

    public static void LoseScreen()
    {
        uiController.loseScreenPrefab.gameObject.SetActive(true);
  
    }

    public static void SetLevelNumber()
    {
     
        if (GameManager.isReflexLevelOpen)
        {
            uiController.levelNumberText.text = "LEVEL " + (GameManager.reflexLevelNumber + 1);
        }
        else if (GameManager.isMemoryLevelOpen)
        {
            uiController.levelNumberText.text = "LEVEL " + (GameManager.memoryLevelNumber + 1);
        }
       
    }

    public static void ResetLevelNumber()
    {

     
            uiController.levelNumberText.text = "";
  

    }
    // ...
}
