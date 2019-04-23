using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinCondition : MonoBehaviour
{

	public GameObject Panel;
	private static int score;

	void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("Player") && score >= 1000)
			{
			Panel.gameObject.SetActive (true);

			LoadScene(2);
			}
		}
    // Start is called before the first frame update
    void Start()
    {
		Panel.gameObject.SetActive (false);
    }

    // Update is called once per frame
    void Update()
    {
		score = TakePicture.count;
    }

	public void LoadScene(int level)
	{
		
		Application.LoadLevel(level);
	}
}

