using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime);

        if (transform.position.x < -9)
        {
            Destroy(gameObject);
        }
    }
}
