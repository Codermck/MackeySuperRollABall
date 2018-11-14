using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CanvasController : MonoBehaviour {

	public GameObject scoreText;
	int score;

	// Use this for initialization
	void Start () {

		score = 0;
		scoreText.GetComponent<Text>().text = "Score: " + score.ToString();	
	}
	
	public void IncreaseScore(int amount)
	{
		score += amount;

		scoreText.GetComponent<Text>().text = "Score: " + score.ToString();	
	
	}

	// Update is called once per frame
	void Update () {
		
	}
}
