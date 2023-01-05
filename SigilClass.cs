 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SigilClass : MonoBehaviour
{
    public Sprite SigilImg;

    public int ID;

    public SigilClass(Sprite Img, int id)
    {
        SigilImg = Img;
        ID = id;
    }
}
