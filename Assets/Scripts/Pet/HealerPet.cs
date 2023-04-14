using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealerPet : MonoBehaviour
{
    public float stoppingDistance;
    public float enemyAvoidanceDistance;
    private Transform player;
    private float timeSinceLastHeal;
    public static int currentHealth = 150;

    private AudioSource healAudio;
    private AudioSource hurtAudio;
    private Animator animator;
    private UnityEngine.AI.NavMeshAgent navMeshAgent;

    void Awake()
    {
        // Cari player
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Get the NavMeshAgent component
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        // Audio
        AudioSource[] audioSources = GetComponents<AudioSource>();

        healAudio = audioSources[0];
        hurtAudio = audioSources[1];

        //Animation
        animator = GetComponent<Animator>();

        stoppingDistance = 3f;
        enemyAvoidanceDistance = 4f;
        navMeshAgent.speed = 2.5f;
    }

    void Update()
    {
        // move towards player
        if (currentHealth > 0 && Vector3.Distance(transform.position, player.position) > stoppingDistance)
        {
            // Melihat Player
            transform.LookAt(player.position);

            // Berjalan ke Player
            navMeshAgent.SetDestination(player.position);
        }
        else if (currentHealth <= 0){
            KillPet();
        }

        // Menghindar
        AvoidEnemies();

    }

    void FixedUpdate()
    {
        if (currentHealth > 0 && Time.time - timeSinceLastHeal > 10)
        {
            //  Player health component
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

            // Play Audio
            healAudio.Play();

            // Heal
            playerHealth.currentHealth += 8;
            playerHealth.currentHealth = Mathf.Clamp(playerHealth.currentHealth, 0, playerHealth.startingHealth);

            // Update health slider
            playerHealth.healthSlider.value = playerHealth.currentHealth;

            // Reset the time since last heal
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
        hurtAudio.Play();

        // Mati
        if (currentHealth <= 0)
        {
            navMeshAgent.speed = 0;

            // Destroy the pet
            //Destroy(gameObject, 2f);
            ShopManager.isHavePet = false;
            ShopManager.isHaveHealer = false;
        }
    }

    void KillPet()
    {
        // Destroy the pet
        animator.SetTrigger("Die");
        Invoke("DestroyPet", 4f);
        Destroy(gameObject, 2f);
        ShopManager.isHavePet = false;
        ShopManager.isHaveHealer = false;
    }

    void OnCollisionEnter(Collision other)
    {
        // Take damage jika colliding
        if (other.gameObject.tag == "Enemy")
        {
            TakeDamage(EnemyAttack.attackDamage);
        }
    }
}



