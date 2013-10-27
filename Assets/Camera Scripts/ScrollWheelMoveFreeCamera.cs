using UnityEngine;
using System.Collections;

public class ScrollWheelMoveFreeCamera : MonoBehaviour
{
	public float AccelerationFactor = 1.0F;
	public float MinAcceleration = 10.0F;
	public float MaxAcceleration = 1000.0F;
	public float MaxSpeed = 5.0F;

	// Update is called once per frame
	void Update () {
		float acceleration = Input.GetAxis("Mouse ScrollWheel");

		float inclination = (transform.localEulerAngles.x) * Mathf.Deg2Rad;
		float polar = (transform.localEulerAngles.y + 90.0f) * Mathf.Deg2Rad;
		Vector3 directionNormal = new Vector3(
			Mathf.Cos(polar) * Mathf.Cos(inclination),
			Mathf.Sin(inclination),
			Mathf.Sin(polar) * Mathf.Cos(inclination)
			);

		float existingVelocityFactor = Mathf.Clamp(
			transform.rigidbody.velocity.magnitude * AccelerationFactor,
			MinAcceleration,
			MaxSpeed
			);

		transform.rigidbody.velocity += directionNormal * acceleration * Time.deltaTime * existingVelocityFactor;
		if (acceleration != 0.0F)
			acceleration = 0.0F;
	}
}
