using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
    Transform pet;
    GameObject petObject;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    UnityEngine.AI.NavMeshAgent nav;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        //Mendapatkan componen reference
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }


    void Update()
    {
        // Placed in update because the existence of Pet is not confirmed
        petObject = GameObject.FindGameObjectWithTag("Pet");
        if (petObject != null) pet = petObject.transform;
        
        
        //Pindah ke player position
        if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0 && !ShopScript.afterQuestShopping && !PlayerHealth.isDead)
        {
            if (pet != null)
            {
                if (Vector3.Distance(transform.position, pet.position) < Vector3.Distance(transform.position, player.position))
                {
                    nav.SetDestination(pet.position);
                }
                else
                {
                    nav.SetDestination(player.position);
                }
            }
            else
            {
                nav.SetDestination(player.position);
            }
        }
        else //Stop moving
        {
            nav.enabled = false;
        }
    }
}