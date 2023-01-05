using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SigilDisplayData : MonoBehaviour
{
    OutputInput OI;
    Image Img;
    Color BaseColor;
    [SerializeField]
    public string MyWord;
    EventClass EC;
    private void Start()
    {
        Img = gameObject.GetComponent<Image>();
        BaseColor = Img.color;
        OI = OutputInput.OutputInputClass;
        
         EC = GameObject.Find("SystemManager").GetComponent<EventClass>();
        //Debug.Log(EC);
        EC.CallSigilsEvent.AddListener(SetActive);
        if(gameObject.GetComponent<BoxCollider2D>() == null)
        {
            gameObject.AddComponent<BoxCollider2D>();
            BoxCollider2D Box = gameObject.GetComponent<BoxCollider2D>();
            Box.size = new Vector2(20, 20);
        }

    }
    public void SetActive(string Word)
    {
        if(gameObject.activeInHierarchy == true)
        { 
        if(Word == MyWord)
        {
            ChangeColor(true);
        }
        else
        {
            ChangeColor(false);
        }
        }
    }
    private void ChangeColor(bool Change)
    {
        
        if (Change)
        {
            Img.color = Color.red;
        }
        else
        {
            Img.color = BaseColor;
        }
    }
    private void OnMouseUpAsButton()
    {
        Debug.Log("SigilEvent");
        OI.DisplayWordProxy(MyWord);
        EC.TriggerEvent(MyWord);
    }
}
