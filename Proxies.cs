using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proxies : MonoBehaviour
{
    /*
    Proxies System

    Element Proxies : 

    Base Proxies : Metal , Wood , Hide , Cloth , Liquid , Crystal , Dust , Stone , Bone , Clay , AnimalParts , PlantMatter

    Item Proxies : Tool/Weapon(Metal , Wood, Stone , Bone)*2   Trinket/Carving(Metal , Wood, Stone , Bone,Crystal)*1   Potion/Elixer(Liquid/AnimalParts/PlantMatter)   Clothing/Fabric(Cloth,Hide)

    Compound Proxies : Simple_Storage/Stand(Wood)   Intermediate_Storage/Stand   Complex_Storage/Stand

    Structure Proxies :  PrimitiveStructure(Bone,Wood,Hide)   StoneMainStructure   WoodMainStructure  ComplexMaterialStrut


    EntityMinor Proxies

    EntityCommon Proxies

    EntityHigh Proxies

    LocationSProxies : Wild Rural Urban


    LocationLProxies : S M L

    */

    public enum ConceptProxies
    {
        Null,
        Element,
        Base_Metal, Base_Wood, Base_Bone, Base_Stone, Base_Crystal, Base_Clay, Base_Liquid, Base_Hide, Base_Cloth, Base_AnimalParts, Base_PlantMatter,
        Item_ToolWeapon, Item_Trinket, Item_PotionElixer, Item_ClothingFabric,
        Compound_Simple_StorageStandStrut, Compound_Intermediate_StorageStandStrut, Compound_Complex_StorageStandStrut,
        Structure_PrimitiveBuilding, Structure_StoneBuilding, Structure_WoodBuilding, Structure_CompoundBuilding,
        Minor_Animal, Minor_Spirit, Minor_Plant,
        Common_Humanoid,
        High_King, High_HighSpirit,
        Loc_S_Wild, Loc_S_Rural, Loc_S_Civilized,
        Loc_L_S, Loc_L_M, Loc_L_L, Loc_L,
        Contains_IsMadeOf_Has,ResultsIn, And_AddedTo_JoinedWith, SubtractedFrom_RemovedFrom,Before_Precedes,After_Following,Use_MakeUseOf,Is_ToBe
    }







}
