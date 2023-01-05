using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConceptClass : MonoBehaviour
{
    public string ConceptName;

    public int ID;

    public DataStorage.ConceptTypes Concept;

    public DataStorage.SubConceptTypes SubConcept;

    public DataStorage.SubConceptTypes GrammarValue;

    public bool IsGrammarOperator;

    public ConceptClass(string Name, int _ID, DataStorage.ConceptTypes CT, DataStorage.SubConceptTypes SCT)
    {
        ConceptName = "Concept " + Name;
        ID = _ID;
        Concept = CT;
        SubConcept = SCT;
        IsGrammarOperator = false;
        switch (SCT)
        {
            case DataStorage.SubConceptTypes.A_Con:
                IsGrammarOperator = true;
                break;
            case DataStorage.SubConceptTypes.B_Res:
                IsGrammarOperator = true;
                break;
            case DataStorage.SubConceptTypes.C_Add:
                IsGrammarOperator = true;
                break;
            case DataStorage.SubConceptTypes.D_Sub:
                IsGrammarOperator = true;
                break;
            case DataStorage.SubConceptTypes.E_Neg:
                IsGrammarOperator = true;
                break;
        }
    }

}
