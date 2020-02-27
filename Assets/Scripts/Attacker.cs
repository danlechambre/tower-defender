using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    private LevelController levelController;
    private GameObject currentTarget;
    
    private Animator anim;
    private AudioSource audioSource;

    [Header("Attacker Config")]
    [Range(-0.5f, 0.5f)][SerializeField]
    private float yPadding = 0.0f;
    [Header("Audio Config")]
    [SerializeField]
    private AudioClip attackSFX;
    [Range(0f, 1.0f)]
    [SerializeField]
    private float volume;

    private float moveSpeed = 1.0f;
    private int lane;
    

    private void Awake()
    {
        levelController = FindObjectOfType<LevelController>();
        levelController.AttackerSpawned();
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
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

        audioSource.clip = attackSFX;
        audioSource.Play();
        Health health = currentTarget.GetComponent<Health>();
        health.TakeDamage(damage);

    }

    public void CheckForTarget()
    {
        if (!currentTarget)
        {
            anim.SetBool("isAttacking", false);
        }
        else
        {
            return;
        }
    }

    public float GetYPadding()
    {
        return yPadding;
    }

    public void OnDestroy()
    {
        levelController.AttackerKilled();
    }
}
