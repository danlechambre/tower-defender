using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] 
    GameObject projectilePrefab;
    [SerializeField]
    AudioClip projectileSFX;
    Transform projectileParent;

    Animator anim;
    AudioSource audio;

    [SerializeField]
    Vector2 projectileOffset;
    
    Vector2 shooterPos;
    int lane;

    private void Start()
    {
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        projectileParent = GameObject.Find("Projectiles").transform;

        shooterPos = (Vector2)transform.position + projectileOffset;
    }

    private void Update()
    {
        if (IsAttackerInLane())
        {
            if (!anim.GetBool("isAttacking"))
            {
                anim.SetBool("isAttacking", true);
            }
        }
        else
        {
            if (anim.GetBool("isAttacking"))
            {
                anim.SetBool("isAttacking", false);
            }
        }
    }

    private bool IsAttackerInLane()
    {
        Attacker[] attackers = FindObjectsOfType<Attacker>();
        foreach (Attacker attacker in attackers)
        {
            int attackerLane = attacker.GetLane();
            if (attackerLane == this.lane)
            {
                return true;
            }
        }

        return false;
    }

    public void SetLane(int lane)
    {
        this.lane = lane;
    }

    public void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, shooterPos, Quaternion.identity);
        projectile.transform.parent = projectileParent;
        projectile.tag = this.tag;

        audio.clip = projectileSFX;
        audio.Play();
    }
}
