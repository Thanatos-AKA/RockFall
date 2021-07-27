using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceStationP : MonoBehaviour
{
    private void Start() {
        IndicatorManagerP.instance.AddIndicator(this.gameObject, Color.red);
    }
}
