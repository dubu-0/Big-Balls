using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Emitter : MonoBehaviour
{
    [SerializeField] private Ball ballPrefab;
    [SerializeField] private float rate = 3;
    
    private float _leftXBound;
    private float _rightXBound;
    private float _expiredTime;

    private void Start()
    {
        var bounds = GetComponent<SpriteRenderer>().bounds;
        _leftXBound = bounds.min.x;
        _rightXBound = bounds.max.x;
    }

    private void Update()
    {
        _expiredTime += Time.deltaTime;

        if (_expiredTime >= 1 / rate)
        {
            Emit();
            _expiredTime = 0;
        }
    }

    private void Emit()
    {
        var spawnPosition = new Vector2(GetRandomX(), transform.position.y);
        var ball = Instantiate(ballPrefab, spawnPosition, Quaternion.identity);

        ball.transform.parent = transform;
    }

    private float GetRandomX() => Random.Range(_leftXBound, _rightXBound);
}
