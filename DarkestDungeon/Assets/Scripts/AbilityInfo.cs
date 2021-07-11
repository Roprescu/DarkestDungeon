using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ATTACK_RANGE
{
    Invalid,
    Melee,
    Ranged
}

public class AbilityInfo : MonoBehaviour
{
    public Sprite m_Sprite;
    public List<int> m_RequiredPosition;
    public List<int> m_Targets;
    public ATTACK_RANGE m_AttackRange;
    public int m_DamageMod = -1;
    public int m_AccuracyMod = -1;
    public int m_CritMod = -1;
}
