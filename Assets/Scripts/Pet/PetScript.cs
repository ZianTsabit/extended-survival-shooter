using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pet;

    void Start()
    {
        pet = GameObject.FindGameObjectWithTag("Pet");
        pet.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ShopManager.isHavePet)
        {
            pet.SetActive(true);
        }
        
    }
}
