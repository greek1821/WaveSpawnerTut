using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Spawner : MonoBehaviour
{
    #region NonTut
    public GameObject PrefabToSpawn;
    public bool PlayerSpawn;
    public GameManageer GM;
    #endregion

    GameObject objectSpawned;
    public List<GameObject> Spawnpoints;
    public bool isTriggered;
    bool spawning;
    public int EnemiesToKill;
    int I;
    public float spawntime;
    float spawntimer;
    public List<GameObject> PrefabsSpawned;
    public WaveListSO Waves;
    int SpawnCount;
    Vector3 Spawnpoint;
    public IntSO RegionKills;

    void Start()
    {
        spawning = true;
        I = 0;
       
        if (PlayerSpawn)
        {
            Spawn(PrefabToSpawn);
        }
	}

    private void Update()
    {
        if (!PlayerSpawn)
        {
            if (RegionKills.Integer == EnemiesToKill)
            {
                spawning = true;
            }
        }   
    
        if (spawning)
        {
            SpawnLogic();
        }
       
    }

    void SpawnLogic()
    {
        if (isTriggered)
        {
            SpawnCount = 0;
            spawntimer += Time.deltaTime;
            if (spawntimer > spawntime)
            {
                for (int o = 0; o < Waves.WaveList[I].EnemiesToSpawn.Count; o++)
                {
                    //Debug.Log()
                    //Do Timer
                    Spawn(Waves.WaveList[I].EnemiesToSpawn[o]);
                    //Spawn(PrefabToSpawn);
                    SpawnCount += 1;
                    if (SpawnCount == Waves.WaveList[I].EnemiesInWave)
                    {
                        //StopSpawning
                        RegionKills.Integer = 0;
                        EnemiesToKill = Waves.WaveList[I].EnemiesInWave;
                        Debug.Log(RegionKills.Integer);
                        Debug.Log(EnemiesToKill);
                        spawning = false;
                        spawntimer = 0;
                        I += 1;
                        break;
                    }


                }
            }
        }
    }

    public void Spawn(GameObject PrefabToSpawn)
    {
        if (PlayerSpawn)
        {
            Spawnpoint = Spawnpoints[0].transform.position;
        }
        else
        {
            int ranInt = Random.Range(0, Spawnpoints.Count);
            Spawnpoint = Spawnpoints[ranInt].transform.position;
        }
        objectSpawned = Instantiate(PrefabToSpawn, Spawnpoint, Quaternion.identity);
        PrefabsSpawned.Add(objectSpawned);
        if (!PlayerSpawn)
        {
            objectSpawned.GetComponent<AIPedal>().SetGM(GM);
        }
        GM.SpawnedPedals.Add(objectSpawned);
    }
}
