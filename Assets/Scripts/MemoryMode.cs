using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryMode : MonoBehaviour
{
    [SerializeField] Button optionA;
    [SerializeField] Button optionB;
    [SerializeField] Text questionText;

    [SerializeField] string Question;
    private void Start()
    {
       optionA.onClick.AddListener(() => CheckThisButtonIsCorrectAnswer(optionA));
       optionB.onClick.AddListener(() => CheckThisButtonIsCorrectAnswer(optionB));

    
    }
    public void CheckThisButtonIsCorrectAnswer(Button pressedButton)
    {
        if (pressedButton.gameObject.tag == "Correct")
        {
            UIController.WinScreen();
        }
        else
        {
            UIController.LoseScreen();
            KillCurrentLevel();
        }
    }

    void KillCurrentLevel()
    {
        Destroy(gameObject.transform.parent.gameObject);
    }

    public void SetQuestionText()
    {
        questionText.text = "" + Question;
    }
}
