using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : MonoBehaviour
{
    private Attacker attacker;

    private void Start()
    {
        attacker = GetComponent<Attacker>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject defender = collision.gameObject;

        if (defender.GetComponent<Defender>())
        {
            attacker.Attack(defender);
        }
    }
}
