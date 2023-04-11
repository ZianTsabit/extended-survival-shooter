using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour {

    [Header("References")]
    [SerializeField] private Transform[] weapons;

    [Header("Keys")]
    [SerializeField] private KeyCode[] keys;

    [Header("Settings")]
    [SerializeField] private float switchTime;
    public static int bonusDamage;

    private int selectedWeapon;
    private float timeSinceLastSwitch;

    private void Start() {
        SetWeapons();
        Select(selectedWeapon);

        timeSinceLastSwitch = 0f;
    }

    private void SetWeapons() {
        weapons = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
            weapons[i] = transform.GetChild(i);

        if (keys == null) keys = new KeyCode[weapons.Length];
    }

    private void Update() {
        int previousSelectedWeapon = selectedWeapon;

        for (int i = 0; i < keys.Length; i++)
            if (Input.GetKeyDown(keys[i]) && timeSinceLastSwitch >= switchTime)
                selectedWeapon = i;

        if (previousSelectedWeapon != selectedWeapon) Select(selectedWeapon);

        timeSinceLastSwitch += Time.deltaTime;
    }

    private void Select(int weaponIndex) {
        int previousSelectedWeapon = selectedWeapon;
        for (int i = 0; i < weapons.Length; i++)
            // check if the child isEquipped
            if (weapons[i].gameObject.name == "Bow" && PlayerBow.isEquipped){
                weapons[i].gameObject.SetActive(i == weaponIndex);
            } else if (weapons[i].gameObject.name == "Sword" && PlayerMelee.isEquipped){
                weapons[i].gameObject.SetActive(i == weaponIndex);
            } else if (weapons[i].gameObject.name == "Rifle" && PlayerShooting.isEquipped){
                weapons[i].gameObject.SetActive(i == weaponIndex);
            } else if (weapons[i].gameObject.name == "Shotgun" && PlayerShotgun.isEquipped){
                weapons[i].gameObject.SetActive(i == weaponIndex);
            }

        timeSinceLastSwitch = 0f;
        OnWeaponSelected();
    }

    private void OnWeaponSelected() {  }
}