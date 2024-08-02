using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCollision : MonoBehaviour
{
    private AudioManager audioManager;
    public PlayerController playerController;
    public GameObject impactEffect;
    public Score score;
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        playerController = FindObjectOfType<PlayerController>();
        score = FindObjectOfType<Score>();
    }
    void Update() {
        if(transform.position.x <= -GameManager.Instance.GameWidth / 2 || transform.position.y >= GameManager.Instance.GameHeight / 2) {
            Destroy(gameObject);
        };
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        GameObject asteroids = gameObject;
        switch (other.gameObject.tag)
        {
            case "Bullet":
                Destroy(asteroids);
                Destroy(other.gameObject);
                audioManager.ExplosionSound();
                score.ScoreAdd(10);

                Instantiate(impactEffect, transform.position, transform.rotation);
            break;
            case "Player":
                Destroy(asteroids);
                audioManager.ExplosionSound();
                Instantiate(impactEffect, transform.position, transform.rotation);
                audioManager.DamageSound();
                playerController.TakeDamage(10);
                playerController.OnDie();
            break;
            case "BadAsteroid":
                Destroy(asteroids);
                audioManager.ExplosionSound();
                audioManager.DamageSound();
                score.ScoreAdd(-10);
            break;
        }
    }
}
