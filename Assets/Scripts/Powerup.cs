using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {

    enum Direction{
        Left = -1,
        Right = 1
    }
	public float Speed = 8f;
    private float MapWidth;
	private Direction dir;
	//public Camera cam;
	public Cam camScript;
	// Use this for initialization
	void Start () {
        Transform BackgroundTransform = GameObject.FindGameObjectWithTag("Background").GetComponent<Transform>();
        MapWidth = BackgroundTransform.localScale.x;
        MapWidth -= (transform.localScale.x / 2);
        dir = Direction.Right;
		//cam = Camera.main;		
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 Move = new Vector2((int)dir * Speed * Time.deltaTime, 0);
        transform.Translate(Move);
        float ClampedX = Mathf.Clamp(transform.position.x, (0 + transform.localScale.x / 2), MapWidth);
        transform.position = new Vector2(ClampedX, transform.position.y);
		
	    if (transform.position.x == MapWidth){
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
