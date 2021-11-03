using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Ball : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private int score = 3;
    [SerializeField] private int damage = 1;
    [SerializeField] private Color color = Color.blue;

    private Score _scoreUI;
    
    private void Start()
    {
        _scoreUI = FindObjectOfType<Score>();
        GetComponent<SpriteRenderer>().color = color;
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

    private void MoveDown()
    {
        var current = transform.position;
        var target = new Vector3(current.x, -5f);
        var maxDistanceDelta = speed * Time.deltaTime;
        
        transform.position = Vector3.MoveTowards(current, target, maxDistanceDelta);
    }
}
