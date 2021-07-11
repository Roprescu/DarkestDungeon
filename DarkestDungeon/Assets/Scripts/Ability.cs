using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    AbilityInfo m_AbilityInfo;

    public Ability(AbilityInfo _info)
    {
        m_AbilityInfo = _info;
    }
}
