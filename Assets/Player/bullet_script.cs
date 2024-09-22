using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_script : MonoBehaviour
{
    public GameObject hitEffect;
    public void OnCollisionEnter2D(Collision2D other) {
        GameObject effect = Instantiate(hitEffect, transform.position , Quaternion.identity);




        Zombie_Move enemy = other.gameObject.GetComponent<Zombie_Move>();
        if (enemy != null) {
            enemy.TakeDamage(1);
        }

        Destroy(gameObject);
        Destroy(effect, 2f);
        
    }
}
