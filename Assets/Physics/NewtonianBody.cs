using UnityEngine;
using System.Collections;

public class NewtonianBody : MonoBehaviour
{
	public float Density = 100000.0F;
	public float Mass = 1.0F;

	public float Charge = 0.0F;

	public float StrongAttraction = 200.0F;

	private bool m_IsAbsorbed = false;

	public float Volume
	{
		get { return Mass / Density; }
	}

	public float Radius
	{
		get { return Mathf.Pow(Volume * 2.3562F, 1.0F / 3.0F); }
	}

	public NewtonianBody(float density, float mass)
	{
		Density = density;
		Mass = mass;
	}

	public void Absorb(NewtonianBody other)
	{
		float totalMass = other.Mass + Mass;

        float myMassFactor = Mass/totalMass;
        float otherMassFactor = other.Mass/totalMass;

		Density = Density * myMassFactor + other.Density * otherMassFactor;
        rigidbody.velocity = rigidbody.velocity * myMassFactor + other.rigidbody.velocity * otherMassFactor;
        transform.position = transform.position * myMassFactor + other.transform.position * otherMassFactor;

		Mass += other.Mass;
		Destroy(other.gameObject);
		other.m_IsAbsorbed = true;
	}

	// Update is called once per frame
	void Update()
	{
		SynchronizeMassToVisuals();
	}

	void OnCollisionEnter(Collision collision)
	{
        if (m_IsAbsorbed)
            return;

		NewtonianBody otherBody = collision.gameObject.GetComponent<NewtonianBody>();
		if (otherBody == null)
			return;

		Absorb(otherBody);
	}

	void SynchronizeMassToVisuals()
	{
		if (Density <= 0 || Mass <= 0)
			return;

		rigidbody.mass = Mass;

		float bodyRadius = Radius;
		transform.localScale = new Vector3(bodyRadius, bodyRadius, bodyRadius);
		//SphereCollider myCollider = collider as SphereCollider;
		//myCollider.radius = bodyRadius;
	}

	void OnDrawGizmos()
	{
		SynchronizeMassToVisuals();
	}
}
