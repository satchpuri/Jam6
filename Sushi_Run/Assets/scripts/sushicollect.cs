using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sushicollect : MonoBehaviour {

	[SerializeField] private GameObject player;
	[SerializeField] private playercontrol plyctrl;
	//the bounds within you must be near the sushi to pick it up
	[SerializeField] private float distanceOffset;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		plyctrl = player.GetComponent<playercontrol>();

		distanceOffset = 1.5f;
	}
	
	// Update is called once per frame
	void Update () {

		//try to grab a sushi roll
		if (Input.GetAxis("Jump") != 0 && playercontrol.clickTimer > playercontrol.timeTillReclick) 
		{
			//within range of the sushi roll
			if (player.transform.position.x + distanceOffset > transform.position.x && player.transform.position.x - distanceOffset < transform.position.x) 
			{
				//check if the player can hold more sushi
				if (plyctrl.GetHolding () < plyctrl.GetMaxHold ()) 
				{
					plyctrl.SetHolding (plyctrl.GetHolding () + 1);
					playercontrol.clickTimer = 0;
					Destroy(gameObject);
				}
			}
		}

        transform.position += new Vector3(GameManagerSpawn.speed * Time.deltaTime, 0.0f, 0.0f);


	}
}
