using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BuffPet : MonoBehaviour
{
    public float stoppingDistance = 4f;
    public float enemyAvoidanceDistance = 3f;
    private Transform player;
    private NavMeshAgent navMeshAgent;
    public int currentHealth;
    private WeaponHolder weaponHolder;

    // Bonus damage 
    public int bonusDamage = 10;

    void Awake()
    {
        // Cari player
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // NavMeshAgent component
        navMeshAgent = GetComponent<NavMeshAgent>();

        // urrent health
        currentHealth = 150;

        // WeaponHolder
        weaponHolder = GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponHolder>();
    }

    void Update()
    {
        if (currentHealth > 0)
        {
            navMeshAgent.SetDestination(player.position);

            // Melihat Player
            transform.LookAt(player.position);

            // add bonus damage 
            WeaponHolder.bonusDamage = bonusDamage;
        }
        
        // Menghindar
        AvoidEnemies();
    }


    void AvoidEnemies()
    {
        // Get all enemies
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // Cari enemy terdekat
        GameObject closestEnemy = null;
        float closestDistance = float.MaxValue;
        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < closestDistance)
            {
                closestEnemy = enemy;
                closestDistance = distance;
            }
        }

        // Mejauhi Musuh
        if (closestEnemy != null && closestDistance < enemyAvoidanceDistance)
        {
            Vector3 direction = transform.position - closestEnemy.transform.position;
            navMeshAgent.Move(direction.normalized * navMeshAgent.speed * Time.deltaTime);
        }
    }

    public void TakeDamage(int damage)
    {
        // Mengurangi health jika terkena collision
        currentHealth -= damage;

        // Mati
        if (currentHealth <= 0)
        {
            navMeshAgent.speed = 0;

            // Death Animation

            // Destroy the pet
            Destroy(gameObject, 2f);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        // Take damage jika colliding
        if (other.gameObject.tag == "Enemy")
        {
            TakeDamage(other.gameObject.GetComponent<EnemyAttack>().attackDamage);
        }
    }
}
