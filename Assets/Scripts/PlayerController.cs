using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour {

	public float moveSpeed = 1000f;
	CanvasController cc;
	Vector3 resetPosition;
	Vector3 offset;
	Rigidbody rb;

	// Use this for initialization
	void Start () {
		transform.position = resetPosition;

		rb = this.GetComponent<Rigidbody>();
	
		offset = Camera.main.transform.position - this.transform.position;

		cc = GameObject.Find ("Canvas").GetComponent <CanvasController>();
	}
	
	// Update is called once per frame
	void Update () {
		float hdir = Input.GetAxisRaw ("Horizontal");
		float vdir = Input.GetAxisRaw ("Vertical");

		Camera.main.transform.position = this.transform.position + offset;

		Vector3 directionVector = new Vector3 (hdir, 0, vdir);
		Vector3 unitVector = directionVector.normalized;
		Vector3 forceVector = unitVector * moveSpeed * Time.deltaTime;
		rb.AddForce(forceVector);
		if (transform.position.y < -25f) {
			ReturnToCheckPoint();
		}
		
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject && other.gameObject.tag == "Collectible") {
			CollectiblesController col;

			col = other.gameObject.GetComponent<CollectiblesController>(); 

			if (col.isCollected == false) {

				col.isCollected = true;
				cc.IncreaseScore (1);


			}
		}
	}

	void ReturnToCheckPoint() {
		transform.position = resetPosition;
	}
}