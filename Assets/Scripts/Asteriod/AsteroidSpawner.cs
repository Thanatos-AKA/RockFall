using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public float radius = 250.0f;
    public Rigidbody asteriodPrefab;

    public float spawnRate = 5.0f;
    public float variance = 1.0f;

    public Transform target;
    public bool spawnAsteriod;

    private void Start() {
        StartCoroutine(CreatAsteriods());
    }

    IEnumerator CreatAsteriods() {
        while(true) {
            float nextSpawnTime = spawnRate + Random.Range(-variance, variance);

            yield return new WaitForSeconds(nextSpawnTime);

            yield return new WaitForFixedUpdate();

            CreatNewAsteriod();
        }
    }

    private void CreatNewAsteriod() {
        if(spawnAsteriod == false) {
            return;
        }

        var asteroidPosition = Random.onUnitSphere * radius;

        asteroidPosition.Scale(transform.lossyScale);

        asteroidPosition += transform.position;

        var newAsteriod = Instantiate(asteriodPrefab);

        newAsteriod.transform.position = asteroidPosition;

        newAsteriod.transform.LookAt(target);
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.yellow;

        //tell gizmos to use current scale and position;
        Gizmos.matrix = transform.localToWorldMatrix;

        Gizmos.DrawWireSphere(Vector3.zero, radius);
    }

    public void DestroyAllAsteriods() {
        foreach(var asteriod in FindObjectsOfType<Asteriod>()) {
            Destroy(asteriod.gameObject);
        }
    }
}
