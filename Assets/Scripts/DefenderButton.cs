using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderButton : MonoBehaviour
{
    [SerializeField]
    private GameObject defenderPrefab;

    private DefenderSpawner defenderSpawner;

    private SpriteRenderer sr;
    private DefenderButton[] buttons;

    private void Start()
    {
        defenderSpawner = FindObjectOfType<DefenderSpawner>();

        sr = GetComponent<SpriteRenderer>();
        buttons = FindObjectsOfType<DefenderButton>();
    }

    private void OnMouseDown()
    {
        SetButtonActive();
        defenderSpawner.SetDefenderPrefab(defenderPrefab);
    }

    private void SetButtonActive()
    {
        foreach (DefenderButton b in buttons)
        {
            b.sr.color = Color.grey;
        }

        sr.color = Color.white;
    }
}
