using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Door : MonoBehaviour
{
    [SerializeField] private Sprite _closed;
    [SerializeField] private Sprite _opened;
    [SerializeField] private Signaling _signaling;

    private SpriteRenderer _renderer;
    private bool _isOpen = false;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Open();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (transform.position.y > collision.transform.position.y)
        {
            Close();
        }
    }

    private void Open()
    {
        if (_isOpen == false)
        {
            _isOpen = true;
            _renderer.sprite = _opened;
            _signaling.Play();
        }
    }

    private void Close()
    {
        if (_isOpen)
        {
            _isOpen = false;
            _renderer.sprite = _closed;
            _signaling.Stop();
        }
    }
}
