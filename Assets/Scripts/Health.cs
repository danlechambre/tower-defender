using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int startingHealth;
    [SerializeField]
    private GameObject deathVFXprefab;

    private int currentHealth;
    private bool isDead = false;

    private void Start()
    {
        currentHealth = startingHealth;
    }

    //public bool IsDead()
    //{
    //    return isDead;
    //}
    
    public bool TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth < 1)
        {
            isDead = true;
        }

        if (isDead)
        {
            DeathSequence();
        }

        return isDead;
    }

    private void DeathSequence()
    {
        Vector2 deathVFXPos = (Vector2)transform.position + GetComponent<BoxCollider2D>().offset;
        GameObject deathVFX = Instantiate(deathVFXprefab, deathVFXPos, Quaternion.identity);
        Destroy(deathVFX, 1.0f);
        Destroy(this.gameObject);
    }
}
