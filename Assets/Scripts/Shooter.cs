using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] 
    GameObject projectilePrefab;
    [SerializeField]
    Vector2 projectileOffset;

    Animator anim;
    Vector2 shooterPos;
    [SerializeField]
    int lane;

    Transform spawner;

    private void Start()
    {
        spawner = GameObject.Find("Spawner").transform;
        shooterPos = (Vector2)transform.position + projectileOffset;
        
        anim = GetComponent<Animator>();
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
        projectile.tag = this.tag;
    }
}
