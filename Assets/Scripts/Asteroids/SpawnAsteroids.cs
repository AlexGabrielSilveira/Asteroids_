using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class SpawnAsteroids : MonoBehaviour
{
    public List<GameObject> Asteroids;
    public float interval = 1f;
    public float cooldown;
    
    void Update()
    {
        cooldown -= Time.deltaTime;

        if(cooldown < 0) {
            cooldown = interval;

            int asteroidsIndex = Random.Range(0, Asteroids.Count);
            GameObject Asteroid = Asteroids[asteroidsIndex];
            Quaternion rotation = Asteroid.transform.rotation;

            var X = Random.Range(-GameManager.Instance.GameWidth / 2, GameManager.Instance.GameWidth / 2);
            var Y = GameManager.Instance.GameHeight / 2;
            Vector2 position = new Vector2(X, Y);

            Instantiate(Asteroid, position, rotation);  
        }
    }
}
