using UnityEngine;
using System.Collections;

public class NewtonianBody : MonoBehaviour
{
	public float Density = 100000.0F;
	public float Mass = 1.0F;

	public float Charge = 0.0F;

	public float StrongAttraction = 200.0F;

	public float Volume
	{
		get { return Mass / Density; }
	}

	public float Radius
	{
		get { return Mathf.Pow(Volume / 4.1888F, 1.0F / 3.0F); }
	}

	public NewtonianBody(float density, float mass)
	{
		Density = density;
		Mass = mass;
	}

	public void Absorb(NewtonianBody other)
	{
		Density += other.Density * (other.Mass / (Mass + other.Mass));
	}

	// Update is called once per frame
	void Update()
	{
		rigidbody.mass = Mass;

		float bodyRadius = Radius;
		transform.localScale = new Vector3(bodyRadius, bodyRadius, bodyRadius);
        (collider as SphereCollider).radius = bodyRadius;
	}
}
