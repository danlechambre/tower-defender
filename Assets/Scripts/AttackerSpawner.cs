using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [Header("Obj Refs")]
    [SerializeField] 
    Attacker[] attackerPrefabs;

    [Header("Spawn Config")]
    [SerializeField]
    private float levelMinSpawnDelay = 1.0f;
    [SerializeField]
    private float levelMaxSpawnDelay = 5.0f;
    [SerializeField]
    private float minSpawnDelay, maxSpawnDelay;

    IEnumerator spawnAttackers;

    private void Start()
    {
        minSpawnDelay = levelMinSpawnDelay;
        maxSpawnDelay = levelMaxSpawnDelay;
        spawnAttackers = SpawnAttackers();
    }

    IEnumerator SpawnAttackers()
    {
        while (true)
        {
            float timeBetweenSpawns = UnityEngine.Random.Range(minSpawnDelay, maxSpawnDelay);
            yield return new WaitForSeconds(timeBetweenSpawns);

            SpawnAttacker();
        }
    }

    private void SpawnAttacker()
    {
        int attackerIndex = UnityEngine.Random.Range(0, attackerPrefabs.Length);

        float spawnPosY = (float)UnityEngine.Random.Range(1, 6);
        int lane = (int)spawnPosY;

        Vector2 spawnPos = new Vector2(transform.position.x, spawnPosY);
        Attacker newAttacker = Instantiate(attackerPrefabs[attackerIndex], spawnPos, transform.rotation);
        
        Vector3 paddingVector = new Vector3(0, newAttacker.GetYPadding(), 0);
        newAttacker.transform.position += paddingVector;
        
        newAttacker.SetLane(lane);
        newAttacker.transform.parent = transform;
    }

    public void StopSpawning()
    {
        StopCoroutine(spawnAttackers);
    }

    public void StartSpawning()
    {
        StartCoroutine(spawnAttackers);
    }

    public void SetDifficulty(float difficultyMultiplier)
    {
        minSpawnDelay *= difficultyMultiplier;
        maxSpawnDelay *= difficultyMultiplier;
    }
}
