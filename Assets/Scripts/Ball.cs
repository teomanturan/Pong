using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    public float movementSpeed = 50f;
    float x;
    float y;
    int score = 0;
    [SerializeField] Text scoreText; 

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        StartingBallMovement();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log(collision.collider.tag);
        if (collision.collider.CompareTag("Player"))
        {
            score++;
            scoreText.text = score.ToString();
            x = -x;
            movementSpeed = movementSpeed + 5;
            rb.AddForce(new Vector2 (x, y));
        }
    }

    #region Top Baslangic Hareketi
    void StartingBallMovement()
    {
        x = UnityEngine.Random.value < 0.5f ? -1.0f : 1.0f;
        y = UnityEngine.Random.value < UnityEngine.Random.value ? UnityEngine.Random.Range(-1.0f, -0.5f) : UnityEngine.Random.Range(1.0f, 0.5f);

        rb.AddForce(new Vector2 (x, y) * movementSpeed);
    }
    #endregion
}
