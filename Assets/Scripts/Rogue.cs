using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Rogue : MonoBehaviour
{
    [SerializeField] private Sprite _front;
    [SerializeField] private Sprite _back;
    [SerializeField] private float _speed;

    private SpriteRenderer _renderer;
    private Vector3 _direction;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        TurnToTop();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Chest>(out _))
        {
            TurnToDown();
        }
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(_speed * Time.deltaTime * _direction);
    }

    private void TurnToTop()
    {
        _direction = Vector3.up;
        _renderer.sprite = _back;
    }

    private void TurnToDown()
    {
        _direction = Vector3.down;
        _renderer.sprite = _front;
    }
}
