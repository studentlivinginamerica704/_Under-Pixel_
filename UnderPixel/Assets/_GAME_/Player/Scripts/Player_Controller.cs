using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Player_Controller : MonoBehaviour
{
    private Vector2 moveDir;
    private Rigidbody2D playerRigidbody2D;

    [Header("Movement Attributes")]
    [SerializeField] private float moveSpeed = 5f; // Adjusted variable name for consistency

    [Header("Dependencies")]
    [SerializeField] private Rigidbody2D rb;

    #region Tick
    private void Update()
    {
        GatherInput();
    }

    private void FixedUpdate()
    {
        MovementUpdate();
    }
    #endregion

    #region Input Logic
    private void GatherInput()
    {
        moveDir.x = Input.GetAxisRaw("Horizontal");
        moveDir.y = Input.GetAxisRaw("Vertical");
    }
    #endregion

    #region Movement Logic
    private void MovementUpdate()
    {
        rb.velocity = moveDir * moveSpeed * Time.fixedDeltaTime;
    }
    #endregion

    #region Collisions
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision involves a specific tag (optional).
        if (collision.gameObject.CompareTag("Collisions"))
        {
            // Reset the player's position to the previous frame to prevent moving through the collider.
            transform.position = collision.transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Trigger!");
    }
    #endregion
}
