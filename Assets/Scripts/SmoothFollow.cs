//TEXT BOOK
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class SmoothFollow : MonoBehaviour {
//    public Transform target;

//    public float height = 5.0f;

//    public float distance = 10.0f;

//    public float rotationDamping;
//    public float heightDamping;

//    void LateUpdate() {
//        if(!target) return;

//        var wantdedRotationAngle = target.eulerAngles.y;
//        var wantedHeight = target.position.y + height;

//        var currentRotationAngle = transform.eulerAngles.y;
//        var currentHeight = transform.position.y;

//        currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantdedRotationAngle, rotationDamping * Time.deltaTime);
//        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

//        var currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

//        transform.position = target.position - currentRotation * Vector3.forward * distance;
//        transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);
//        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, rotationDamping * Time.deltaTime);
//    }
//}

//NO damping
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class SmoothFollow : MonoBehaviour {
//    public Transform target;
//    public float height = 3.0f;
//    public float distance = 10.0f;
//    public float positionDamping = 1.0f;
//    public float rotationDamping = 1.0f;

//    private void LateUpdate() {
//        if(target == null)
//            return;

//        var wantedRotation = target.rotation;
//        var wantedPosition = target.position;

//        transform.rotation = wantedRotation;
//        transform.position = wantedPosition - wantedRotation * Vector3.forward * distance + wantedRotation * Vector3.up * height;
//    }
//}

//My damping
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow : MonoBehaviour {
    public Transform target;
    public float height = 5.0f;
    public float distance = 10.0f;
    public float positionDamping = 1.0f;
    public float rotationDamping = 1.0f;

    private void LateUpdate() {
        if(target == null)
            return;

        var wantedRotationX = target.eulerAngles.x;
        var wantedRotationY = target.eulerAngles.y;
        var currentRotationX = this.transform.eulerAngles.x;
        var currentRotationY = this.transform.eulerAngles.y;

        //Debug.Log(target.rotation);

        currentRotationX = Mathf.LerpAngle(currentRotationX, wantedRotationX, rotationDamping * Time.deltaTime);
        currentRotationY = Mathf.LerpAngle(currentRotationY, wantedRotationY, rotationDamping * Time.deltaTime);

        var currentRotation = Quaternion.Euler(currentRotationX, currentRotationY, 0);

        transform.position = target.position - currentRotation * Vector3.forward * distance + currentRotation * Vector3.up * height;
        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, rotationDamping * Time.deltaTime);
    }
}
