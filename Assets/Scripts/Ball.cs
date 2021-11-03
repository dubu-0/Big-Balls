using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(SpriteRenderer))]
public class Ball : MonoBehaviour
{
    private int _score = 3;
    private int _damage = 1;
    private Score _scoreUI;
    private SpriteRenderer _spriteRenderer;
    private float _currentSpeed;
    private static float _acceleration;
    
    private void Start()
    {
        _scoreUI = FindObjectOfType<Score>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        Init();
        MoveFaster(Time.time);
    }

    private void Update()
    {
        MoveDown();
    }

    private void OnMouseDown()
    {
        _scoreUI.Add(_score);
        Destroy(gameObject);
    }

    public int GetDamage() => _damage;

    private void Init()
    {
        _spriteRenderer.color = GetRandomColor();
        _currentSpeed = GetRandomSpeed();
        transform.localScale *= GetRandomScale();
        _damage = GetRandomDamage();
        _score = GetRandomScore();
    }

    private void MoveDown()
    {
        var current = transform.position;
        var target = new Vector3(current.x, -5f);
        var maxDistanceDelta = _currentSpeed * Time.deltaTime;
        
        transform.position = Vector3.MoveTowards(current, target, maxDistanceDelta);
    }

    private void MoveFaster(float passedTime)
    {
        if ((int)passedTime % 12 == 0)
        {
            _acceleration += 1;
            Debug.Log($"Acceleration: {_acceleration}");
        }
    }

    private Color GetRandomColor()
    {
        var r = Random.Range(0f, 1f);
        var g = Random.Range(0f, 1f);
        var b = Random.Range(0f, 1f);
        var a = Random.Range(0.6f, 0.95f);

        return new Color(r, g, b, a);
    }

    private float GetRandomSpeed() => Random.Range(0.2f, 0.8f) * 1 / ((int)transform.localScale.x + 0.1f) + _acceleration;

    private float GetRandomScale() => Random.Range(0.3f, 3.5f);
    private int GetRandomDamage() => Random.Range(1, 3) + (int)transform.localScale.x;
    private int GetRandomScore()
    {
        var multiplier = _currentSpeed - transform.localScale.x;
        
        if (multiplier < 1) 
            multiplier = 1;

        return Random.Range(1, 5) * (int)multiplier;
    }
}
