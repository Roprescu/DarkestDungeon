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

    public virtual void TurnHandler()
    {
        
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
}
