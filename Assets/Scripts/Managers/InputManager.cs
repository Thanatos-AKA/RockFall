//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class InputManager : Singleton<InputManager> {
//    public VirtualJoystick steering;

//    private ShipWeapons currentWeapons;
//    public float fireRate = 0.2f;
//    private bool isFiring = false;

//    public void SetWeapons(ShipWeapons weapons) {
//        this.currentWeapons = weapons;
//    }

//    public void RemoveWeapons(ShipWeapons weapons) {
//        if(this.currentWeapons == weapons) {
//            this.currentWeapons = null;
//        }
//    }

//    public void StartFiring() {
//        StartCoroutine(FireWeapons());
//    }

//    IEnumerator FireWeapons() {
//        isFiring = true;

//        while(isFiring) {
//            if(currentWeapons != null) {
//                currentWeapons.Fire();
//            }

//            yield return new WaitForSeconds(fireRate);
//        }
//    }

//    public void StopFiring() {
//        isFiring = false;
//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager> {
    //for joystick
    public VirtualJoystick steering;

    //for weapons
    public GameObject shotPrefab;
    public float fireRate = 0.2f;
    private ShipWeapons currentWeapons;
    private bool isFiring = false;

    public void SetWeapons(ShipWeapons weapons) {
        currentWeapons = weapons;
    }

    public void RemoveWeapons(ShipWeapons weapons) {
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
            yield return new WaitForSeconds(fireRate);
        }
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