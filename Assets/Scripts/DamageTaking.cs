using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTaking : MonoBehaviour
{
    public int hitPoints = 10;

    public GameObject destructionPrefab;

    public bool gameOverOnDestroy = false;

    public void TakeDamage(int amount) {
        Debug.Log(gameObject.name + " is damaged!!");

        hitPoints -= amount;

        if(hitPoints <= 0) {
            Debug.Log(gameObject.name + " is destroyde!!");

            Destroy(gameObject);

            if(destructionPrefab != null) {
                Instantiate(destructionPrefab, transform.position, transform.rotation);
            }

            if(gameOverOnDestroy == true) {
                GameManager.instance.GameOver();
            }
        }
    }
}
