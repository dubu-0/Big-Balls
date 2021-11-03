using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(SpriteRenderer))]
public class Ball : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private int score = 3;
    [SerializeField] private int damage = 1;
    

    private Score _scoreUI;
    private SpriteRenderer _spriteRenderer;
    private Camera _mainCamera;
    
    private void Start()
    {
        _scoreUI = FindObjectOfType<Score>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _mainCamera = Camera.main;
        
        Init();
    }

    private void Update()
    {
        MoveDown();
    }

    private void OnMouseDown()
    {
        _scoreUI.Add(score);
        Destroy(gameObject);
    }

    public int GetDamage() => damage;

    private void Init()
    {
        _spriteRenderer.color = GetRandomColor();
        speed = GetRandomSpeed();
        transform.localScale *= GetRandomScale();
        damage = GetRandomDamage();
        score = GetRandomScore();
    }

    private void MoveDown()
    {
        var current = transform.position;
        var target = new Vector3(current.x, -5f);
        var maxDistanceDelta = speed * Time.deltaTime;
        
        transform.position = Vector3.MoveTowards(current, target, maxDistanceDelta);
    }

    private Color GetRandomColor()
    {
        var r = Random.Range(0f, 1f);
        var g = Random.Range(0f, 1f);
        var b = Random.Range(0f, 1f);
        var a = Random.Range(0.6f, 0.95f);

        return new Color(r, g, b, a);
    }

    private float GetRandomSpeed() => Random.Range(0.2f, 0.8f) * 1 / ((int)transform.localScale.x + 0.1f);

    private float GetRandomScale() => Random.Range(0.3f, 3.5f);
    private int GetRandomDamage() => Random.Range(1, 3) + (int)transform.localScale.x;
    private int GetRandomScore()
    {
        var multiplier = speed - transform.localScale.x;
        
        if (multiplier < 1) 
            multiplier = 1;

        return Random.Range(1, 5) * (int)multiplier;
    }
}
