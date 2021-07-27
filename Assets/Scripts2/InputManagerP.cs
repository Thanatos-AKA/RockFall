using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManagerP : SingletonP<InputManagerP>
{
    //for joystick
    public VirtualJoystick steering;

    //for weapons
    public GameObject shotPrefab;
    public ShipWeaponsP currentWeapons;
    public float fireRate = 0.2f;
    private bool isFiring = false;

    public void SetWeapons(ShipWeaponsP weapons) {
        currentWeapons = weapons;
    }

    public void RemoveWeapons(ShipWeaponsP weapons) {
        if(currentWeapons == weapons) {
            currentWeapons = null;
        }
    }

    public void StartFiring() {
        StartCoroutine(FireWeapons());
    }

    IEnumerator FireWeapons() {
        isFiring = true;

        while(isFiring) {
            if(currentWeapons != null) {
                Fire();
            }
        }

        yield return new WaitForSeconds(fireRate);
    }

    public void Fire() {
        for(int i = 0; i < currentWeapons.firePoints.Length; i++) {
            var firePointToUse = currentWeapons.firePoints[i];
            Instantiate(shotPrefab, firePointToUse.position, firePointToUse.rotation);
        }
    }

    public void StopFiring() {
        isFiring = false;
    }
}
