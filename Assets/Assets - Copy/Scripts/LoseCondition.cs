using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseCondition : MonoBehaviour
{

	public GameObject Panel;

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			Panel.gameObject.SetActive (true);

		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			Panel.gameObject.SetActive (false);

		}
	}

	// Start is called before the first frame update
	void Start()
	{
		Panel.gameObject.SetActive (false);
		Cursor.visible = true;
	}
	// Update is called once per frame
	void Update()
	{

	}
}