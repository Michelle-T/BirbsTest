using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour {

	/*public GameObject cameraOne;
	public GameObject cameraTwo;*/

    //Serialized Fields of Cameras
    [SerializeField]
    public Camera cameraOne;
    [SerializeField]
    public Camera cameraTwo;

    private int changeCheck = 2;

	AudioListener cameraOneAudioLis;
	AudioListener cameraTwoAudioLis;

	// Use this for initialization
	void Start()
	{
        cameraTwo.GetComponent<Camera>().enabled = true;
        cameraOne.GetComponent<Camera>().enabled = false;

        //Get Camera Listeners
        cameraOneAudioLis = cameraOne.GetComponent<AudioListener>();
		cameraTwoAudioLis = cameraTwo.GetComponent<AudioListener>();

		//Camera Position Set
		cameraPositionChange(PlayerPrefs.GetInt("CameraPosition"));
	}

	// Update is called once per frame
	void Update()
	{
		//Change Camera Keyboard
		switchCamera();


	}

	//UI JoyStick Method
	public void cameraPositonM()
	{
		cameraChangeCounter();
	}

	//Change Camera Keyboard
	void switchCamera()
	{
		if (Input.GetKey(KeyCode.Mouse1) && changeCheck != 1 || Input.GetKeyDown("joystick button 3"))
		{
			
			cameraChangeCounter();
			changeCheck = 1;
		}

		if (Input.GetKeyUp(KeyCode.Mouse1))
		{
			cameraChangeCounter();
			changeCheck = 2;
		}


	}

	//Camera Counter
	void cameraChangeCounter()
	{
		int cameraPositionCounter = PlayerPrefs.GetInt("CameraPosition");
		cameraPositionCounter++;
		cameraPositionChange(cameraPositionCounter);

	}

	//Camera change Logic
	void cameraPositionChange(int camPosition)
	{
		if (camPosition > 1)
		{
			camPosition = 0;
		}

		//Set camera position database
		PlayerPrefs.SetInt("CameraPosition", camPosition);

		//Set camera position 1
		if (camPosition == 0)
		{
            cameraOne.GetComponent<Camera>().enabled = true;
            cameraOneAudioLis.enabled = true;

			cameraTwoAudioLis.enabled = false;
            cameraTwo.GetComponent<Camera>().enabled = false;
        }

		//Set camera position 2
		if (camPosition == 1)
		{
            cameraTwo.GetComponent<Camera>().enabled = true;
            cameraTwoAudioLis.enabled = true;

			cameraOneAudioLis.enabled = false;
            cameraOne.GetComponent<Camera>().enabled = false;
        }

	}
}