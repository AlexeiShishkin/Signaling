using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Chest : MonoBehaviour
{
    [SerializeField] private Sprite _opened;

    private SpriteRenderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _renderer.sprite = _opened;
    }
}
