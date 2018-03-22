using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class machinecollectsushi : MonoBehaviour {

	[SerializeField] private float distanceLimit;
	[SerializeField] private GameObject player;
	[SerializeField] private playercontrol plyctrl;
	private bool canGiveSushi;

	// Use this for initialization
	void Start () {
		distanceLimit = 3.5f;
		player = GameObject.FindGameObjectWithTag("Player");
		plyctrl = player.GetComponent<playercontrol>();
		canGiveSushi = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (player.transform.position.x + distanceLimit > transform.position.x && player.transform.position.x - distanceLimit < transform.position.x) {
			canGiveSushi = true;
		}
		else 
		{
			canGiveSushi = false;
		}

		if (canGiveSushi && Input.GetAxis("Jump") > 0) 
		{
			playercontrol.score += plyctrl.GetHolding();
			plyctrl.SetHolding(0);
		}

		print(canGiveSushi);
	}
}
