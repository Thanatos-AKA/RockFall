using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollowP : MonoBehaviour
{
    public Transform target;
    public float distance = 10.0f;
    public float height = 3.5f;
    public float damping = 1.0f;

    private void LateUpdate() {
        var wantedRotationX = target.transform.eulerAngles.x;
        var wantedRotationY = target.transform.eulerAngles.y;
        var wantedPosition = target.position;
        var currentRotationX = this.transform.eulerAngles.x;
        var currentRotationY = this.transform.eulerAngles.y;

        currentRotationX = Mathf.LerpAngle(currentRotationX, wantedRotationX, damping * Time.deltaTime);
        currentRotationY = Mathf.LerpAngle(currentRotationY, wantedRotationY, damping * Time.deltaTime);

        var currentRotation = Quaternion.Euler(currentRotationX, currentRotationY, 0);

        this.transform.position = target.position + currentRotation * Vector3.back * distance + currentRotation * Vector3.up * height;

        this.transform.rotation = currentRotation;
    }
}
