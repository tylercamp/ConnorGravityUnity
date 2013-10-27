using UnityEngine;
using System.Collections;

public class SynchronizedSphericalLight : MonoBehaviour
{
    public float NewtonianToLightRadiusFactor = 1.5F;

	// Update is called once per frame
	void Update()
	{
		renderer.material.color = light.color;
		light.range = GetComponent<NewtonianBody>().Radius * NewtonianToLightRadiusFactor;
	}
}
