using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteriod : MonoBehaviour
{
    public float speed = 10.0f;
    private void Start() {
        //Because it has rigidbody, use velocity to move it.
        GetComponent<Rigidbody>().velocity = transform.forward * speed;

        //Indicator
        var indicator = IndicatorManager.instance.AddIndicator(gameObject, Color.red);
        indicator.showDistanceTo = GameManager.instance.currentStation.transform;

    }
}
