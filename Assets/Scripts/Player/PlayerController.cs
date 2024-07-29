using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D player;
    public float speed = 12;
    private HealthBar healthBar;
    public AudioManager audioManager;

    void Start() {
        healthBar = FindObjectOfType<HealthBar>();
        healthBar.SetMaxHealth(GameManager.Instance.PlayerHealth);
        audioManager = FindObjectOfType<AudioManager>();
    }
    void Update()
    {
        CollisionLimiter();
    }
    void FixedUpdate()
    {
        PlayerSpeed();
    }

    public void TakeDamage(int damage) { 
        GameManager.Instance.PlayerHealth -= damage;
        healthBar.SetHealth(GameManager.Instance.PlayerHealth);
    }
    public void OnDie() {
        if(GameManager.Instance.PlayerHealth <= 0) {
            audioManager.DeathSound();
            Time.timeScale = 0;
        }
    }
    public void PlayerSpeed() {
        var direction = Input.GetAxis("Horizontal");
        var velocity = new Vector2(direction * speed, 0);
        player.velocity = velocity;
    }
    public void CollisionLimiter() {
        float collisionLimiter = GameManager.Instance.GameWidth / 2;

        if(transform.position.x  < -collisionLimiter) {
            transform.position =  new Vector2(-collisionLimiter, transform.position.y);
        }else if(transform.position.x > collisionLimiter) {
            transform.position = new Vector2(collisionLimiter, transform.position.y);

        }
    }
}
