using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int enemyType;
    public int startingHealth = 100;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    public int scoreValue = 10;
    public AudioClip deathClip;


    Animator anim;
    AudioSource enemyAudio;
    ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;
    bool isDead;
    bool isSinking;


    void Awake()
    {
        //Mendapatkan reference komponen
        anim = GetComponent<Animator>();
        enemyAudio = GetComponent<AudioSource>();
        hitParticles = GetComponentInChildren<ParticleSystem>();
        capsuleCollider = GetComponent<CapsuleCollider>();

        //Set current health
        currentHealth = startingHealth;
    }


    void Update()
    {
        //Check jika sinking
        if (isSinking)
        {
            //memindahkan object kebawah
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }


    public void TakeDamage(int amount, Vector3 hitPoint)
    {
        //Check jika dead
        if (isDead)
            return;

        //play audio
        enemyAudio.Play();

        //kurangi health
        currentHealth -= amount;

        //Ganti posisi particle
        hitParticles.transform.position = hitPoint;

        //Play particle system
        hitParticles.Play();

        //Dead jika health <= 0
        if (currentHealth <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        //set isdead
        isDead = true;

        //SetCapcollider ke trigger
        capsuleCollider.isTrigger = true;

        //trigger play animation Dead
        anim.SetTrigger("Dead");

        //Play Sound Dead
        enemyAudio.clip = deathClip;
        enemyAudio.Play();
    }

    public void StartSinking()
    {
        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        isSinking = true;
        MoneyManager.money += scoreValue;

        int sceneIdx = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;

        if (sceneIdx == 2) // Level_1
        {
            if (enemyType == 0) Zombunny_1.enemyKilled++;

            if (Zombunny_1.enemyKilled == Zombunny_1.targetKill) ShopManager.afterQuestShopping = true;
            
        } else if (sceneIdx == 3) // Level_2
        {
            if (enemyType == 0) Zombunny_2.enemyKilled++;
            else if (enemyType == 1) Zombear_2.enemyKilled++;

            if (Zombunny_2.enemyKilled >= Zombunny_2.targetKill && Zombear_2.enemyKilled >= Zombear_2.targetKill) ShopManager.afterQuestShopping = true;
        } else if (sceneIdx == 4) // Level_3
        {
            if (enemyType == 0) Zombunny_3.enemyKilled++;
            else if (enemyType == 1) Zombear_3.enemyKilled++;

            if (Zombunny_3.enemyKilled >= Zombunny_3.targetKill && Zombear_3.enemyKilled >= Zombear_3.targetKill) ShopManager.afterQuestShopping = true;
        } else if (sceneIdx == 6) // Level_4
        {
            if (enemyType == 2) Hellephant_4.enemyKilled++;

            if (Hellephant_4.enemyKilled >= Hellephant_4.targetKill) UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIdx + 1);
        }

        Destroy(gameObject, 2f);
    }
}