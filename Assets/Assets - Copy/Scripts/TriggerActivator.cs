using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerActivator : MonoBehaviour
{
	public GameObject ObjectToEnable;


	private void OnTriggerEnter(Collider other)
	{
		ObjectToEnable.SetActive(true);
	}

	private void OnTriggerExit(Collider other)
	{
		ObjectToEnable.SetActive(false);
	}
    
}
