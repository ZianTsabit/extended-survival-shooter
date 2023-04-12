using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealerPet : MonoBehaviour
{
    public float stoppingDistance = 4f;
    public float enemyAvoidanceDistance = 3f;
    private Transform player;
    private float timeSinceLastHeal;
    public int currentHealth;

    public AudioClip deathClip;
    private AudioSource playerAudio;
    private UnityEngine.AI.NavMeshAgent navMeshAgent;

    void Awake()
    {
        // Cari player
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Get the NavMeshAgent component
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        // Initialize current health
        currentHealth = 150;

        // Audio
        playerAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        // move towards player
        if (currentHealth > 0 && Vector3.Distance(transform.position, player.position) > stoppingDistance)
        {
            navMeshAgent.SetDestination(player.position);
        }

        // Menghindar
        AvoidEnemies();
    }

    void FixedUpdate()
    {
        if (currentHealth > 0 && Time.time - timeSinceLastHeal > 3)
        {
            //  player health component
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

            playerAudio.Play();
            // heal
            playerHealth.currentHealth += 8;
            playerHealth.currentHealth = Mathf.Clamp(playerHealth.currentHealth, 0, playerHealth.startingHealth);

            // update health slider
            playerHealth.healthSlider.value = playerHealth.currentHealth;

            // reset the time since last heal
            timeSinceLastHeal = Time.time;
        }
    }

    void AvoidEnemies()
    {
        // Get all enemies
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // Cari closest enemy
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

        // Menjauhi musuh terdekat
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
            ShopManager.isHavePet = false;
            ShopManager.isHaveHealer = false;
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



