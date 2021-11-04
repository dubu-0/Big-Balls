using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(SpriteRenderer))]
public class Ball : MonoBehaviour
{
    [SerializeField] private Color prohibitedColor;
    
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
            _acceleration += 1;
    }

    private Color GetRandomColor()
    {
        const float prohibitedRange = 255 * 0.05f;
        
        var r = Random.Range(0f, prohibitedColor.r - prohibitedRange) + Random.Range(prohibitedColor.r + prohibitedRange, 1f);
        var g = Random.Range(0f, prohibitedColor.g - prohibitedRange) + Random.Range(prohibitedColor.g + prohibitedRange, 1f);
        var b = Random.Range(0f, prohibitedColor.b - prohibitedRange) + Random.Range(prohibitedColor.b + prohibitedRange, 1f);
        var a = Random.Range(0.4f, 0.8f);

        return new Color(r, g, b, a);
    }

    private float GetRandomSpeed() => 1 / ((transform.localScale.y + 0.5f) * 2) + _acceleration;

    private float GetRandomScale() => Random.Range(0.45f, 3.5f);
    private int GetRandomDamage() => Random.Range(1, 3) + (int)transform.localScale.y;
    private int GetRandomScore()
    {
        var score = 5 * _currentSpeed - 18 * transform.localScale.y;
        
        if (score < 1) 
            score = 1;

        Debug.Log((int)score);
        
        return (int)score;
    }
}
