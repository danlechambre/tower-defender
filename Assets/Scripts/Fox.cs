using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    private Attacker attacker;
    private Animator anim;

    private void Start()
    {
        attacker = GetComponent<Attacker>();
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject defender = collision.gameObject;

        if (defender.GetComponent<Gravestone>())
        {
            anim.SetTrigger("jumpTrigger");
        }
        else if (defender.GetComponent<Defender>())
        {
            attacker.Attack(defender);
        }
    }
}
