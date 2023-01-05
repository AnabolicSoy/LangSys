using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventClass : MonoBehaviour
{


    public EventSerialization CallSigilsEvent;
    private void Start()
    {
        CallSigilsEvent = new EventSerialization();

    }
    public void TriggerEvent(string Word)
    {
        Debug.Log("EVENT");
        Debug.Log(Word);
        CallSigilsEvent.Invoke(Word);
    }

}
