using UnityEngine;
using System.Collections;

public class WASDMoveFreeCamera : MonoBehaviour
{

	public float MovementsPerSecond = 5.0F;
	
	// Update is called once per frame
	void Update () {
		Vector3 movementVector = Vector3.zero;

		movementVector += new Vector3(
				Mathf.Sin(camera.transform.localEulerAngles.y * Mathf.Deg2Rad),
				0.0F,
				Mathf.Cos(camera.transform.localEulerAngles.y * Mathf.Deg2Rad)
			) * Input.GetAxis("Vertical") * MovementsPerSecond * Time.deltaTime;

		movementVector += new Vector3(
				Mathf.Sin((camera.transform.localEulerAngles.y + 90.0F) * Mathf.Deg2Rad),
				0.0F,
				Mathf.Cos((camera.transform.localEulerAngles.y + 90.0F) * Mathf.Deg2Rad)
			) * Input.GetAxis("Horizontal") * MovementsPerSecond * Time.deltaTime;

		if (Input.GetKey(KeyCode.Z))
			movementVector.y -= MovementsPerSecond * Time.deltaTime;
		if (Input.GetKey(KeyCode.X))
			movementVector.y += MovementsPerSecond * Time.deltaTime;

		camera.transform.position += movementVector;
	}
}
