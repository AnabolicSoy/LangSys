using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookClass : MonoBehaviour
{

    int NumberOfLines;

   public LineClass[] StatementLines;

    public readonly Library.BookTopic MyTopic;

    public readonly LangGroupClass MyLanguage;
    public BookClass()
    { }
    public BookClass(LangGroupClass LGC, Library.BookTopic Topic,int LineNumber)
    {
        Debug.Log("InstanceOfBookClass");
        MyTopic = Topic;
        MyLanguage = LGC;
        NumberOfLines = LineNumber;

        SetUp();
    }
    private void SetUp()
    {
        Debug.Log("SetUp()");
        GrammarSystem GSys = GrammarSystem.GS;
        StatementLines = new LineClass[NumberOfLines];
        Debug.Log("StatementLines = NumberOfLines");
        for (int i = 0; i < StatementLines.Length; i++)
        {
            Debug.Log(i);
            StatementLines[i] = new LineClass();
            StatementLines[i] = GSys.GetLine(MyTopic, MyLanguage);
            Debug.Log(StatementLines[i].Words.Length);
        }
    }


}
