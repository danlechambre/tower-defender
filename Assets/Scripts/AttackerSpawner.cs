using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [Header("Obj Refs")]
    [SerializeField] 
    Attacker attackerPrefab;

    [Header("Spawn Config")]
    [SerializeField]
    private float minSpawnDelay = 1.0f;
    [SerializeField]
    private float maxSpawnDelay = 5.0f;
    [Range (-0.5f, 0.5f)][SerializeField]
    private float yPadding = 0.0f;



    bool spawning = true;
    
    IEnumerator Start()
    {
        while (spawning)
        {
            float timeBetweenSpawns = UnityEngine.Random.Range(minSpawnDelay, maxSpawnDelay);
            yield return new WaitForSeconds(timeBetweenSpawns);

            SpawnAttacker();
        }
    }

    private void SpawnAttacker()
    {
        float spawnPosY = (float)UnityEngine.Random.Range(1, 6) + yPadding;
        int lane = (int)spawnPosY;

        Vector2 spawnPos = new Vector2(transform.position.x, spawnPosY);
        Attacker newAttacker = Instantiate(attackerPrefab, spawnPos, transform.rotation);
        newAttacker.SetLane(lane);
        newAttacker.transform.parent = transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
