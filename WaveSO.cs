using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
[CreateAssetMenu(fileName = "Integer", menuName = "ScriptableObjects/Objects/Wave")]
public class WaveSO : ScriptableObject
{
    public int EnemiesInWave;
    public List<GameObject> EnemiesToSpawn;
}
