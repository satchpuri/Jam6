using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerSpawn : MonoBehaviour {

    public static float spawnRate;
    public static float speed;
    public static int timer;

    public GameObject anySushi;
    public GameObject start;
    public GameObject end;

	// Use this for initialization
	void Start () {
        speed = 1.0f;
        spawnRate = 6.0f;
        timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        speed += 0.001f;
        spawnRate -= 0.001f;
        timer++;

        if (timer > 60*spawnRate)
        {
            print("Should Spawn");
            Instantiate(anySushi, start.transform.position, Quaternion.identity);
            timer = 0;
        }

	}
}
