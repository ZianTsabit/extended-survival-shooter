using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMelee : MonoBehaviour
{
    public static int attackDamage = 30;
    public static bool isEquipped = false;

    Animator anim;
    GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = player.GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !ShopScript.afterQuestShopping)
        {
            anim.SetTrigger("Slash");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && !ShopScript.afterQuestShopping)
        {
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(attackDamage + WeaponHolder.bonusDamage, transform.position);
        }
    }
}
