using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum COMBATANT_STATS
{
    Invalid,
    Speed
}

public class Combatant : MonoBehaviour
{
    BattleManager m_BattleManagerRef;

    [SerializeField]
    HERO_TYPE m_HeroType;
    [SerializeField]
    Transform m_YourTurnUI;
    [SerializeField]
    int m_Speed;
    [SerializeField]
    int m_HP;
    [SerializeField]
    int m_MaxHP;
    List<Ability> m_AbilitiesList;

    void Awake()
    {
        SetupAbilities();
    }

    void SetupAbilities()
    {
        m_AbilitiesList = new List<Ability>();
        List<AbilityInfo> defaultAbilities = Library.instance.GetAbilitiesInfo(m_HeroType);
        foreach (AbilityInfo ability in defaultAbilities)
        {
            // m_AbilitiesList.Add(new Ability(ability));
        }
    }

    public void TurnHandler()
    {
        m_YourTurnUI.gameObject.SetActive(true);
        StartCoroutine(WaitCourutine());
    }

    IEnumerator WaitCourutine()
    {
        yield return new WaitForSeconds(5);
        m_YourTurnUI.gameObject.SetActive(false);
        m_BattleManagerRef.NotifyTurnEnd();
    }


    public int GetStat(COMBATANT_STATS _stat)
    {
        switch(_stat)
        {
            case COMBATANT_STATS.Speed:
                return m_Speed;
            default:
                Debug.Log("STAT INVALID");
                return -999;
        }
    }

    public void SetBattleManagerRef(BattleManager _ref)
    {
        m_BattleManagerRef = _ref;
    }

    public HERO_TYPE GetHeroType()
    {
        return m_HeroType;
    }
}
