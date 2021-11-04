using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class ExplosionFx : MonoBehaviour
{
    [SerializeField] private ParticleSystem myParticleSystem;

    private Ball.Ball _ball;
    
    private void Start()
    {
        if (_ball)
        {
            ChangeFxColorTo(_ball);
            ChangeParticlesSizeTo(_ball);
        }
    }

    public void SetBall(Ball.Ball ball) => _ball ??= ball;
    
    public void Play(Vector2 position)
    {
        var clone = Instantiate(myParticleSystem, position, Quaternion.identity);
        clone.Play();
        Destroy(clone.gameObject, clone.main.startLifetime.constantMax);
    }

    private void ChangeFxColorTo(Ball.Ball ball)
    {
        var mainModule = myParticleSystem.main;
        mainModule.startColor = ball.BallStatsProvider.Color;   
    }

    private void ChangeParticlesSizeTo(Ball.Ball ball)
    {
        transform.localScale *= ball.BallStatsProvider.Diameter / 2;
    }
}
