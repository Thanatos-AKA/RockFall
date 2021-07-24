using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSteeringP : MonoBehaviour
{
    private Vector2 deltaInput;
    private Vector2 steeringInput;
    private Quaternion orientate;
    private Vector3 orientateAngles;
    private Quaternion orientateAdjust;

    public float damping = 1.0f;
    public float turnRate = 1.0f;
    private void Update() {
        deltaInput = InputManager.instance.steering.delta;

        steeringInput.x = -deltaInput.y;
        steeringInput.y = deltaInput.x;
        steeringInput *= turnRate;

        orientate = Quaternion.Euler(steeringInput);

        transform.rotation *= orientate;

        orientateAngles = transform.eulerAngles;
        orientateAngles.z = 0.0f;

        orientateAdjust = Quaternion.Euler(orientateAngles);

        transform.rotation = Quaternion.Slerp(transform.rotation, orientateAdjust, damping * Time.deltaTime);
    }
}
