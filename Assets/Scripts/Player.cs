using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public float movementSpeed = 5f;
    public float h;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        h = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        Mover(h);
    }

    #region Hareket Mekaniði
    void Mover(float h)
    {
        rb.velocity = new Vector2 (rb.velocity.x,movementSpeed * h);
    }
    #endregion
}
