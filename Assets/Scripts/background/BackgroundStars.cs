using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundStars : MonoBehaviour
{
    private float cooldown = 0;
    public GameObject starPrefab;
    public float spawnInterval = 0.05f;
    public int numberOfStars = 20;

    void Update()
    {
        cooldown -= Time.deltaTime;

        if (cooldown <= 0f)
        {
            cooldown = spawnInterval;

            var gameManager = GameManager.Instance;
            float y = gameManager.GameHeight / 2;

            Vector2 position = new Vector2(10, Random.Range(-y, y));
            Instantiate(starPrefab, position, Quaternion.identity);
        }
    }
}
