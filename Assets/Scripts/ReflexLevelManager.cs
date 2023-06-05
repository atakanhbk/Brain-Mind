using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflexLevelManager : MonoBehaviour
{
    [SerializeField] List<GameObject> reflexLevelList;
    [SerializeField] GameManager gameManager;
   

    public void CreateReflexLevel()
    {

        var spawnedLevel = Instantiate(reflexLevelList[gameManager.levelScriptableObject.reflexLevelNumber].gameObject, Vector3.zero, Quaternion.identity);
        spawnedLevel.gameObject.transform.parent = transform.parent;
        spawnedLevel.transform.localScale = Vector3.one;
        spawnedLevel.GetComponent<RectTransform>().offsetMin = Vector2.zero;
        spawnedLevel.GetComponent<RectTransform>().offsetMax = Vector2.zero;
        GameManager.isReflexLevelOpen = true;
    
    }

    
}
