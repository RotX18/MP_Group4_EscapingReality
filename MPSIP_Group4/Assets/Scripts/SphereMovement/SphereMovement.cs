using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMovement : MonoBehaviour
{

	[SerializeField, Range(0f, 100f)]
	float maxSpeed = 10f;

	[SerializeField, Range(0f, 100f)]
	float maxAcceleration = 10f;

	Vector2 playerInput;
	Vector3 velocity, desiredVelocity;

	Rigidbody body;

	void Awake()
	{
		body = GetComponent<Rigidbody>();
	}
	void Update()
	{

		playerInput.x = Input.GetAxis("Horizontal");
		playerInput.y = Input.GetAxis("Vertical");
		//we do this to prevent the diagonal movement of the player input from exceed the value 
		//we clamp it instead of normalizing it so that free directional
		playerInput = Vector2.ClampMagnitude(playerInput, 1f);

		Vector3 acceleration = new Vector3(playerInput.x, 0f, playerInput.y) * maxSpeed;
		desiredVelocity = new Vector3(playerInput.x, 0f, playerInput.y) * maxSpeed;
	}

	private void FixedUpdate()
	{
		velocity = body.velocity;
		float maxSpeedChange = maxAcceleration * Time.deltaTime;
		velocity.x = Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChange);
		velocity.z = Mathf.MoveTowards(velocity.z, desiredVelocity.z, maxSpeedChange);
		body.velocity = velocity;
	}
}
