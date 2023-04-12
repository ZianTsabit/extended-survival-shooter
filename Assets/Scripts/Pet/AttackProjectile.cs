using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackProjectile : MonoBehaviour
{
    public int damage = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            EnemyHealth enemy = other.gameObject.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                // Pass the hit point as Vector3.zero since we don't need it in this case
                enemy.TakeDamage(damage, Vector3.zero);
            }
            // Disable the collider to prevent the projectile from affecting the enemy's position
            GetComponent<Collider>().enabled = false;
            // Destroy the projectile after some time
            Destroy(gameObject, 2f);
        }
    }
}