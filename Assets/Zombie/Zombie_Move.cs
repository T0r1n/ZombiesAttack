using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Move : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform player;
    public float speed = 2f;

    public int health = 50;
    public int reward = 30;

    public Statistic statistic;


    private void Start() {
        player = GameObject.FindWithTag("Player").transform;
        GameObject otherObject = GameObject.Find("Stats");
        statistic = otherObject.GetComponent<Statistic>();
    }
    
    public void TakeDamage(int damage)
    {
        health-=damage;
        if (health <= 0){
            statistic.score += reward;
            Destroy(gameObject);
        }


    }

    void FixedUpdate()
    {
        Vector2 playerPosition = new Vector2(player.position.x, player.position.y);
        Vector2 lookDir = playerPosition - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;

        Vector2 direction = (player.position - transform.position).normalized;
        rb.velocity = direction * speed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            other.gameObject.GetComponent<Shooting>().shoot_A.Stop();
            Debug.Log("Игрок проиграл!");
            statistic.EndGame();
            

            Time.timeScale = 0;

        }

    }


}
