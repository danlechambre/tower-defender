using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Range(1.0f, 10.0f)]
    [SerializeField]
    float projectileSpeed = 5.0f;
    [SerializeField]
    Vector3 rotation = new Vector3(0f, 0f, 0f);
    [SerializeField]
    int projectileDamage = 50;

    private void Update()
    {
        transform.Translate(Vector2.right * projectileSpeed * Time.deltaTime, Space.World);
        transform.Rotate(rotation, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(this.tag))
        {
            return;
        }

        var health = collision.GetComponent<Health>();

        if (!health)
        {
            Debug.Log("No Health component attached");
        }
        else
        {
            health.TakeDamage(projectileDamage);
        }

        Destroy(this.gameObject);
    }
}
