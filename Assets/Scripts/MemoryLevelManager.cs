using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryLevelManager : MonoBehaviour
{
    [SerializeField] List<GameObject> memoryLevelList;
    [SerializeField] GameManager gameManager;
    public void CreateMemoryLevel()
    {
        var spawnedLevel = Instantiate(memoryLevelList[gameManager.levelScriptableObject.memoryLevelNumber].gameObject, Vector3.zero, Quaternion.identity);
        spawnedLevel.gameObject.transform.parent = transform.parent;
        spawnedLevel.transform.localScale = Vector3.one;
        spawnedLevel.GetComponent<RectTransform>().offsetMin = Vector2.zero;
        spawnedLevel.GetComponent<RectTransform>().offsetMax = Vector2.zero;
        GameManager.isMemoryLevelOpen = true;
        GameManager.isReflexLevelOpen = false;
    }
}
