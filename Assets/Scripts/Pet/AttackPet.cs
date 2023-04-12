using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPet : MonoBehaviour
{
    public float stoppingDistance = 4f;
    public float enemyAvoidanceDistance = 3f;
    public float projectileSpeed = 200f;
    public float timeBetweenAttacks = 3f;
    public int currentHealth = 150;
    public GameObject projectilePrefab;

    private GameObject[] enemies;
    private UnityEngine.AI.NavMeshAgent navMeshAgent;
    private float timeSinceLastAttack;

    void Awake()
    {

        // NavMeshAgent component
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        // Get all enemies
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    void Update()
    {
        // Update tenemy list
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // Mendekati musuh terdekat
        if (currentHealth > 0)
        {
            GameObject closestEnemy = GetClosestEnemy();
            if (closestEnemy != null && Vector3.Distance(transform.position, closestEnemy.transform.position) > stoppingDistance)
            {
                navMeshAgent.SetDestination(closestEnemy.transform.position);
            }
        }

        // Menghindar
        AvoidEnemies();
    }

    void FixedUpdate()
    {
        if (currentHealth > 0 && Time.time - timeSinceLastAttack > timeBetweenAttacks)
        {
            // Menyerang musuh terdekat
            GameObject closestEnemy = GetClosestEnemy();
            if (closestEnemy != null)
            {
                Attack(closestEnemy);
            }

            // Reset the time dari  last attack
            timeSinceLastAttack = Time.time;
        }
    }

    void AvoidEnemies()
    {
        // Cari enemy terdekat
        GameObject closestEnemy = GetClosestEnemy();

        // Mejauhi Musuh
        if (closestEnemy != null && Vector3.Distance(transform.position, closestEnemy.transform.position) < enemyAvoidanceDistance)
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

    GameObject GetClosestEnemy()
    {
        // Cari closest enemy
        GameObject closestEnemy = null;
        float closestDistance = float.MaxValue;
        foreach (GameObject enemy in enemies)
        {   //Jika musuh masih ada
            if (enemy != null) 
            {
                float distance = Vector3.Distance(transform.position, enemy.transform.position);
                if (distance < closestDistance)
                {
                    closestEnemy = enemy;
                    closestDistance = distance;
                }
            }
        }


        return closestEnemy;
    }


    void Attack(GameObject enemy)
    {
        // Instantiate projectile di posisi pet
        GameObject attackProjectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        // Set the projectile's velocity ke arah musuh
        Vector3 direction = (enemy.transform.position - transform.position).normalized;
        attackProjectile.GetComponent<Rigidbody>().velocity = direction * projectileSpeed;

        // projectile's damage
        attackProjectile.GetComponent<AttackProjectile>().damage = 25;

        // Destroy Projectile
        Destroy(attackProjectile, 2f);
    }
}
