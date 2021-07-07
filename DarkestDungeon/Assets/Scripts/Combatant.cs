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
    Transform m_YourTurnUI;
    [SerializeField]
    int m_Speed;
    [SerializeField]
    int m_HP;
    [SerializeField]
    int m_MaxHP;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
}
