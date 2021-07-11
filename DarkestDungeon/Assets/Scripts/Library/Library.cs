using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Library : MonoBehaviour
{
    static public Library instance;
    Dictionary<HERO_TYPE, List<AbilityInfo>> m_HeroesAbilitiesDict;

    void Awake()
    {
        SingletonCLassic();
        SetupDictionaries();
    }

    void SingletonCLassic()
    {
        if (instance != null)
        {
            Debug.LogWarning("Library instantiated twice!!!");
            Destroy(instance);
            return;
        }
        instance = GetComponent<Library>();
    }

    void SetupDictionaries()
    {
        m_HeroesAbilitiesDict = new Dictionary<HERO_TYPE, List<AbilityInfo>>();
        m_HeroesAbilitiesDict.Add(HERO_TYPE.Invalid, transform.Find("Heroes_Info").Find("Invalid_Info").GetComponent<CombatabtDefaultInfo>().m_Abilities);
        m_HeroesAbilitiesDict.Add(HERO_TYPE.Crusader, transform.Find("Heroes_Info").Find("Crusader_Info").GetComponent<CombatabtDefaultInfo>().m_Abilities);
    }

    public List<AbilityInfo> GetAbilitiesInfo(HERO_TYPE _hero)
    {
        return m_HeroesAbilitiesDict[_hero];
    }
}