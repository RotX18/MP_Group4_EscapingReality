using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMovement : MonoBehaviour
{
    #region private VARS
    [SerializeField, Range(0f, 100f)]
	float maxSpeed = 10f;

	[SerializeField, Range(0f, 100f)]
	float maxAcceleration = 10f;

	Vector2 playerInput;
	Vector3 velocity, desiredVelocity;

	Rigidbody body;
	#endregion

	#region MonoBehaviour functions
	void Awake()
	{
		//defining rigidbody component for physics
		body = GetComponent<Rigidbody>();
	}
	void Update()
	{
        if (!PlayerMovement.IsMoving)
        {
			playerInput.x = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).x;
			playerInput.y = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).y;

			//we do this to prevent the diagonal movement of the player input from exceed the value 
			//we clamp it instead of normalizing it so that it is free directional
			playerInput = Vector2.ClampMagnitude(playerInput, 1f);

			//if needed acceleration can be used to change airmovement but for now there is no air movement so it is commented
			//Vector3 acceleration = new Vector3(playerInput.x, 0f, playerInput.y) * maxSpeed;
		
			//set desiredvelocity to be players input multiplied by maxSpeed
			desiredVelocity = new Vector3(playerInput.x, 0f, playerInput.y) * maxSpeed;

        }
	}

	//in fixedupdate we do physics update here
	private void FixedUpdate()
	{
		//set velocity to be current rigidbody velocity and change it accordingly 
		velocity = body.velocity;

		//max speed change affects how the fast the player can pick up speed when turnning so the more max acceleration the fast it can reach to maxSpeed
		float maxSpeedChange = maxAcceleration * Time.deltaTime;

		//move the x and z velocity towards desired velocity at the rate of maxSpeedChange
		velocity.x = Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChange);
		velocity.z = Mathf.MoveTowards(velocity.z, desiredVelocity.z, maxSpeedChange);

		//set rigidbody velocity to be the velocity after changing
		body.velocity = velocity;
	}
    #endregion
}
