using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour {

	public float timer = 3f;
	private float tempTime = 0f;
	private bool doRotate = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (doRotate){
			if (tempTime < timer){
				gameObject.transform.Rotate(0,0,1);
				tempTime += Time.deltaTime;
			}
			else if (tempTime >= timer){
				doRotate = false;
				gameObject.transform.rotation = new Quaternion(0,0,0,0);
				tempTime = 0;
			}
		}
	}

	public void RotateCamera() {
		doRotate = true;
	}
}
