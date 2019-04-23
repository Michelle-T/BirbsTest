using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCharacterController : MonoBehaviour
{
	public float Speed;
	public float JumpHeight;
	private int JumpCount=0;
	public GameObject pausePanel;
	bool pause = false;
	bool scoring = true;
    //public Rigidbody rb;

    //Added a Serialized Camera
    [SerializeField]
    Camera FirstCam;

    void Start() {
		pausePanel.SetActive(false);
		//rb = GetComponent<Rigidbody>();
	}

	void Update() {
	if (Input.GetKeyDown("p"))
	{
		if (pause == true)
		{
			Time.timeScale = 0.0f;
			pausePanel.SetActive(true);
			scoring = false;
			pause = false;
		}
		else
		{
			Time.timeScale = 1.0f;
			pausePanel.SetActive(false);
			scoring = true;
			pause = true;
		}
	}

		if (Input.GetKeyDown("escape"))
		{
			Application.Quit();
		}
	}

	void FixedUpdate() {
		
		PlayerMovement ();


//		if (Input.GetKey(KeyCode.W))
//			{
//		rb.MovePosition(transform.position + transform.forward * Time.deltaTime);
//			}

		if (Input.GetKeyDown (KeyCode.Space) && JumpCount < 1 || Input.GetKeyDown("joystick button 0") && JumpCount < 1){
			StartCoroutine(Example());
			GetComponent<Rigidbody>().AddForce (Vector3.up * JumpHeight);
			}

	
	}

	IEnumerator Example()
	{
		JumpCount = 1;
		yield return new WaitForSeconds(2);
		JumpCount = 0;
	}

	void PlayerMovement()
	{
		float hor = Input.GetAxis ("Horizontal");
		float ver = Input.GetAxis ("Vertical");
		Vector3 playerMovement = new Vector3 (hor, 0f, ver) * Speed * Time.deltaTime;
		transform.Translate (playerMovement, Space.Self);

		if (FirstCam.GetComponent<Camera>().enabled == false)
		{
			Speed = 8;
		}
		else
			{
				Speed = 2;
			}


	}
}
