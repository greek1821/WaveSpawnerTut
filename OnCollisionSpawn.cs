using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionSpawn : MonoBehaviour
{
    public BoxCollider Zone;
    public bool Triggered;
    Spawner mySpawner;
    bool RegionEntered;
    public IntSO RegionKills;
    private void Awake()
    {
        mySpawner = GetComponent<Spawner>();
        RegionEntered = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.CompareTag("Player"))
        {
            if(!RegionEntered)
            {
                RegionKills.Integer = 0;
                RegionEntered = true;
            }
            if (!Triggered)
            {
                mySpawner.isTriggered=true;
                Triggered = true;
            }
        }
    }

}
