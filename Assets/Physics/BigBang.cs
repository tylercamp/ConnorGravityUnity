using UnityEngine;
using System.Collections;

public class BigBang : MonoBehaviour
{
	/*
	 * This part is interesting:
	 *	The game object passed to the BigBang script in Unity is used as a template for instantiation in
	 *	the Start method. Generally this is a prefab, but it isn't always a prefab. Having this
	 *	member as type "NewtonianBody" puts a limit on what type of objects can be used as a
	 *	template, where the only objects that can be a template must have a NewtonianBody
	 *	component.
	 */
	public NewtonianBody NewtonianBodyPrefab;


	public float DarkMatterPercentage = 50.0F;

	//  Note: Currently broken
	public bool DarkMatterCollisionsEnabled = false;

	public float CreationRadius = 10.0F;
	public float MinInitialVelocity = 1.0F;
	public float MaxInitialVelocity = 5.0F;
	public int ParticlesOnCreate = 50;

	// Use this for initialization
	void Start()
	{
		for (int i = 0; i < ParticlesOnCreate; i++)
		{
			NewtonianBody newBody = Instantiate(NewtonianBodyPrefab) as NewtonianBody;
			newBody.transform.position = Random.insideUnitSphere * CreationRadius;
			newBody.rigidbody.velocity = Random.onUnitSphere * Random.Range(MinInitialVelocity, MaxInitialVelocity);

			newBody.Mass = Random.value * 1000.0F + 10.0F;
			newBody.Density = 1000.0F;

			bool isDarkMatter = Random.value < DarkMatterPercentage / 100.0F;
			if (isDarkMatter)
			{
				if (!DarkMatterCollisionsEnabled)
					Object.Destroy(newBody.collider);

				Object.Destroy(newBody.GetComponent(typeof (SynchronizedSphericalLight)));
				Object.Destroy(newBody.light);

				newBody.rigidbody.detectCollisions = false;
			}
		}

		//Object.Destroy(gameObject);
	}

	void OnDrawGizmosSelected()
	{
		Gizmos.DrawWireSphere(transform.position, CreationRadius);
	}
}
