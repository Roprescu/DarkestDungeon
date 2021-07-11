using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityDrawer : MonoBehaviour
{
    [SerializeField]
    Transform m_Ability_1;
    [SerializeField]
    Transform m_Ability_2;
    [SerializeField]
    Transform m_Ability_3;
    [SerializeField]
    Transform m_Ability_4;
    Dictionary<int, Transform> m_AbilitiesDict;

    void Awake()
    {
        m_AbilitiesDict = new Dictionary<int, Transform>();
        m_AbilitiesDict.Add(1, m_Ability_1);
        m_AbilitiesDict.Add(2, m_Ability_2);
        m_AbilitiesDict.Add(3, m_Ability_3);
        m_AbilitiesDict.Add(4, m_Ability_4);
    }

    public void DrawAbilities(Combatant _combatant)
    {
        List<AbilityInfo> abilityList = Library.instance.GetAbilitiesInfo(_combatant.GetHeroType());
        int i = 1;
        foreach (AbilityInfo ability in abilityList)
        {
            m_AbilitiesDict[i].GetComponent<SpriteRenderer>().sprite = ability.m_Sprite;
            ++i;
        }
    }
}
