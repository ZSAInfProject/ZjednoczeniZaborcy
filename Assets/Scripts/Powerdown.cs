using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerdown : MonoBehaviour {

    enum Direction{
        Left = -1,
        Right = 1
    }
	public float speed = 8f;
    private float mapWidth;
	private Direction dir;
	//public Camera cam;
	public Cam camScript;
	// Use this for initialization
	void Start () {
        Transform backgroundTransform = GameObject.FindGameObjectWithTag("Background").GetComponent<Transform>();
        mapWidth = backgroundTransform.localScale.x;
        mapWidth -= (transform.localScale.x / 2);
        dir = Direction.Right;
		//cam = Camera.main;		
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 move = new Vector2((int)dir * speed * Time.deltaTime, 0);
        transform.Translate(move);
        float clampedX = Mathf.Clamp(transform.position.x, (0 + transform.localScale.x / 2), mapWidth);
        transform.position = new Vector2(clampedX, transform.position.y);
		
	    if (transform.position.x == mapWidth){
            dir = Direction.Left;
        }
        else if (transform.position.x == 0.25f){
            dir = Direction.Right;
        }
	}

	private void OnTriggerEnter2D(Collider2D other){
		if (other.transform.tag == "PlayerBullet"){
			camScript.RotateCamera();
		}
	}
}
