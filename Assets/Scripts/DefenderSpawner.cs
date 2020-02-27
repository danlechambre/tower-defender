using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    private GameObject defenderPrefab;
    private Stars stars;

    private bool[,] gridRefOccupied;
    private int rows, columns;
    private bool spawning = false;

    private void Start()
    {
        rows = (int)GetComponent<BoxCollider2D>().size.y + 1;
        columns = (int)GetComponent<BoxCollider2D>().size.x + 1;
        gridRefOccupied = new bool[rows, columns];

        stars = FindObjectOfType<Stars>();

        if (!stars)
        {
            Debug.LogError("Could not find Object type Stars");
        }
    }

    private void OnMouseDown()
    {
        if (spawning)
        {
            if (!defenderPrefab)
            {
                return;
            }

            Defender defender = defenderPrefab.GetComponent<Defender>();

            AttemptToPlaceDefender(defender);
        }
    }

    private void AttemptToPlaceDefender(Defender defender)
    {
        int cost = defender.GetCost();

        Vector2 posToSpawn = SpawnPositionFromClick();
        int r = (int)posToSpawn.y;
        int c = (int)posToSpawn.x;

        if (stars.HasEnoughStars(cost) && !gridRefOccupied[r, c])
        {
            stars.SpendStars(cost);
            SpawnDefender(posToSpawn, r, c);
            SetGridRefAsOccupied(r, c);
        }
    }

    private Vector2 SpawnPositionFromClick()
    {
        Vector2 mousePos = Input.mousePosition;
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 posToSpawn = new Vector2(Mathf.Round(worldPos.x), Mathf.Round(worldPos.y));
        return posToSpawn;
    }

    private void SpawnDefender(Vector2 spawnPosition, int rowRef, int colRef)
    {
        float yPadding = defenderPrefab.GetComponent<Defender>().GetYPadding();
        spawnPosition = new Vector2(spawnPosition.x, spawnPosition.y + yPadding);
        GameObject newDefender = Instantiate(defenderPrefab, spawnPosition, Quaternion.identity);
        newDefender.GetComponent<Defender>().SetGridRef(rowRef, colRef);
        newDefender.transform.parent = transform;
    }

    public void SetDefenderPrefab(GameObject defenderPrefab)
    {
        this.defenderPrefab = defenderPrefab;
    }

    public void SetGridRefAsFree(int row, int col)
    {
        gridRefOccupied[row, col] = false;
    }

    public void SetGridRefAsOccupied(int row, int col)
    {
        gridRefOccupied[row, col] = true;
    }

    public void StartSpawning()
    {
        spawning = true;
    }

    public void StopSpawning()
    {
        spawning = false;
    }
}
