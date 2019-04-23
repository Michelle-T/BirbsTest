using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSoundActivator : MonoBehaviour
{
	public GameObject ObjectToEnable;

	public AudioSource FireBird;

	private void OnTriggerEnter(Collider other)
	{
		FireBird.Play();
	}



}
