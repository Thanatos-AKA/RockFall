//using UnityEngine;
//using System.Collections;

//public class ShipSteering : MonoBehaviour {
//    public float turnRate = 1.0f;
//    public float levelDamping = 1.0f;

//    private void Update() {
//        var steeringInput = InputManager.instance.steering.delta;

//        var rotation = new Vector2();
//        rotation.x = -steeringInput.y;
//        rotation.y = steeringInput.x;
//        rotation *= turnRate;
//        rotation.x = Mathf.Clamp(rotation.x, -Mathf.PI * 0.5f, Mathf.PI * 0.5f);
//        rotation.y = Mathf.Clamp(rotation.y, -Mathf.PI * 0.5f, Mathf.PI * 0.5f);

//        var newOrientation = Quaternion.Euler(rotation);
//        transform.rotation *= newOrientation;

//        var levelAngles = transform.eulerAngles;
//        levelAngles.z = 0.0f;
//        var levelOrientation = Quaternion.Euler(levelAngles);

//        transform.rotation = Quaternion.Slerp(transform.rotation, levelOrientation, levelDamping * Time.deltaTime);

//        Debug.Log(levelAngles.ToString() + " | " + levelOrientation.ToString() + " | " + transform.rotation.ToString());
//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSteering : MonoBehaviour {
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
