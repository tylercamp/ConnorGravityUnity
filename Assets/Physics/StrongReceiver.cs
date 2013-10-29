using UnityEngine;
using System.Collections;

public class StrongReceiver : MonoBehaviour {

	public static float StrongConstant = 10.0F;

	public float StrongAttraction = 1.0F;
	public float StrongRamp = 3.0F;

	// Update is called once per frame
	void Update () {
		NewtonianBody[] totalBodies = FindObjectsOfType(typeof(NewtonianBody)) as NewtonianBody[];
		NewtonianBody myBody = GetComponent<NewtonianBody>();

		Vector3 forceVector;
		foreach (NewtonianBody currentBody in totalBodies)
		{
			forceVector = currentBody.rigidbody.position - this.rigidbody.position;
			float distanceNth = Mathf.Pow(forceVector.magnitude / StrongRamp, 3.0F);

			//	Distance of ~0, must be this object
			if (distanceNth <= float.Epsilon)
				continue;

			float factor = (myBody.Mass + currentBody.Mass) / distanceNth * StrongConstant;

			gameObject.rigidbody.AddForce(forceVector.normalized * factor);
		}
	}
}
