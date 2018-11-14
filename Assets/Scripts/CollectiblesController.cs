using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblesController : MonoBehaviour {

	public bool isCollected;

	AudioSource audioSource;
	Vector3 direction;

	bool hasPlayed = false;

	// Use this for initialization
	void Start () {

		audioSource = GetComponent<AudioSource> ();
		 isCollected = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (isCollected == true) {

			Debug.Log ("isCollected has been set to true for me!");
			Destroy (this.gameObject, 1f);
			if (hasPlayed == false) {
				audioSource.Play ();
				hasPlayed = true;
			}
				Disappear ();
			
		}

	}


	void Disappear () {
		
		this.transform.Translate(Vector3.up * 4f * Time.deltaTime);
		this.transform.localScale += new Vector3 (.25f, .25f, .25f) * Time.deltaTime;
	}
}
