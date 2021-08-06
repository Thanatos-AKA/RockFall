using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoard : MonoBehaviour
{
    private Quaternion orientate2;
    private Vector3 newDirection;
    void Update()
    {
        if(Input.GetKey(KeyCode.W)) {
            orientate2 = Quaternion.Euler(0.3f * Vector3.left);
        }
        if(Input.GetKey(KeyCode.S)) {
            orientate2 = Quaternion.Euler(0.3f * Vector3.right);
        }
        if(Input.GetKey(KeyCode.A)) {
            orientate2 = Quaternion.Euler(0.3f * -Vector3.up);
        }
        if(Input.GetKey(KeyCode.D)) {
            orientate2 = Quaternion.Euler(0.3f * -Vector3.down);
        }

        if(Input.GetKeyUp(KeyCode.W)) {
            newDirection = transform.eulerAngles;
            newDirection.x = 0.0f;
            newDirection.y = 0.0f;
            newDirection.z = 0.0f;
            orientate2 = Quaternion.Euler(newDirection);
        }
        if(Input.GetKeyUp(KeyCode.S)) {
            newDirection = transform.eulerAngles;
            newDirection.x = 0.0f;
            newDirection.y = 0.0f;
            newDirection.z = 0.0f;

            orientate2 = Quaternion.Euler(newDirection);
        }
        if(Input.GetKeyUp(KeyCode.A)) {
            newDirection = transform.eulerAngles;
            newDirection.x = 0.0f;
            newDirection.y = 0.0f;
            newDirection.z = 0.0f;

            orientate2 = Quaternion.Euler(newDirection);
        }
        if(Input.GetKeyUp(KeyCode.D)) {
            newDirection = transform.eulerAngles;
            newDirection.x = 0.0f;
            newDirection.y = 0.0f;
            newDirection.z = 0.0f;

            orientate2 = Quaternion.Euler(newDirection);
        }

        transform.rotation *= orientate2;

        newDirection = transform.eulerAngles;
        newDirection.z = 0.0f;
        transform.rotation = Quaternion.Euler(newDirection);
    }
}
