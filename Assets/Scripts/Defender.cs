using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [Header("Defender Config")]
    [SerializeField]
    private int cost = 10;
    [Range(-0.5f, 0.5f)]
    [SerializeField]
    private float yPadding = 0.0f;
    private int rowRef;
    private int colRef;
    private DefenderSpawner dSpawner;

    private void Start()
    {
        dSpawner = FindObjectOfType<DefenderSpawner>();
        if (GetComponent<Shooter>())
        {
            GetComponent<Shooter>().SetLane(rowRef);
        }
    }

    public float GetYPadding()
    {
        return yPadding;
    }

    public int GetCost()
    {
        return cost;
    }

    public void AddStars(int starsToAdd)
    {
        FindObjectOfType<Stars>().AddStars(starsToAdd);
    }

    public void SetGridRef(int rowRef, int colRef)
    {
        this.rowRef = rowRef;
        this.colRef = colRef;
    }
}
