using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Library : MonoBehaviour
{
    [SerializeField]
    DataStorage DS;

    public List<BookClass> MyBookCollection;

    public enum BookTopic
    {
        ItemCraft,
        Alchem,
        Mapping,
    }

    public void StartSetup()
    {
        if (DS.IsSetup)
        {
            MyBookCollection = new List<BookClass>();
            Debug.Log(DS.LanguageGroups.Length);
            Debug.Log(MyBookCollection.Count);
            Debug.Log("Set1");
            MyBookCollection.Add(new BookClass(DS.LanguageGroups[0].GetComponent<LangGroupClass>(), BookTopic.Alchem, 15));
            Debug.Log("Set2");
            MyBookCollection.Add(new BookClass(DS.LanguageGroups[1].GetComponent<LangGroupClass>(), BookTopic.ItemCraft, 18));
            Debug.Log("Set3");
            MyBookCollection.Add(new BookClass(DS.LanguageGroups[2].GetComponent<LangGroupClass>(), BookTopic.ItemCraft, 25));
            Debug.Log("Set4");
            MyBookCollection.Add(new BookClass(DS.LanguageGroups[3].GetComponent<LangGroupClass>(), BookTopic.Alchem, 6));
            Debug.Log("Set5");
            MyBookCollection.Add(new BookClass(DS.LanguageGroups[4].GetComponent<LangGroupClass>(), BookTopic.Mapping, 8));
            Debug.Log("Set6");
        }


    }


    public void ArchiveBook(int ID,out int Coins)
    {
        Coins = 0;
        LangGroupClass LGC = MyBookCollection[ID].MyLanguage;
        for (int i = 0; i < MyBookCollection[ID].StatementLines.Length; i++) //Iterate Lines
        {
            for (int j = 0; j < MyBookCollection[ID].StatementLines[i].Words.Length; j++)//Iterate Words in Line
            {
                if(MyBookCollection[ID].StatementLines[i].Words[j].PlayerGivenProxie == LGC.GetWordByWordName(MyBookCollection[ID].StatementLines[i].Words[j].WordName).RealProxie)
                {
                    Coins++;
                }
                else
                {
                    //Coins--;
                }
            }
        }

        if(Coins < 0)
        {
            Coins = 0;
        }
        MyBookCollection.RemoveAt(ID);
        
    }


        
}
