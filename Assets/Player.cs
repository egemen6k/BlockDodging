using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 15f;
    private float _mapWidth = 5f;
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        if (_rb == null)
        {
            Debug.LogError("Rigidbody2D is null");
        }
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * _speed;

        Vector2 newPosition = _rb.position + Vector2.right * x;
        newPosition.x = Mathf.Clamp(newPosition.x, -_mapWidth, +_mapWidth);
        _rb.MovePosition(newPosition);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        FindObjectOfType<GameManager>().EndGame();
    }
}
