using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class ProxyManager : MonoBehaviour
{
    [SerializeField]
    OutputInput OI;
    [SerializeField]
    DataStorage DS;
    [SerializeField]
    GameObject ProxyPanel;
    [SerializeField]
    ProxyClass[] ProxyDataObjects;

    Sprite SelectedImage;
    ProxyClass SelectedProxie;
    int MaxNumberOfImages;

    int ImageBatchMultipyer;
    int ImageBatchConstant;

    int ProxyBatchMultiplyer;
    int ProxyBatchConstant;

    int[] BTN_TO_SP_ID;
    [SerializeField]
    Text[] BTN_Text;
    [SerializeField]
    Image[] BTN_Img;

    WordClass SelectedWord;
    bool IsSetToActive;
    void Start()
    {
        ImageBatchMultipyer = 0;
        ImageBatchConstant = 3;
        ProxyBatchMultiplyer = 0;
        ProxyBatchConstant = 6;
       
    }
    public void SetToActive()
    { IsSetToActive = true; }
    public void SetWordClass()
    {
        Debug.Log("SetWordClass()");
        SelectedWord = OI.SelectedWord;
        if (OI.SelectedWord.WordName != null)
            if (IsSetToActive)
            { OpenSystem(); }
    }
    public void RemoveWordClass()
    {
        Debug.Log("RemoveWordClass()");
        SelectedWord = null;
    }

    private void OpenSystem()
    {
        Debug.Log("OpenSystem()"); 
        if (SelectedWord.WordName != null)
        {
             ProxyPanel.SetActive(true);
            Set_BTN_TEXT();
            Set_BTN_IMG();
            
        }
        
    }
    public void CloseSystem()
    {
        Debug.Log("CloseSystem()");
        ProxyPanel.SetActive(false);
        IsSetToActive = false;
    }


    public void UP_ProxySelection()
    {
        int Prev = ProxyBatchMultiplyer;
        Debug.Log("UP_ProxySelection()");
        ProxyBatchMultiplyer++;
        if( (ProxyBatchMultiplyer * ProxyBatchConstant) > ProxyDataObjects.Length)
        {
            ProxyBatchMultiplyer = Prev;
        }

        Set_BTN_TEXT();
    }
    public void DOWN_ProxySelection()
    {
        Debug.Log("DOWN_ProxySelection()");
        ProxyBatchMultiplyer--;
        if(ProxyBatchMultiplyer < 0)
        {
            ProxyBatchMultiplyer = 0;
        }
        Set_BTN_TEXT();
    }


    public void UP_ProxyImage()
    {
        Debug.Log("UP_ProxyImage()");
        int PrevValue = ImageBatchMultipyer;
        ImageBatchMultipyer++;
        if((ImageBatchMultipyer * ImageBatchConstant) + ImageBatchConstant - 1> SelectedProxie.Images.Length)
        {
            ImageBatchMultipyer = PrevValue;
        }
        Set_BTN_IMG();
    }
    public void DOWN_ProxyImage()
    {
        Debug.Log("DOWN_ProxyImage()");
        ImageBatchMultipyer--;
        if (ImageBatchMultipyer < 0)
        {
            ImageBatchMultipyer = 0;
        }
        Set_BTN_IMG();
    }


    public void SELECT_ProxySelection(int BTN_ID)
    {
        Debug.Log("SELECT_ProxySelection()");
        if(-1 + BTN_ID + (ProxyBatchMultiplyer * ProxyBatchConstant) < ProxyDataObjects.Length)
        {
            SelectedProxie = ProxyDataObjects[-1 + BTN_ID + (ProxyBatchMultiplyer * ProxyBatchConstant)].GetComponent<ProxyClass>();
            Debug.Log(SelectedProxie);
            MaxNumberOfImages = ProxyDataObjects[-1 + BTN_ID + (ProxyBatchMultiplyer * ProxyBatchConstant)].Images.Length;
            RegisterSelection();
            Set_BTN_IMG();
        }

    }
    public void SELECT_ProxyImage(int IMAGE_ID)
    {
        Debug.Log("SELECT_ProxyImage()");
        Debug.Log("MaxNumberOfImages" + MaxNumberOfImages);
        Debug.Log(-1 + IMAGE_ID + (ImageBatchMultipyer * ImageBatchConstant));
        if (MaxNumberOfImages >= -1 + IMAGE_ID + (ImageBatchMultipyer * ImageBatchConstant))
        {

        SelectedImage = SelectedProxie.Images[-1 + IMAGE_ID + (ImageBatchMultipyer * ImageBatchConstant)];
        Debug.Log(SelectedProxie.Images[-1 + IMAGE_ID + (ImageBatchMultipyer * ImageBatchConstant)]);

        }
        RegisterSelection();
    }

    

    private void Set_BTN_TEXT()
    {
        Debug.Log("Set_BTN_TEXT()");
        for (int i = 0; i < ProxyBatchConstant; i++)
        {
            int Value =   i + (ProxyBatchMultiplyer * ProxyBatchConstant);
            if (Value >= 0 && Value < ProxyDataObjects.Length)
            BTN_Text[i].text = ProxyDataObjects[Value].MyProxy.ToString();
        }
    }
    private void Set_BTN_IMG()
    {
        Debug.Log("Set_BTN_IMG()");
        Debug.Log(SelectedProxie);
        if (SelectedProxie == null)
        {
            Debug.Log(SelectedProxie);
            for (int i = 0; i < ImageBatchConstant; i++)
            {
                BTN_Img[i].sprite = null;
                BTN_Img[i].color = Color.green;
            }
        }
        else
        {
            Debug.Log(SelectedProxie);
            for (int i = 0; i < ImageBatchConstant; i++)
            {
                Debug.Log( i + (ImageBatchMultipyer * ImageBatchConstant));
                Debug.Log(SelectedProxie.Images.Length);
                if (SelectedProxie.Images.Length >  i + (ImageBatchMultipyer * ImageBatchConstant))
                {
                    Debug.Log(SelectedProxie.Images[i + (ImageBatchMultipyer * ImageBatchConstant)]);
                    BTN_Img[i].sprite = SelectedProxie.Images[ i + (ImageBatchMultipyer * ImageBatchConstant)];
                    BTN_Img[i].color = Color.white;
                }
                else
                {
                    BTN_Img[i].sprite = null;
                    BTN_Img[i].color = Color.green;
                }
            }
        }
    }
    private void RegisterSelection()
    {
        Debug.Log("RegisterSelection()");
        if (SelectedImage != null)
        {
            Debug.Log("SelectedImage != null");
            SelectedWord.ProxyImg = SelectedImage;
        }
        SelectedWord.PlayerGivenProxie = SelectedProxie.MyProxy;
    }

}
