using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LangGroupClass : MonoBehaviour
{
    public WordClass[] Word_All;
    public WordClass[] Word_Mod;
    public WordClass[] Word_Obj;
    public WordClass[] Word_Loc;
    public WordClass[] Word_Ent;
    public ConceptClass[] ConceptsArray;

    public SigilClass[] Symbols;

    public WordClass GetRandomObject(DataStorage.SubConceptTypes Type)
    {
        List<WordClass> WordList = new List<WordClass>();
        for (int i = 0; i < Word_Obj.Length; i++)
        {
            if(Word_Obj[i].GetMySubConceptType() == Type)
            {
                WordList.Add(Word_Obj[i]);
            }
        }
        
        return WordList[Random.Range(0, WordList.Count)];
        
    }
    public WordClass GetRandomEntity(DataStorage.SubConceptTypes Type)
    {
        List<WordClass> WordList = new List<WordClass>();
        for (int i = 0; i < Word_Ent.Length; i++)
        {
            if (Word_Ent[i].GetMySubConceptType() == Type)
            {
                WordList.Add(Word_Ent[i]);
            }
        }
        return WordList[Random.Range(0, WordList.Count)];
    }
    public WordClass GetRandomLocation(DataStorage.SubConceptTypes Type)
    {
        List<WordClass> WordList = new List<WordClass>();
        for (int i = 0; i < Word_Loc.Length; i++)
        {
            if (Word_Loc[i].GetMySubConceptType() == Type)
            {
                WordList.Add(Word_Loc[i]);
            }
        }
        return WordList[Random.Range(0, WordList.Count)];
    }

    public WordClass GetWordByWordName(string Word)
    {
        string[] SplitWord = Word.Split(':');

        WordClass wordClass = null ;

        switch (SplitWord[0])
        {
            case "Obj_Element":
                wordClass = Word_Obj[int.Parse(SplitWord[1])];
                break;
            case "Obj_Base":
                wordClass = Word_Obj[int.Parse(SplitWord[1])];
                break;
            case "Obj_Item":
                wordClass = Word_Obj[int.Parse(SplitWord[1])];
                break;
            case "Obj_Compound":
                wordClass = Word_Obj[int.Parse(SplitWord[1])];
                break;
            case "Obj_Strut":
                wordClass = Word_Obj[int.Parse(SplitWord[1])];
                break;
            case "Ent_Minor":
                wordClass = Word_Ent[int.Parse(SplitWord[1])];
                break;
            case "Ent_Basal":
                wordClass = Word_Ent[int.Parse(SplitWord[1])];
                break;
            case "Ent_Higher":
                wordClass = Word_Ent[int.Parse(SplitWord[1])];
                break;
            case "Loc_S":
                wordClass = Word_Loc[int.Parse(SplitWord[1])];
                break;
            case "Loc_L":
                wordClass = Word_Loc[int.Parse(SplitWord[1])];
                break;
            case "ModifierA":
                wordClass = Word_Mod[0];
                break;
            case "ModifierB":
                wordClass = Word_Mod[1];
                break;
            case "ModifierC":
                wordClass = Word_Mod[2];
                break;
            case "ModifierD":
                wordClass = Word_Mod[3];
                break;

        }

        return wordClass;

    }
}
