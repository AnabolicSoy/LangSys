using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class DataStorage : MonoBehaviour
{
    [SerializeField]
    public Sprite[] Symbols1;
    [SerializeField]
    public Sprite[] Symbols2;
    [SerializeField]
    public Sprite[] Symbols3;
    [SerializeField]
    public Sprite[] Symbols4;
    [SerializeField]
    public Sprite[] Symbols5;
    [SerializeField]
    public Sprite[] Symbols6;
    [SerializeField]
    public Sprite NullSprite;

    [SerializeField]
    Text CoinsDisplay;

    [SerializeField]
    public GameObject[] LanguageGroups;

    public bool IsSetup;

    private int PlayerCoins;


    public enum ConceptTypes
    {
        Entity,
        Object,
        Location,
        Modifier,
    }

    public enum SubConceptTypes
    {
        A_Con,               // Contains / IsMadeOf
        B_Res,               // ResultsIn
        C_Add,               // Addition / Added to 
        D_Sub,               //  Subtracted 
        E_Neg,               // Is Not/ Negation
        Location_S,
        Location_L,
        Object_Elemental,
        Object_Base,
        Object_Item,
        Object_Compound,
        Object_Structural,
        Entity_Minor,
        Entity_Basal,
        Entity_Higher,
    }

    public void StartSet()
    {
        IsSetup = true;
        SetSymbols();
        SetModWords();
        SetObjWords();
        SetEntWords();
        SetLocWords();
        SetDerivatives();
    }

    private void SetSymbols()
    {
        for (int i = 0; i < LanguageGroups.Length; i++)
        {
            LangGroupClass LGC = LanguageGroups[i].GetComponent<LangGroupClass>();
            LGC.Symbols = new SigilClass[20];
            //----------------------------//
            int[] SyNumber = new int[4];
            for (int j = 0; j < 4; j++)
            {
                Reset:;
                SyNumber[j] = Random.Range(0, 6);
                for (int k = 0; k < j; k++)
                {
                    if (j != k && SyNumber[j] == SyNumber[k])
                    {
                        goto Reset;
                    }
                }

            }
           // Debug.Log(SyNumber[0] + " " + SyNumber[1] + " " + SyNumber[2] + " " + SyNumber[3]);
            //----------------------------//
            for (int j = 0; j < 5; j++)
            {
                switch (SyNumber[0])
                {
                    case 0:
                        LGC.Symbols[j] = new SigilClass(Symbols1[j], j);
                        break;
                    case 1:
                        LGC.Symbols[j] = new SigilClass(Symbols2[j], j);
                        break;
                    case 2:
                        LGC.Symbols[j] = new SigilClass(Symbols3[j], j);
                        break;
                    case 3:
                        LGC.Symbols[j] = new SigilClass(Symbols4[j], j);
                        break;
                    case 4:
                        LGC.Symbols[j] = new SigilClass(Symbols5[j], j);
                        break;
                    case 5:
                        LGC.Symbols[j] = new SigilClass(Symbols6[j], j);
                        break;

                }
            }
            for (int j = 5; j < 10; j++)
            {
                switch (SyNumber[1])
                {
                    case 0:
                        LGC.Symbols[j] = new SigilClass(Symbols1[j - 5], j - 5);
                        break;
                    case 1:
                        LGC.Symbols[j] = new SigilClass(Symbols2[j - 5], j - 5);
                        break;
                    case 2:
                        LGC.Symbols[j] = new SigilClass(Symbols3[j - 5], j - 5);
                        break;
                    case 3:
                        LGC.Symbols[j] = new SigilClass(Symbols4[j - 5], j - 5);
                        break;
                    case 4:
                        LGC.Symbols[j] = new SigilClass(Symbols5[j - 5], j - 5);
                        break;
                    case 5:
                        LGC.Symbols[j] = new SigilClass(Symbols6[j - 5], j - 5);
                        break;

                }
            }
            for (int j = 10; j < 15; j++)
            {
                switch (SyNumber[2])
                {
                    case 0:
                        LGC.Symbols[j] = new SigilClass(Symbols1[j - 10], j - 10);
                        break;
                    case 1:
                        LGC.Symbols[j] = new SigilClass(Symbols2[j - 10], j - 10);
                        break;
                    case 2:
                        LGC.Symbols[j] = new SigilClass(Symbols3[j - 10], j - 10);
                        break;
                    case 3:
                        LGC.Symbols[j] = new SigilClass(Symbols4[j - 10], j - 10);
                        break;
                    case 4:
                        LGC.Symbols[j] = new SigilClass(Symbols5[j - 10], j - 10);
                        break;
                    case 5:
                        LGC.Symbols[j] = new SigilClass(Symbols6[j - 10], j - 10);
                        break;

                }
            }
            for (int j = 15; j < 20; j++)
            {
                switch (SyNumber[3])
                {
                    case 0:
                        LGC.Symbols[j] = new SigilClass(Symbols1[j - 15], j - 15);
                        break;
                    case 1:
                        LGC.Symbols[j] = new SigilClass(Symbols2[j - 15], j - 15);
                        break;
                    case 2:
                        LGC.Symbols[j] = new SigilClass(Symbols3[j - 15], j - 15);
                        break;
                    case 3:
                        LGC.Symbols[j] = new SigilClass(Symbols4[j - 15], j - 15);
                        break;
                    case 4:
                        LGC.Symbols[j] = new SigilClass(Symbols5[j - 15], j - 15);
                        break;
                    case 5:
                        LGC.Symbols[j] = new SigilClass(Symbols6[j - 15], j - 15);
                        break;

                }
            }

        }
    }
    private void GetSymbolsArray(SigilClass[] Symbols,out SigilClass[] Word)
    {
        Word = new SigilClass[Random.Range(3, 9)];
        for (int i = 0; i < Word.Length; i++)
        {
            Word[i] = Symbols[Random.Range(0, Symbols.Length)];
        }

    }

    private void SetModWords()
    {
        for (int i = 0; i < LanguageGroups.Length; i++)
        {
            LangGroupClass LGC = LanguageGroups[i].GetComponent<LangGroupClass>();

            LGC.Word_Mod = new WordClass[4];


            GetSymbolsArray(LGC.Symbols, out SigilClass[] Word);
            LGC.Word_Mod[0] = new WordClass("ModifierA:0" , 0, Word, ConceptTypes.Modifier, SubConceptTypes.A_Con);
            LGC.Word_Mod[0].RealProxie = Proxies.ConceptProxies.Contains_IsMadeOf_Has;
            GetSymbolsArray(LGC.Symbols, out SigilClass[] Word1);
            LGC.Word_Mod[1] = new WordClass("ModifierB:0" , 1, Word1, ConceptTypes.Modifier, SubConceptTypes.B_Res);
            LGC.Word_Mod[1].RealProxie = Proxies.ConceptProxies.ResultsIn;
            GetSymbolsArray(LGC.Symbols, out SigilClass[] Word2);
            LGC.Word_Mod[2] = new WordClass("ModifierC:0" , 2, Word2, ConceptTypes.Modifier, SubConceptTypes.C_Add);
            LGC.Word_Mod[2].RealProxie = Proxies.ConceptProxies.And_AddedTo_JoinedWith;
            GetSymbolsArray(LGC.Symbols, out SigilClass[] Word3);
            LGC.Word_Mod[3] = new WordClass("ModifierD:0", 3, Word3, ConceptTypes.Modifier, SubConceptTypes.D_Sub);
            LGC.Word_Mod[3].RealProxie = Proxies.ConceptProxies.SubtractedFrom_RemovedFrom;
        }
    }
    private void SetObjWords()
    {
        //Debug.Log("Log");
        for (int i = 0; i < LanguageGroups.Length; i++)
        {
            int Elem = Random.Range(5, 15);
            int Base = Random.Range(15, 35);
            int Item = Random.Range(35, 50);
            int Comp = Random.Range(30, 50);
            int Strut = Random.Range(30, 50);
            LangGroupClass LGC = LanguageGroups[i].GetComponent<LangGroupClass>();
            LGC.Word_Obj = new WordClass[Elem+Base+Item+Comp+Strut];
            for (int j = 0; j < Elem; j++)
            {
                GetSymbolsArray(LGC.Symbols, out SigilClass[] Word);
                LGC.Word_Obj[j] = new WordClass("Obj_Element:" + j, j, Word, ConceptTypes.Object, SubConceptTypes.Object_Elemental);
                LGC.Word_Obj[j].RealProxie = Proxies.ConceptProxies.Element;
            }
            for (int j = Elem; j < Elem + Base; j++)
            {
                GetSymbolsArray(LGC.Symbols, out SigilClass[] Word);
                LGC.Word_Obj[j] = new WordClass("Obj_Base:" + j , j , Word, ConceptTypes.Object, SubConceptTypes.Object_Base);
                if (j < 11 + Elem)
                {
                    switch (j- Elem)
                    {
                        case 0:
                            LGC.Word_Obj[j].RealProxie = Proxies.ConceptProxies.Base_Bone;
                            break;
                        case 1:
                            LGC.Word_Obj[j].RealProxie = Proxies.ConceptProxies.Base_Metal;
                            break;
                        case 2:
                            LGC.Word_Obj[j].RealProxie = Proxies.ConceptProxies.Base_Wood;
                            break;
                        case 3:
                            LGC.Word_Obj[j].RealProxie = Proxies.ConceptProxies.Base_Stone;
                            break;
                        case 4:
                            LGC.Word_Obj[j].RealProxie = Proxies.ConceptProxies.Base_Cloth;
                            break;
                        case 5:
                            LGC.Word_Obj[j].RealProxie = Proxies.ConceptProxies.Base_Hide;
                            break;
                        case 6:
                            LGC.Word_Obj[j].RealProxie = Proxies.ConceptProxies.Base_Liquid;
                            break;
                        case 7:
                            LGC.Word_Obj[j].RealProxie = Proxies.ConceptProxies.Base_Crystal;
                            break;
                        case 8:
                            LGC.Word_Obj[j].RealProxie = Proxies.ConceptProxies.Base_AnimalParts;
                            break;
                        case 9:
                            LGC.Word_Obj[j].RealProxie = Proxies.ConceptProxies.Base_PlantMatter;
                            break;
                        case 10:
                            LGC.Word_Obj[j].RealProxie = Proxies.ConceptProxies.Base_Clay;
                            break;
                    }
                }
                else
                {
                    switch (Random.Range(0, 11))
                    {
                        case 0:
                            LGC.Word_Obj[j].RealProxie = Proxies.ConceptProxies.Base_Bone;
                            break;
                        case 1:
                            LGC.Word_Obj[j].RealProxie = Proxies.ConceptProxies.Base_Metal;
                            break;
                        case 2:
                            LGC.Word_Obj[j].RealProxie = Proxies.ConceptProxies.Base_Wood;
                            break;
                        case 3:
                            LGC.Word_Obj[j].RealProxie = Proxies.ConceptProxies.Base_Stone;
                            break;
                        case 4:
                            LGC.Word_Obj[j].RealProxie = Proxies.ConceptProxies.Base_Cloth;
                            break;
                        case 5:
                            LGC.Word_Obj[j].RealProxie = Proxies.ConceptProxies.Base_Hide;
                            break;
                        case 6:
                            LGC.Word_Obj[j].RealProxie = Proxies.ConceptProxies.Base_Liquid;
                            break;
                        case 7:
                            LGC.Word_Obj[j].RealProxie = Proxies.ConceptProxies.Base_Crystal;
                            break;
                        case 8:
                            LGC.Word_Obj[j].RealProxie = Proxies.ConceptProxies.Base_AnimalParts;
                            break;
                        case 9:
                            LGC.Word_Obj[j].RealProxie = Proxies.ConceptProxies.Base_PlantMatter;
                            break;
                        case 10:
                            LGC.Word_Obj[j].RealProxie = Proxies.ConceptProxies.Base_Clay;
                            break;
                    }
                }
            }
            for (int j = Elem + Base; j < Item + Elem +Base; j++)
            {
                GetSymbolsArray(LGC.Symbols, out SigilClass[] Word);
                LGC.Word_Obj[j] = new WordClass("Obj_Item:" + j , j , Word, ConceptTypes.Object, SubConceptTypes.Object_Item);
                if (j < 4 + Elem + Base)
                {
                    switch (j - (Elem + Base))
                    {
                        case 0:
                            LGC.Word_Obj[j].RealProxie = Proxies.ConceptProxies.Item_ClothingFabric;
                            break;
                        case 1:
                            LGC.Word_Obj[j].RealProxie = Proxies.ConceptProxies.Item_PotionElixer;
                            break;
                        case 2:
                            LGC.Word_Obj[j].RealProxie = Proxies.ConceptProxies.Item_Trinket;
                            break;
                        case 3:
                            LGC.Word_Obj[j].RealProxie = Proxies.ConceptProxies.Item_ToolWeapon;
                            break;
                    }
                }
                else
                {
                    switch (Random.Range(0, 4))
                    {
                        case 0:
                            LGC.Word_Obj[j].RealProxie = Proxies.ConceptProxies.Item_ClothingFabric;
                            break;
                        case 1:
                            LGC.Word_Obj[j].RealProxie = Proxies.ConceptProxies.Item_PotionElixer;
                            break;
                        case 2:
                            LGC.Word_Obj[j].RealProxie = Proxies.ConceptProxies.Item_Trinket;
                            break;
                        case 3:
                            LGC.Word_Obj[j].RealProxie = Proxies.ConceptProxies.Item_ToolWeapon;
                            break;
                    }
                }
            }
            for (int j = Item + Elem + Base; j < Item + Elem + Base + Comp; j++)
            {
                GetSymbolsArray(LGC.Symbols, out SigilClass[] Word);
                LGC.Word_Obj[j] = new WordClass("Obj_Compound:" + j , j , Word, ConceptTypes.Object, SubConceptTypes.Object_Compound);
                if (j < 3 + Item + Elem + Base)
                {
                    switch (j -(Item + Elem + Base))
                    {
                        case 0:
                            LGC.Word_Obj[j].RealProxie = Proxies.ConceptProxies.Compound_Complex_StorageStandStrut;
                            break;
                        case 1:
                            LGC.Word_Obj[j].RealProxie = Proxies.ConceptProxies.Compound_Simple_StorageStandStrut;
                            break;

                        case 2:
                            LGC.Word_Obj[j].RealProxie = Proxies.ConceptProxies.Compound_Intermediate_StorageStandStrut;
                            break;

                    }
                }
                else
                {
                    switch (Random.Range(0, 3))
                    {
                        case 0:
                            LGC.Word_Obj[j].RealProxie = Proxies.ConceptProxies.Compound_Complex_StorageStandStrut;
                            break;
                        case 1:
                            LGC.Word_Obj[j].RealProxie = Proxies.ConceptProxies.Compound_Simple_StorageStandStrut;
                            break;

                        case 2:
                            LGC.Word_Obj[j].RealProxie = Proxies.ConceptProxies.Compound_Intermediate_StorageStandStrut;
                            break;
                    }
                }
            }
            for (int j = Item + Elem + Base + Comp; j < Strut + Item + Elem + Base + Comp; j++)
            {
                GetSymbolsArray(LGC.Symbols, out SigilClass[] Word);
                LGC.Word_Obj[j] = new WordClass("Obj_Strut:" + j , j , Word, ConceptTypes.Object, SubConceptTypes.Object_Structural);
                if (j < 4 + Item + Elem + Base + Comp)
                {
                    switch (j - (Item + Elem + Base + Comp))
                    {
                        case 0:
                            LGC.Word_Obj[j].RealProxie = Proxies.ConceptProxies.Structure_CompoundBuilding;
                            break;
                        case 1:
                            LGC.Word_Obj[j].RealProxie = Proxies.ConceptProxies.Structure_PrimitiveBuilding;
                            break;
                        case 2:
                            LGC.Word_Obj[j].RealProxie = Proxies.ConceptProxies.Structure_StoneBuilding;
                            break;
                        case 3:
                            LGC.Word_Obj[j].RealProxie = Proxies.ConceptProxies.Structure_WoodBuilding;
                            break;
                      
                    }
                }
                else
                {
                    switch (Random.Range(0, 4))
                    {
                        case 0:
                            LGC.Word_Obj[j].RealProxie = Proxies.ConceptProxies.Structure_CompoundBuilding;
                            break;
                        case 1:
                            LGC.Word_Obj[j].RealProxie = Proxies.ConceptProxies.Structure_PrimitiveBuilding;
                            break;
                        case 2:
                            LGC.Word_Obj[j].RealProxie = Proxies.ConceptProxies.Structure_StoneBuilding;
                            break;
                        case 3:
                            LGC.Word_Obj[j].RealProxie = Proxies.ConceptProxies.Structure_WoodBuilding;
                            break;
                    }
                }
            }

           //Debug.Log(LGC.Word_Obj.Length);
           // Debug.Log(LGC.Word_Obj[0].WordName);
        }
    }
    private void SetEntWords()
    {

       // Debug.Log("Log");

        for (int i = 0; i < LanguageGroups.Length; i++)
        {
            int Ent_L = Random.Range(5, 51);
            int Ent_C = Random.Range(35, 51);
            int Ent_H = Random.Range(1, 14);
            LangGroupClass LGC = LanguageGroups[i].GetComponent<LangGroupClass>();
            LGC.Word_Ent = new WordClass[Ent_L + Ent_C + Ent_H];
            for (int j = 0; j < Ent_L; j++)
            {
                GetSymbolsArray(LGC.Symbols, out SigilClass[] Word);
                LGC.Word_Ent[j] = new WordClass("Ent_Minor:" + j, j, Word, ConceptTypes.Entity, SubConceptTypes.Entity_Minor);
                if (j < 3 )
                {
                    switch (j)
                    {
                        case 0:
                            LGC.Word_Ent[j].RealProxie = Proxies.ConceptProxies.Minor_Animal;
                            break;
                        case 1:
                            LGC.Word_Ent[j].RealProxie = Proxies.ConceptProxies.Minor_Plant;
                            break;
                        case 2:
                            LGC.Word_Ent[j].RealProxie = Proxies.ConceptProxies.Minor_Spirit;
                            break;

                    }
                }
                else
                {
                    switch (Random.Range(0, 3))
                    {
                        case 0:
                            LGC.Word_Ent[j].RealProxie = Proxies.ConceptProxies.Minor_Animal;
                            break;
                        case 1:
                            LGC.Word_Ent[j].RealProxie = Proxies.ConceptProxies.Minor_Plant;
                            break;
                        case 2:
                            LGC.Word_Ent[j].RealProxie = Proxies.ConceptProxies.Minor_Spirit;
                            break;
                    }
                }
            }
            for (int j =  Ent_L; j < Ent_C + Ent_L; j++)
            {
                GetSymbolsArray(LGC.Symbols, out SigilClass[] Word);
                LGC.Word_Ent[j] = new WordClass("Ent_Basal:" + j , j , Word, ConceptTypes.Entity, SubConceptTypes.Entity_Basal);
                LGC.Word_Ent[j].RealProxie = Proxies.ConceptProxies.Common_Humanoid;
            }
            for (int j = Ent_C + Ent_L; j < Ent_C + Ent_L + Ent_H; j++)
            {
                GetSymbolsArray(LGC.Symbols, out SigilClass[] Word);
                LGC.Word_Ent[j] = new WordClass("Ent_Higher:" + j , j , Word, ConceptTypes.Entity, SubConceptTypes.Entity_Higher);
                
                    switch (Random.Range(0,2))
                    {
                        case 0:
                            LGC.Word_Ent[j].RealProxie = Proxies.ConceptProxies.High_HighSpirit;
                            break;
                        case 1:
                            LGC.Word_Ent[j].RealProxie = Proxies.ConceptProxies.High_King;
                            break;
                    }
                

            }
           


        }
    }
    private void SetLocWords()
    {
     //   Debug.Log("Log");


        for (int i = 0; i < LanguageGroups.Length; i++)
        {
            int LocS = Random.Range(30, 41);
            int LocL = Random.Range(3, 7);
            LangGroupClass LGC = LanguageGroups[i].GetComponent<LangGroupClass>();
            LGC.Word_Loc = new WordClass[LocS + LocL];
            for (int j = 0; j < LocS; j++)
            {
                GetSymbolsArray(LGC.Symbols, out SigilClass[] Word);
                LGC.Word_Loc[j] = new WordClass("Loc_S:" + j, j, Word, ConceptTypes.Location, SubConceptTypes.Location_S);
                if (j < 3 )
                {
                    switch (j)
                    {
                        case 0:
                            LGC.Word_Loc[j].RealProxie = Proxies.ConceptProxies.Loc_S_Wild;
                            break;
                        case 1:
                            LGC.Word_Loc[j].RealProxie = Proxies.ConceptProxies.Loc_S_Rural;
                            break;
                        case 2:
                            LGC.Word_Loc[j].RealProxie = Proxies.ConceptProxies.Loc_S_Civilized;
                            break;

                    }
                }
                else
                {
                    switch (Random.Range(0, 3))
                    {
                        case 0:
                            LGC.Word_Loc[j].RealProxie = Proxies.ConceptProxies.Loc_S_Wild;
                            break;
                        case 1:
                            LGC.Word_Loc[j].RealProxie = Proxies.ConceptProxies.Loc_S_Rural;
                            break;
                        case 2:
                            LGC.Word_Loc[j].RealProxie = Proxies.ConceptProxies.Loc_S_Civilized;
                            break;
                    }
                }
            }
            for (int j = LocS ; j < LocS + LocL; j++)
            {
                GetSymbolsArray(LGC.Symbols, out SigilClass[] Word);
                LGC.Word_Loc[j] = new WordClass("Loc_L:" + j , j , Word, ConceptTypes.Location, SubConceptTypes.Location_L);
                LGC.Word_Loc[j].RealProxie = Proxies.ConceptProxies.Loc_L;
            }
           
        }
    }

    private void SetDerivatives()
    {
        //Obj.Elem  :  No derivatives
        //Obj.Base  : Elem 
        //Obj.Item  : Base
        //Obj.Comp  : Item : Base
        //Obj.Strut : Comp : Item : Base 
        //Ent.Minor : Elem : Base
        //Ent.Base  : Elem : Item : Strut
        //Ent.Hig   : Elem : Loc.S : Item
        //Loc.S     : Obj.Strut
        //Loc.H     : Loc.S
       // Debug.Log("Log");
        ObjectDerivatives();
        EntityDerivatives();
        LocationDerivatives();
    }
    private void ObjectDerivatives()
    {
       // Debug.Log("Log");
        for (int i = 0; i < LanguageGroups.Length; i++)
        {
            LangGroupClass LGC = LanguageGroups[i].GetComponent<LangGroupClass>();
            for (int j = 0; j < LGC.Word_Obj.Length; j++)
            {
                switch (LGC.Word_Obj[j].GetMySubConceptType())
                {
                   
                    case SubConceptTypes.Object_Elemental:
                        LGC.Word_Obj[j].Derivatives = new WordClass[1];
                        LGC.Word_Obj[j].Derivatives[0] = LGC.Word_Obj[j];
                        break;
                    case SubConceptTypes.Object_Base:
                        GetWordListBySub(ConceptTypes.Object,DataStorage.SubConceptTypes.Object_Elemental, LGC, Random.Range(1, 6), out WordClass[] A_1, LGC.Word_Obj[j]);
                        if(A_1.Length == 0)
                        {
                            Debug.LogError("ERROR");
                        }
                        LGC.Word_Obj[j].Derivatives = A_1;
                        break;
                    case SubConceptTypes.Object_Item:
                        GetWordListBySub(ConceptTypes.Object,DataStorage.SubConceptTypes.Object_Base, LGC, Random.Range(1, 4), out WordClass[] B_1 , LGC.Word_Obj[j]); 
                        if (B_1.Length == 0)
                        {
                            Debug.LogError("ERROR");
                        }
                        GetWordListBySub(ConceptTypes.Object, DataStorage.SubConceptTypes.Object_Base, LGC, Random.Range(1, 4), out  WordClass[] B_2, LGC.Word_Obj[j]);
                        if (B_2.Length == 0)
                        {
                            Debug.LogError("ERROR");
                        }
                        LGC.Word_Obj[j].Derivatives = B_1;
                        LGC.Word_Obj[j].Derivatives.Concat<WordClass>(B_2).ToArray();
                        
                        break;
                    case SubConceptTypes.Object_Compound:
                        GetWordListBySub(ConceptTypes.Object, DataStorage.SubConceptTypes.Object_Base, LGC, Random.Range(1, 6), out WordClass[] C_1, LGC.Word_Obj[j]);
                        if (C_1.Length == 0)
                        {
                            Debug.LogError("ERROR");
                        }
                        LGC.Word_Obj[j].Derivatives = C_1;
                        break;
                    case SubConceptTypes.Object_Structural:
                        GetWordListBySub(ConceptTypes.Object, DataStorage.SubConceptTypes.Object_Item, LGC, Random.Range(1, 24), out WordClass[] D_1, LGC.Word_Obj[j]);
                        if (D_1.Length == 0)
                        {
                            Debug.LogError("ERROR");
                        }
                        GetWordListBySub(ConceptTypes.Object, DataStorage.SubConceptTypes.Object_Compound, LGC, Random.Range(1, 13), out WordClass[] D_2, LGC.Word_Obj[j]);
                        if (D_2.Length == 0)
                        {
                            Debug.LogError("ERROR");
                        }
                        LGC.Word_Obj[j].Derivatives =   D_1;
                        LGC.Word_Obj[j].Derivatives.Concat<WordClass>(D_2).ToArray();
                        break;


                }
            }
        }
    }
    private void EntityDerivatives()
    {
     //   Debug.Log("Log");
        for (int i = 0; i < LanguageGroups.Length; i++)
        {
            LangGroupClass LGC = LanguageGroups[i].GetComponent<LangGroupClass>();
            for (int j = 0; j < LGC.Word_Ent.Length; j++)
            {
                switch (LGC.Word_Ent[j].GetMySubConceptType())
                {

                    case SubConceptTypes.Entity_Minor:
                        GetWordListBySub(ConceptTypes.Object, DataStorage.SubConceptTypes.Object_Base, LGC, Random.Range(1, 3), out WordClass[] A_1, LGC.Word_Ent[j]);
                        LGC.Word_Ent[j].Derivatives = A_1;

                        break;
                    case SubConceptTypes.Entity_Basal:

                        GetWordListBySub(ConceptTypes.Object, DataStorage.SubConceptTypes.Object_Base, LGC, Random.Range(1, 4), out WordClass[] B_1, LGC.Word_Ent[j]);
                        GetWordListBySub(ConceptTypes.Object, DataStorage.SubConceptTypes.Object_Item, LGC, Random.Range(1, 9), out WordClass[] B_2, LGC.Word_Ent[j]);
                        LGC.Word_Ent[j].Derivatives = B_1;
                        LGC.Word_Ent[j].Derivatives.Concat<WordClass>(B_2).ToArray();

                        break;
                    case SubConceptTypes.Entity_Higher:
                        GetWordListBySub(ConceptTypes.Location, DataStorage.SubConceptTypes.Location_S, LGC, Random.Range(1, 9), out WordClass[] C_1, LGC.Word_Ent[j]);
                        GetWordListBySub(ConceptTypes.Object, DataStorage.SubConceptTypes.Object_Item, LGC, Random.Range(1, 6), out WordClass[] C_2, LGC.Word_Ent[j]);
                        GetWordListBySub(ConceptTypes.Object, DataStorage.SubConceptTypes.Object_Base, LGC, Random.Range(1, 6), out WordClass[] C_3, LGC.Word_Ent[j]);
                        LGC.Word_Ent[j].Derivatives = C_1;
                        LGC.Word_Ent[j].Derivatives.Concat<WordClass>(C_2).ToArray();
                        LGC.Word_Ent[j].Derivatives.Concat<WordClass>(C_3).ToArray();
                        break;
  


                }
            }
        }

    }
    private void LocationDerivatives()
    {
        //Debug.Log("Log");
        for (int i = 0; i < LanguageGroups.Length; i++)
        {
            LangGroupClass LGC = LanguageGroups[i].GetComponent<LangGroupClass>();
            for (int j = 0; j < LGC.Word_Loc.Length; j++)
            {
                switch (LGC.Word_Loc[j].GetMySubConceptType())
                {

                    case SubConceptTypes.Location_S:
                        GetWordListBySub(ConceptTypes.Object, DataStorage.SubConceptTypes.Object_Structural, LGC, Random.Range(1, 25), out WordClass[] A_1, LGC.Word_Loc[j]);
                        GetWordListBySub(ConceptTypes.Entity, DataStorage.SubConceptTypes.Entity_Minor, LGC, Random.Range(1, 16), out WordClass[] A_2, LGC.Word_Loc[j]);
                        GetWordListBySub(ConceptTypes.Entity, DataStorage.SubConceptTypes.Entity_Basal, LGC, Random.Range(1, 16), out WordClass[] A_3, LGC.Word_Loc[j]);
                        LGC.Word_Loc[j].Derivatives = A_1;
                        LGC.Word_Loc[j].Derivatives.Concat<WordClass>(A_2).ToArray();
                        LGC.Word_Loc[j].Derivatives.Concat<WordClass>(A_3).ToArray();
                        break;
                    case SubConceptTypes.Location_L:
                        GetWordListBySub(ConceptTypes.Location, DataStorage.SubConceptTypes.Location_S, LGC, Random.Range(1, 6), out WordClass[] D_1, LGC.Word_Loc[j]);
                        LGC.Word_Loc[j].Derivatives = D_1;
                        LGC.Word_Loc[j].Derivatives.Concat<WordClass>(D_1).ToArray();
                        break;


                }
            }
        }

    }

    private void FilterByProxy(Proxies.ConceptProxies Prox, List<WordClass> WordList, out WordClass[] WordArray, int NumberOfWords)
    {
        //Debug.Log("Log");
        WordArray = new WordClass[NumberOfWords];
        for (int i = 0; i < WordList.Count; i++)
        {
            //Debug.Log(i);
            switch (Prox)
            {
                case Proxies.ConceptProxies.Item_ToolWeapon:
                    if (WordList[i].RealProxie != (Proxies.ConceptProxies.Base_Bone | Proxies.ConceptProxies.Base_Metal | Proxies.ConceptProxies.Base_Wood | Proxies.ConceptProxies.Base_Stone))
                    { WordList.RemoveAt(i); }
                        break;
                case Proxies.ConceptProxies.Item_Trinket:
                    if (WordList[i].RealProxie != (Proxies.ConceptProxies.Base_Bone | Proxies.ConceptProxies.Base_Metal | Proxies.ConceptProxies.Base_Wood | Proxies.ConceptProxies.Base_Stone))
                    { WordList.RemoveAt(i); }
                    break;
                case Proxies.ConceptProxies.Item_PotionElixer:
                    if (WordList[i].RealProxie != (Proxies.ConceptProxies.Base_Liquid | Proxies.ConceptProxies.Base_PlantMatter | Proxies.ConceptProxies.Base_AnimalParts))
                    { WordList.RemoveAt(i); }
                    break;
                case Proxies.ConceptProxies.Item_ClothingFabric:
                    if (WordList[i].RealProxie != (Proxies.ConceptProxies.Base_Hide | Proxies.ConceptProxies.Base_Cloth ))
                    { WordList.RemoveAt(i); }
                    break;
                case Proxies.ConceptProxies.Compound_Simple_StorageStandStrut:
                    if (WordList[i].RealProxie != (Proxies.ConceptProxies.Base_Bone  | Proxies.ConceptProxies.Base_Wood | Proxies.ConceptProxies.Base_Clay))
                    { WordList.RemoveAt(i); }
                    break;
                case Proxies.ConceptProxies.Compound_Intermediate_StorageStandStrut:
                    if (WordList[i].RealProxie != (  Proxies.ConceptProxies.Base_Metal | Proxies.ConceptProxies.Base_Wood | Proxies.ConceptProxies.Base_Stone))
                    { WordList.RemoveAt(i); }
                    break;
                case Proxies.ConceptProxies.Compound_Complex_StorageStandStrut:
                    if (WordList[i].RealProxie != (   Proxies.ConceptProxies.Base_Wood | Proxies.ConceptProxies.Base_Stone))
                    { WordList.RemoveAt(i); }
                    break;
                case Proxies.ConceptProxies.Structure_PrimitiveBuilding:
                    if (WordList[i].RealProxie != (Proxies.ConceptProxies.Base_Bone  | Proxies.ConceptProxies.Base_Wood | Proxies.ConceptProxies.Base_PlantMatter))
                    { WordList.RemoveAt(i); }
                    break;
                case Proxies.ConceptProxies.Structure_StoneBuilding:
                    if (WordList[i].RealProxie != ( Proxies.ConceptProxies.Base_Stone))
                    { WordList.RemoveAt(i); }
                    break;
                case Proxies.ConceptProxies.Structure_WoodBuilding:
                    if (WordList[i].RealProxie != ( Proxies.ConceptProxies.Base_Wood ))
                    { WordList.RemoveAt(i); }
                    break;
                case Proxies.ConceptProxies.Structure_CompoundBuilding:
                    if (WordList[i].RealProxie != ( Proxies.ConceptProxies.Base_Metal  | Proxies.ConceptProxies.Base_Clay | Proxies.ConceptProxies.Base_Stone | Proxies.ConceptProxies.Base_Wood))
                    { WordList.RemoveAt(i); }
                    break;
                case Proxies.ConceptProxies.Minor_Animal:
                    if (WordList[i].RealProxie != (Proxies.ConceptProxies.Base_Bone | Proxies.ConceptProxies.Base_AnimalParts ))
                    { WordList.RemoveAt(i); }
                    break;
                case Proxies.ConceptProxies.Minor_Spirit:
                    if (WordList[i].RealProxie != (Proxies.ConceptProxies.Base_Crystal))
                    { WordList.RemoveAt(i); }
                    break;
                case Proxies.ConceptProxies.Minor_Plant:
                    if (WordList[i].RealProxie != (Proxies.ConceptProxies.Base_PlantMatter | Proxies.ConceptProxies.Base_Wood | Proxies.ConceptProxies.Base_Liquid))
                    { WordList.RemoveAt(i); }
                    break;
                case Proxies.ConceptProxies.Common_Humanoid:
                    if (WordList[i].RealProxie != (Proxies.ConceptProxies.Item_Trinket | Proxies.ConceptProxies.Item_ToolWeapon | Proxies.ConceptProxies.Item_PotionElixer | Proxies.ConceptProxies.Item_ClothingFabric | Proxies.ConceptProxies.Base_Metal | Proxies.ConceptProxies.Base_Cloth | Proxies.ConceptProxies.Base_Hide | Proxies.ConceptProxies.Base_Crystal))
                    { WordList.RemoveAt(i); }
                    break;
                case Proxies.ConceptProxies.High_King:
                    if (WordList[i].RealProxie != (Proxies.ConceptProxies.Loc_S_Wild | Proxies.ConceptProxies.Loc_S_Rural | Proxies.ConceptProxies.Loc_S_Civilized | Proxies.ConceptProxies.Item_ToolWeapon | Proxies.ConceptProxies.Item_Trinket | Proxies.ConceptProxies.Item_PotionElixer | Proxies.ConceptProxies.Item_ClothingFabric | Proxies.ConceptProxies.Base_Metal | Proxies.ConceptProxies.Base_Cloth | Proxies.ConceptProxies.Base_Hide | Proxies.ConceptProxies.Base_Crystal))
                    { WordList.RemoveAt(i); }
                    break;
                case Proxies.ConceptProxies.High_HighSpirit:
                    if (WordList[i].RealProxie != (Proxies.ConceptProxies.Loc_S_Wild | Proxies.ConceptProxies.Loc_S_Rural | Proxies.ConceptProxies.Loc_S_Civilized ))
                    { WordList.RemoveAt(i); }
                    break;
                case Proxies.ConceptProxies.Loc_S_Wild:
                    if (WordList[i].RealProxie != (Proxies.ConceptProxies.Minor_Plant | Proxies.ConceptProxies.Minor_Animal | Proxies.ConceptProxies.Minor_Spirit))
                    { WordList.RemoveAt(i); }
                    break;
                case Proxies.ConceptProxies.Loc_S_Rural:
                    if (WordList[i].RealProxie != (Proxies.ConceptProxies.Minor_Plant | Proxies.ConceptProxies.Minor_Animal | Proxies.ConceptProxies.Minor_Spirit | Proxies.ConceptProxies.Structure_WoodBuilding | Proxies.ConceptProxies.Structure_PrimitiveBuilding))
                    { WordList.RemoveAt(i); }
                    break;
                case Proxies.ConceptProxies.Loc_S_Civilized:
                    if (WordList[i].RealProxie != (Proxies.ConceptProxies.Minor_Spirit | Proxies.ConceptProxies.Structure_StoneBuilding | Proxies.ConceptProxies.Structure_CompoundBuilding))
                    { WordList.RemoveAt(i); }
                    break;

            }


        }
        if(WordList.Count > 0)
        {
        for (int j = 0; j < NumberOfWords; j++)
        {
            //Debug.Log(j);
            WordArray[j] = WordList[Random.Range(0, WordList.Count)];
        }
        }
        else
        {
            Debug.Log("ERROR NO WORDS FOUND");
            Debug.Log("Prox = " + Prox);
           


        }
    }
    private void GetWordListBySub(DataStorage.ConceptTypes Concept,DataStorage.SubConceptTypes WordType, LangGroupClass LGC, int NumberOfWords, out WordClass[] WordArray,WordClass OutputWord)
    {
        //Debug.Log("Log");
        //Debug.Log("Getting " + WordType + " From " + LGC.name + " , " + NumberOfWords + " Words ");

        List<WordClass> TempWordList = new List<WordClass>(); //TemporaryWordList with some randomly chosen Words of type Word Type
        List<WordClass> Words = new List<WordClass>(); // Word List with all Words of Type WordType 
        Proxies.ConceptProxies Proxie = OutputWord.RealProxie; //Not The Functions output, but the function callers data output
        
        switch (Concept)
        {
            case ConceptTypes.Entity:
                for (int k = 0; k < LGC.Word_Ent.Length; k++)
                {
                    if (LGC.Word_Ent[k].GetMySubConceptType() == WordType)
                    {
                        Words.Add(LGC.Word_Ent[k]);
                    }

                }
                break;
            case ConceptTypes.Object:
                for (int k = 0; k < LGC.Word_Obj.Length; k++)
                {
                    if (LGC.Word_Obj[k].GetMySubConceptType() == WordType)
                    {
                        Words.Add(LGC.Word_Obj[k]);
                    }

                }
                break;
            case ConceptTypes.Location:
                for (int k = 0; k < LGC.Word_Loc.Length; k++)
                {
                    if (LGC.Word_Loc[k].GetMySubConceptType() == WordType)
                    {
                        Words.Add(LGC.Word_Loc[k]);
                    }

                }
                break;
        }
        
        if(Words.Count == 0)
        {
            Debug.LogError("NO WORDS OUTPUTED");
        }
        int Count = 0;
        
        if(Proxie != Proxies.ConceptProxies.Null)
        {
            FilterByProxy(Proxie, Words, out WordArray, NumberOfWords);
        }
        else
        {
            while (Count < NumberOfWords && Words.Count > 0)
            {
                int RNG = Random.Range(0, Words.Count);
                TempWordList.Add(Words[RNG]);
                Count++;
                Words.RemoveAt(RNG);
            }
            WordArray = new WordClass[TempWordList.Count];
            for (int i = 0; i < TempWordList.Count; i++)
            {
                WordArray[i] = TempWordList[i];
            }
            // Debug.Log("Loged Words = " + WordCount);
        }

    }

    public void AddCoins(int Value)
    {
           if (Value > 0)
            PlayerCoins += Value;
        UpdateCoins();
    }
    public void RemoveCoins(int Value)
    {
        if(Value > 0)
        PlayerCoins -= Value;
        if(PlayerCoins < 0)
        {
            PlayerCoins = 0;
        }
        UpdateCoins();
    }
    public int GetCoinsValue()
    {
        return PlayerCoins;
    }
    private void UpdateCoins()
    {
        CoinsDisplay.text = "Coins: "+ PlayerCoins.ToString();
    }
}
