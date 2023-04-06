using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMelee : MonoBehaviour
{
    public static int attackDamage = 30;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && !ShopScript.afterQuestShopping)
        {
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(attackDamage, transform.position);
        }
    }
}
