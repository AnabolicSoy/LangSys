using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookArchiveUnit : MonoBehaviour
{
    public LangGroupClass LGC;
    public Library.BookTopic Topic;
    public int Lines;
    public string AuthorName;
    public int Cost;
    public bool IsOriginal;
    public int Age;
    public BookMarket.Era Era;

    public BookArchiveUnit(LangGroupClass LangGroup, Library.BookTopic topic, int lines,string author, int cost, bool IsOG, int age, BookMarket.Era era)
    {
        LGC = LangGroup;
        Topic = topic;
        Lines = lines;
        AuthorName = author;
        Cost = cost;
        IsOriginal = IsOG;
        Age = age;
        Era = era;
    }


}
