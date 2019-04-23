using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCameraController : MonoBehaviour
{
	public float RotationSpeed = 1;
	public Transform Target, Player; //problem?
	float mouseX, mouseY;

	//Dealing with Camera Obstructions




    void Start()
    {
		
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
   
    }

	void LateUpdate()
	{
		CamControl();

	}

	void CamControl()
	{
		mouseX += Input.GetAxis("Mouse X") * RotationSpeed;
		mouseY -= Input.GetAxis("Mouse Y") * RotationSpeed;
		mouseY = Mathf.Clamp (mouseY, -90, 60);

		transform.LookAt (Target);

		if (Input.GetKey (KeyCode.LeftControl)) {
			Target.rotation = Quaternion.Euler (mouseY, mouseX, 0);
		} else {
			Target.rotation = Quaternion.Euler (mouseY, mouseX, 0);
			Player.rotation = Quaternion.Euler (0, mouseX, 0);
		}
	}
		
}
