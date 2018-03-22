using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playercontrol : MonoBehaviour {

	[SerializeField] private float speed;
	[SerializeField] private float limitRight;
	[SerializeField] private float limitLeft;
	public static int score;

	public static int clickTimer = 0;
	public static int timeTillReclick = 20;

	//how many nsushi rolls the player is holding
	public int holding;
	//the maximum number of sushi rolls the player can hold
	public int maxHold;

	[SerializeField] private Text scoreTextBox;

	private string scoreText = "Score: ";

	// Use this for initialization
	void Start () {
		holding = 0;
		maxHold = 2;

		speed = 7.0f;
		limitRight = 10.0f;
		limitLeft = -12.75f;
		score = 0;

		scoreTextBox.text = "Score: " + score;
	}
	
	// Update is called once per frame
	void Update () {

		scoreTextBox.text = "Score: " + score;

		if (Input.GetAxis("Horizontal") > 0 && transform.position.x < limitRight) 
		{
			transform.position += new Vector3(speed, 0.0f, 0.0f) * Time.deltaTime;
		}
		else if (Input.GetAxis("Horizontal") < 0 && transform.position.x > limitLeft) 
		{
			transform.position += new Vector3(-speed, 0.0f, 0.0f) * Time.deltaTime;
		}

		clickTimer++;
	}

	public int GetHolding()
	{
		return holding;
	}

	public void SetHolding(int value)
	{
		holding = value;
	}

	public int GetMaxHold()
	{
		return maxHold;
	}
}
