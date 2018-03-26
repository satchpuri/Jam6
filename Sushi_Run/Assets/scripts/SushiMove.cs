using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SushiMove : MonoBehaviour {

    public Transform StartingPoint;
    public Transform EndingPoint;
    public static float Speed;

	void Start () {
        Speed = 1.0f;	
	}
	
	// Update is called once per frame
	void Update () {

            transform.position += new Vector3(Speed * Time.deltaTime, 0, 0);
	}


}
