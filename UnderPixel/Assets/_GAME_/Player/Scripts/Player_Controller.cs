using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Player_Controller : MonoBehaviour
{
	#region Editor Data
	[Header("Movement Attributes")]
	[SerializeField] float _moveSpeed = 50f;

	[Header("Dependencies")]
	[SerializeField] Rigidbody2D _rb;
	#endregion

	#region Internal Data
	private Vector2 _moveDir = Vector2.zero;
	#endregion

	#region Tick
	private void Update()
	{
		GatherInput();
	}

	private void FixedUpdate()
	{
		MovementUpdata();
	}
	#endregion

	#region Input Logic
	private void GatherInput()
	{
		_moveDir.x = Input.GetAxisRaw("Horizontal");
        _moveDir.y = Input.GetAxisRaw("Vertical");

		print(_moveDir);
    }
	#endregion

	#region Movement Logic
	private void MovementUpdata()
	{
		_rb.velocity = _moveDir * _moveSpeed * Time.fixedDeltaTime;
	}
    #endregion

    #region Collisions
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision involves a specific tag (optional).
        if (collision.gameObject.CompareTag("Collisions"))
        {
            Debug.Log("Player");
        }

        // You can access information about the collision, such as contact points and the other object involved.
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.Log("Collision Contact Point: " + contact.point);
        }

        // You can also access the other GameObject involved in the collision.
        GameObject otherObject = collision.gameObject;
        Debug.Log("Collided with: " + otherObject.name);
    }

    #endregion
}
