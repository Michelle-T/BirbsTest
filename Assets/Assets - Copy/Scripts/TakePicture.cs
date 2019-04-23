
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TakePicture : MonoBehaviour
{


	public Text countText, countText2;

	static public int count;


	public Camera FPcam;


	public LayerMask kiwiMask;
	//public GameObject Menu;

	//public GameObject pausePanel;

	public float pictureRate = 1f;

	//private WaitForSeconds snapDuration = new WaitForSeconds(0.07f);

	private float nextPicture;

	public AudioSource CameraClick;


	// Start is called before the first frame update
	void Start()
	{


		//cam = Camera.main;

		count = 0;
		SetCountText();

		//Ray ray;

		//pausePanel.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButton(0) && Time.time > nextPicture || Input.GetKeyDown("joystick button 5") && Time.time > nextPicture) 
		{
			nextPicture = Time.time + pictureRate;
			CameraClick.Play();
			Ray ray = FPcam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			//Debug_Draws the raycast
			Debug.DrawRay(transform.position, transform.position, Color.red, 6, false);


			//Score System
			if (Physics.Raycast(ray, out hit, 1000f))
			{
				Debug.Log("We hit " + hit.collider.name + " " + hit.point);

				if (hit.collider.gameObject.tag == "Common")
				{
					Debug.Log("Common");
					count = count + 50;
					SetCountText();
					hit.collider.gameObject.tag="CommonHit";
				}
				if (hit.collider.gameObject.tag == "Rare")
				{
					Debug.Log("Rare!");
					count = count + 125;
					SetCountText();
					hit.collider.gameObject.tag="RareHit";
				}
				if (hit.collider.gameObject.tag == "Legendary")
				{
					Debug.Log("LEGENDARY!!!");
					count = count + 500;
					SetCountText();
					hit.collider.gameObject.tag="LegendaryHit";
				}
				if (hit.collider.gameObject.tag == "Sign")
				{
					Debug.Log("practice");
					count = count + 10;
					SetCountText();

				}


				//Hit Tags
				if (hit.collider.gameObject.tag == "CommonHit")
				{
					Debug.Log("CommonHit");
					count = count + 50;
					SetCountText();
				}
				if (hit.collider.gameObject.tag == "RareHit")
				{
					Debug.Log("Rare!");
					count = count + 125;
					SetCountText();
				}
				if (hit.collider.gameObject.tag == "LegendaryHit")
				{
					Debug.Log("LEGENDARY!!!");
					count = count + 0;
					SetCountText();
				}
			}
		}
		//}
	}



	//SCORE
	void SetCountText()
	{
		countText.text = "Count: " + count.ToString();

	}


}