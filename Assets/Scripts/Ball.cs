using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
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
    Vector2 direction;
    public float coefficient = 0.1f;
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
        if (collision.collider.CompareTag("Player"))
        {
            score++;
            scoreText.text = score.ToString();
            SpeedUp();
        }
        if (collision.collider.CompareTag("DeathZone"))
        {
            rb.velocity = Vector2.zero;
        }
    }
    #region Top Baslangic Hareketi
    void StartingBallMovement()
    {
        x = UnityEngine.Random.value < 0.5f ? -1.0f : 1.0f;
        y = UnityEngine.Random.value < UnityEngine.Random.value ? UnityEngine.Random.Range(-1.0f, -0.5f) : UnityEngine.Random.Range(1.0f, 0.5f);
        direction = new Vector2(x * movementSpeed, y * movementSpeed);

        rb.AddForce(direction);
    }
    #endregion

    #region Hýzlandýrma
    void SpeedUp()
    {
        float tempcoeffx = coefficient;
        float tempcoeffy = coefficient;
        tempcoeffx = rb.velocity.x < 0 ? -tempcoeffx : tempcoeffx;
        tempcoeffy = rb.velocity.y < 0 ? -tempcoeffy : tempcoeffy;
        rb.velocity = new Vector2(rb.velocity.x + tempcoeffx, rb.velocity.y + tempcoeffy);
    }
    #endregion
}
