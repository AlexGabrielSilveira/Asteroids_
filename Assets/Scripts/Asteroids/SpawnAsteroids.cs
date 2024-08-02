using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class SpawnAsteroids : MonoBehaviour
{
    public List<GameObject> Asteroids;
    private float interval = 0.55f;
    public float cooldown;
    
    void Update()
    {
        cooldown -= Time.deltaTime;

        if(cooldown < 0) {
            cooldown = interval;

            int asteroidsIndex = Random.Range(0, Asteroids.Count);
            GameObject Asteroid = Asteroids[asteroidsIndex];
            Quaternion rotation = Asteroid.transform.rotation;

            var X = GameManager.Instance.GameWidth / 2;
            var Y = Random.Range(-GameManager.Instance.GameHeight / 2, GameManager.Instance.GameHeight / 2);
            Vector2 position = new Vector2(X, Y);
            

            Instantiate(Asteroid, position, rotation);  
        }
    }
}
