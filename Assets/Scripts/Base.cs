using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    private LevelController lvlController;

    private void Start()
    {
        lvlController = FindObjectOfType<LevelController>();
        if (!lvlController)
        {
            Debug.LogError("Base could not get LvlController");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Attacker>())
        {
            lvlController.LoseLife();
        }
    }
}
