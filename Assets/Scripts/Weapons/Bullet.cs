using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 10f;
    public Rigidbody2D rb;
    public GameObject bulletPrefab;
    void Start()
    {
        rb.velocity = new Vector2(1, 0) * bulletSpeed;
    }
    void Update() {
        if(transform.position.x >= GameManager.Instance.GameWidth / 2) {
            Destroy(bulletPrefab);
        };
    }

}
