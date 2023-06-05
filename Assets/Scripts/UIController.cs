using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject winScreenPrefab;
    public GameObject loseScreenPrefab;

    private static UIController uiController;

    private void Awake()
    {
        uiController = this;
    }


    public static void WinScreen()
    {
        uiController.winScreenPrefab.gameObject.SetActive(true);
        Debug.Log("Showed Win Screen");
    }

    public static void LoseScreen()
    {
        uiController.loseScreenPrefab.gameObject.SetActive(true);
        Debug.Log("Showed Lose Screen");
    }

    public void ClickedTryAgain()
    {
     
    }

    // ...
}
