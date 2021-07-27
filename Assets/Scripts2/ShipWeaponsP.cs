using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipWeaponsP : MonoBehaviour
{
    public Transform[] firePoints;

    private void Awake() {
        InputManagerP.instance.SetWeapons(this);
    }

    private void OnDestroy() {
        if(Application.isPlaying == true) {
            InputManagerP.instance.RemoveWeapons(this);
        }
    }
}
