using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour {

	public float Timer = 3f;
	private float tempTime = 0f;
	private bool doRotate = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		while (tempTime < Timer){
			gameObject.transform.Rotate(0,0,1);
			tempTime += Time.deltaTime;
		}
	}

	public void RotateCamera() {
		doRotate = true;
	}
}
