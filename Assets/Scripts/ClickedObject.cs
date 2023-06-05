using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickedObject : MonoBehaviour, IPointerClickHandler
{
    ReflexMode reflexMode;
    private void Start()
    {
        reflexMode = gameObject.transform.parent.GetComponent<ReflexMode>();
    }
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        Destroy(gameObject);
        reflexMode.CreateClickedObjectOnTheScreen();
        reflexMode.clickedCounter++;
    }
}
