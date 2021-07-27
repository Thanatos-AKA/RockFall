using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotP : MonoBehaviour {
    public float speed = 300.0f;
    public float life = 5.0f;

    private void Start() {
        Destroy(gameObject, life);
    }

    private void Update() {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
