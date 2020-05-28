using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddKill : MonoBehaviour
{
    public IntSO TotalKills;
    public IntSO RegionKills;
    public bool IsAi;
    public void AddKills()
    {
        if (IsAi)
        {
            RegionKills.Integer += 1;
            TotalKills.Integer += 1;
        }
    }
}
