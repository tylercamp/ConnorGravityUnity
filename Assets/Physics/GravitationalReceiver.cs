using UnityEngine;
using System.Collections;

/*
 * All newtonian bodies are sources of gravity, but not all newtonian
 *  bodies may be affected by gravity.
 * 
 */

public class GravitationalReceiver : MonoBehaviour
{
	public static float GravitationConstant = 10.0F;

	// Update is called once per frame
	void Update()
	{
		NewtonianBody[] totalBodies = FindObjectsOfType(typeof(NewtonianBody)) as NewtonianBody[];
        NewtonianBody myBody = GetComponent<NewtonianBody>();

		Vector3 forceVector;
		foreach (NewtonianBody currentBody in totalBodies)
		{
			forceVector = currentBody.rigidbody.position - this.rigidbody.position;
			float distanceSquared = forceVector.sqrMagnitude;

			//	Distance of ~0, must be this object
			if (distanceSquared <= float.Epsilon)
				continue;

            float factor = (myBody.Mass + currentBody.Mass) / (distanceSquared * GravitationConstant);

			gameObject.rigidbody.AddForce(forceVector.normalized * factor);
		}
	}
}
