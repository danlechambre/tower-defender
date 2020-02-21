using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    private float moveSpeed = 1.0f;
    [SerializeField]
    private int lane;
    private GameObject currentTarget;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (!anim.GetBool("isAttacking"))
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }
    }

    public void SetMoveSpeed(float speed)
    {
        moveSpeed = speed;
    }

    public void SetLane(int lane)
    {
        this.lane = lane;
    }

    public int GetLane()
    {
        return lane;
    }

    public void Attack(GameObject target)
    {
        currentTarget = target;
        anim.SetBool("isAttacking", true);
    }

    public void StrikeCurrentTarget(int damage)
    {
        if (!currentTarget)
        {
            return;
        }

        Health health = currentTarget.GetComponent<Health>();
        bool isDead = health.TakeDamage(damage);
        Debug.Log(isDead);
        if (isDead)
        {
            anim.SetBool("isAttacking", false);
        }
    }
}
