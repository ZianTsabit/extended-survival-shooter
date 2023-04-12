using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMelee : MonoBehaviour
{
    public static int attackDamage = 30;
    public static bool isEquipped = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && !ShopScript.afterQuestShopping)
        {
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(attackDamage + WeaponHolder.bonusDamage, transform.position);
        }
    }
}
