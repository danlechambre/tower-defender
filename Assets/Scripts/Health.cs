using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private GameObject deathVFXprefab;

    [Header("Audio Config")]
    [SerializeField]
    private AudioClip deathSFX;
    [Range(0.0f, 1.0f)]
    [SerializeField]
    private float volume;

    [Header("Health Config")]
    [SerializeField]
    private int startingHealth;
    
    private int currentHealth;
    private bool isDead = false;

    private void Start()
    {
        currentHealth = startingHealth;
    }
    
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth < 1)
        {
            isDead = true;
            if (GetComponent<Defender>())
            {
                GetComponent<Defender>().ReleaseSquare();
            }
        }

        if (isDead)
        {
            DeathSequence();
        }

    }

    private void DeathSequence()
    {
        AudioSource.PlayClipAtPoint(deathSFX, transform.position, volume);
        Vector2 deathVFXPos = (Vector2)transform.position + GetComponent<BoxCollider2D>().offset;
        GameObject deathVFX = Instantiate(deathVFXprefab, deathVFXPos, Quaternion.identity);
        Destroy(deathVFX, 1.0f);
        Destroy(this.gameObject);
    }
}
