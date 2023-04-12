using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject healer;
    public GameObject attacker;
    public GameObject buffAura;

    void Start()
    {
        healer.SetActive(false);

        attacker.SetActive(false);

        buffAura.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ShopManager.isHavePet == true && ShopManager.isHaveHealer == true)
        {
            healer.SetActive(true);
            attacker.SetActive(false);
            buffAura.SetActive(false);
        } else if (ShopManager.isHavePet == true && ShopManager.isHaveAttacker == true)
        {
            healer.SetActive(false);
            attacker.SetActive(true);
            buffAura.SetActive(false);
        } else if (ShopManager.isHavePet == true && ShopManager.isHaveBuffAura == true)
        {
            healer.SetActive(false);
            attacker.SetActive(false);
            buffAura.SetActive(true);
        }
        
    }
}
