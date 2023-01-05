using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrammarSystem : MonoBehaviour
{
   [SerializeField]
   DataStorage DS;

    public static GrammarSystem GS;

    private void Start()
    {
        GS = gameObject.GetComponent<GrammarSystem>();
       
    }

    public LineClass GetLine(Library.BookTopic Topic, LangGroupClass LGC)
    {
        LineClass Line = new LineClass();
       // Debug.Log("GetLine");
        switch (Topic)
        {
            case Library.BookTopic.ItemCraft:
              //  Debug.Log("BookTopic.ItemCraft");
                {
                    List<WordClass> WordList = new List<WordClass>();

                    WordClass HeadWord = LGC.GetRandomObject(DataStorage.SubConceptTypes.Object_Item);
                    Debug.Log(HeadWord.WordName);
                    Debug.Log(HeadWord.Derivatives[0].Sigils.Length);
                    WordClass Mod_B = LGC.Word_Mod[1];
                    WordClass Mod_C = LGC.Word_Mod[2];
                    if (HeadWord.Derivatives.Length == 1)
                    {
                        WordList.Add(HeadWord.Derivatives[0]);
                        WordList.Add(Mod_B);
                        WordList.Add(HeadWord);
                    }
                    else if (HeadWord.Derivatives.Length == 2)
                    {
                        WordList.Add(HeadWord.Derivatives[0]);
                        WordList.Add(Mod_C);
                        WordList.Add(HeadWord.Derivatives[1]);
                        WordList.Add(Mod_B);
                        WordList.Add(HeadWord);
                    }
                    else if (HeadWord.Derivatives.Length == 3)
                    {
                        WordList.Add(HeadWord.Derivatives[0]);
                        WordList.Add(Mod_C);
                        WordList.Add(HeadWord.Derivatives[1]);
                        WordList.Add(Mod_C);
                        WordList.Add(HeadWord.Derivatives[2]);
                        WordList.Add(Mod_B);
                        WordList.Add(HeadWord);
                    }
                    else if (HeadWord.Derivatives.Length >= 4)
                    {
                        WordList.Add(HeadWord.Derivatives[0]);
                        WordList.Add(Mod_C);
                        WordList.Add(HeadWord.Derivatives[1]);
                        WordList.Add(Mod_C);
                        WordList.Add(HeadWord.Derivatives[2]);
                        WordList.Add(Mod_C);
                        WordList.Add(HeadWord.Derivatives[3]);
                        WordList.Add(Mod_B);
                        WordList.Add(HeadWord);
                    }
                    if(WordList.Count > 0)
                    {
                        Line.Words = new WordClass[WordList.Count];
                        for (int i = 0; i < Line.Words.Length; i++)
                        {
                            Line.Words[i] = new WordClass();
                            Line.Words[i] = WordList[i];
                        }
                    }
                    else
                    {
                        Debug.LogError("NoWordsWriten");
                    }
                    
                }
                break;
            case Library.BookTopic.Alchem:
                //  Debug.Log("BookTopic.Alchem");
                {
                    List<WordClass> WordList = new List<WordClass>();

                    WordClass HeadWord = LGC.GetRandomObject(DataStorage.SubConceptTypes.Object_Base);
                    WordClass Mod_B = LGC.Word_Mod[1];
                    WordClass Mod_C = LGC.Word_Mod[2];
                    if (HeadWord.Derivatives.Length == 1)
                    {
                        WordList.Add(HeadWord.Derivatives[0]);
                        WordList.Add(Mod_B);
                        WordList.Add(HeadWord);
                    }
                    else if (HeadWord.Derivatives.Length == 2)
                    {
                        WordList.Add(HeadWord.Derivatives[0]);
                        WordList.Add(Mod_C);
                        WordList.Add(HeadWord.Derivatives[1]);
                        WordList.Add(Mod_B);
                        WordList.Add(HeadWord);
                    }
                    else if (HeadWord.Derivatives.Length == 3)
                    {
                        WordList.Add(HeadWord.Derivatives[0]);
                        WordList.Add(Mod_C);
                        WordList.Add(HeadWord.Derivatives[1]);
                        WordList.Add(Mod_C);
                        WordList.Add(HeadWord.Derivatives[2]);
                        WordList.Add(Mod_B);
                        WordList.Add(HeadWord);
                    }
                    else if (HeadWord.Derivatives.Length >= 4)
                    {
                        WordList.Add(HeadWord.Derivatives[0]);
                        WordList.Add(Mod_C);
                        WordList.Add(HeadWord.Derivatives[1]);
                        WordList.Add(Mod_C);
                        WordList.Add(HeadWord.Derivatives[2]);
                        WordList.Add(Mod_C);
                        WordList.Add(HeadWord.Derivatives[3]);
                        WordList.Add(Mod_B);
                        WordList.Add(HeadWord);
                    }
                    
                    if (WordList.Count > 0)
                    {
                        
                        Line.Words = new WordClass[WordList.Count];
                        for (int i = 0; i < Line.Words.Length; i++)
                        {
                            Line.Words[i] = new WordClass();
                            Line.Words[i] = WordList[i];

                        }
                    }
                    else
                    {
                        Debug.LogError("NoWordsWriten");
                    }
                }
                break;
            case Library.BookTopic.Mapping:
                {
                    //    Debug.Log("Library.BookTopic.Mapping");
                    List<WordClass> WordList = new List<WordClass>();

                    WordClass HeadWord = LGC.GetRandomLocation(DataStorage.SubConceptTypes.Location_S);
                    Debug.Log(HeadWord.WordName);
                    WordClass Mod_A = LGC.Word_Mod[0];
                    if (HeadWord.Derivatives.Length == 1)
                    {
                        WordList.Add(HeadWord);
                        WordList.Add(Mod_A);
                        WordList.Add(HeadWord.Derivatives[0]);
                    }
                    else if (HeadWord.Derivatives.Length == 2)
                    {
                        WordList.Add(HeadWord);
                        WordList.Add(Mod_A);
                        WordList.Add(HeadWord.Derivatives[0]);
                        WordList.Add(HeadWord.Derivatives[1]);

                    }
                    else if (HeadWord.Derivatives.Length == 3)
                    {
                        WordList.Add(HeadWord);
                        WordList.Add(Mod_A);
                        WordList.Add(HeadWord.Derivatives[0]);
                        WordList.Add(HeadWord.Derivatives[1]);
                        WordList.Add(HeadWord.Derivatives[2]);
                    }
                    else if (HeadWord.Derivatives.Length >= 4)
                    {
                        WordList.Add(HeadWord);
                        WordList.Add(Mod_A);
                        WordList.Add(HeadWord.Derivatives[0]);
                        WordList.Add(HeadWord.Derivatives[1]);
                        WordList.Add(HeadWord.Derivatives[2]);
                        WordList.Add(HeadWord.Derivatives[3]);
                    }
                    Debug.Log(WordList.Count);
                    if (WordList.Count > 0)
                    {
                        Line.Words = new WordClass[WordList.Count];

                        for (int i = 0; i < Line.Words.Length; i++)
                        {
                            Line.Words[i] = new WordClass();
                            Line.Words[i] = WordList[i];
                        }
                    }
                    else
                    {
                        Debug.LogError("NoWordsWriten");
                    }
                }
                break;
        }

        return Line;
    }



}
