using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private HealthPoints healthPoints;
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        var ball = other.gameObject.GetComponent<Ball>();
        healthPoints.TakeDamage(ball.GetDamage());
        Destroy(ball.gameObject);
    }
}
