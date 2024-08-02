using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            GameManager.Instance.GameOver();
        }
    }

    public void PlayerSpeed() {
        var directionX = Input.GetAxis("Horizontal");
        var directionY = Input.GetAxis("Vertical");
        var velocity = new Vector2(directionX * speed, directionY * speed);
        player.velocity = velocity;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.tag == "BadAsteroid") {
            TakeDamage(10);
        }
    }
}
