using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class ReverseComparer : IComparer<int>
{
    public int Compare(int x, int y)
    {
        return -x.CompareTo(y);
    }
}

public class BattleManager : MonoBehaviour
{
    [SerializeField]
    List<Combatant> m_SceneCombatants;
    SortedList<int, List<Combatant>> m_CombatantList;
    Queue<Combatant> m_CombatabtQueue;

    void Awake()
    {
        m_CombatantList = new SortedList<int, List<Combatant>>(new ReverseComparer());
        m_CombatabtQueue = new Queue<Combatant>();
        foreach (Combatant combatant in m_SceneCombatants)
        {
            AddCombatant(combatant.GetStat(COMBATANT_STATS.Speed), combatant);
            combatant.SetBattleManagerRef(GetComponent<BattleManager>());
        }

        foreach(KeyValuePair<int, List<Combatant>> combatantPair in m_CombatantList)
        {
            foreach(Combatant combatant in combatantPair.Value)
            {
                m_CombatabtQueue.Enqueue(combatant);
            }
        }
        Combatant firstCombatant = m_CombatabtQueue.Dequeue();
        Debug.Log(firstCombatant.transform.name);
        firstCombatant.TurnHandler();
    }

    public void NotifyTurnEnd()
    {
        if(m_CombatabtQueue.Count == 0)
        {
            //next turn
            return;
        }
        Combatant combatant = m_CombatabtQueue.Dequeue();
        Debug.Log(combatant.transform.name);
        combatant.TurnHandler();
    }

    void AddCombatant(int _speed, Combatant _combatant)
    {
        if(!m_CombatantList.ContainsKey(_speed))
        {
            m_CombatantList[_speed] = new List<Combatant>();
        }
        m_CombatantList[_speed].Add(_combatant);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
