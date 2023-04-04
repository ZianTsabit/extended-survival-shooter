using UnityEngine;

public class HealerPet : MonoBehaviour
{
    public float speed = 3f;             
    //public float healInterval = 10f;     
    //public int maxHealth = 150;           
    public float stoppingDistance = 2f;
    public float enemyAvoidanceDistance = 3f;
    private Transform player;            
    private float timeSinceLastHeal;     
    public int currentHealth;           

    void Start()
    {
        // cari player
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // initialize  current health 
        currentHealth = 150;
    }

    void Update()
    {
        // Berjalan ke arah player
        if (currentHealth > 0 && Vector3.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }

        AvoidEnemies();
    }

    void FixedUpdate()
    {
        if (currentHealth > 0 && Time.time - timeSinceLastHeal > 3)
        {
            // mencari komponen health player
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

            // Heal
            playerHealth.currentHealth += 8;
            playerHealth.currentHealth = Mathf.Clamp(playerHealth.currentHealth, 0, playerHealth.startingHealth);

            // update the player's health slider
            playerHealth.healthSlider.value = playerHealth.currentHealth;

            // reset the time since last heal
            timeSinceLastHeal = Time.time;
        }
    }

    void AvoidEnemies()
    {
        // Mendapatkan semua enemies
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // Mendapatkan enemy terdekat
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
            transform.position += direction.normalized * speed * Time.deltaTime;
        }
    }
   
    public void TakeDamage(int damage)
    {
        // kurangi current health
        currentHealth -= damage;

        // mati
        if (currentHealth <= 0)
        {
             
            speed = 0;

            // Death Animation

            // destroy the Pet
            Destroy(gameObject, 2f);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        // Takes Damage jika collide
        if (other.gameObject.tag == "Enemy")
        {
            TakeDamage(other.gameObject.GetComponent<EnemyAttack>().attackDamage);
        }
    }
    
}