using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyLittleBird : MonoBehaviour
{
    public GameManager gameManager;
    public float velocity = 1;
    private Rigidbody2D rb;

    private int _score;
    
    [SerializeField]
    private UIManager _UIManager;

    [SerializeField]
    private float _rotationMultiplier = 3f;

    [SerializeField]
    private float _minRotation = -90f;

    [SerializeField]
    private float _maxRotation = 45f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Jump
            rb.velocity = Vector2.up * velocity;
        }
        float angle = Mathf.Clamp(rb.velocity.y, _minRotation, _maxRotation) * _rotationMultiplier;
        rb.MoveRotation(angle);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameManager.GameOver();
    }

    private void OnBecomeInvisible()
    {
        gameManager.GameOver();
    }

    public void AddScore()
    {
        _score += 1;
        _UIManager.SetScoreText(_score);
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        AddScore();
    }
}
