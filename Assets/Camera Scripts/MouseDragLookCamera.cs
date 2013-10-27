using UnityEngine;
using System.Collections;

public class MouseDragLookCamera : MonoBehaviour
{
	public float DegreesPerPixel;

	//  Not yet implemented
	public bool ClampXRotation = true;

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButton(0))
		{
			Vector3 currentRotation = camera.transform.localEulerAngles;
			currentRotation.y -= Input.GetAxis("Mouse X") * DegreesPerPixel;
			currentRotation.x += Input.GetAxis("Mouse Y") * DegreesPerPixel;
			camera.transform.localEulerAngles = currentRotation;
		}
	}
}
