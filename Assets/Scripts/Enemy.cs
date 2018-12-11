﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    enum Direction{
        Left = -1,
        Right = 1
    }

    public float Speed = 8f;
    private float MapWidth;
    public GameObject Bullet;
    private Direction Dir;
    public float Timer = 2.5f;
    private float tempTime;
    // Use this for initialization
    void Start() {
        Transform BackgroundTransform = GameObject.FindGameObjectWithTag("Background").GetComponent<Transform>();
        MapWidth = BackgroundTransform.localScale.x;
        MapWidth -= (transform.localScale.x / 2);
        Dir = Direction.Right; 
    }

    // Update is called once per frame
    void Update() {
        Vector2 Move = new Vector2((int)Dir * Speed * Time.deltaTime, 0);
        transform.Translate(Move);
        float ClampedX = Mathf.Clamp(transform.position.x, (0 + transform.localScale.x / 2), MapWidth);
        transform.position = new Vector2(ClampedX, transform.position.y);

        if (transform.position.x == MapWidth){
            Dir = Direction.Left;
            transform.Translate(new Vector2(0, -1));
        }
        else if (transform.position.x == 0.5f){
            Dir = Direction.Right;
            transform.Translate(new Vector2(0, -1));
        }

        tempTime += Time.deltaTime;
        
        if(tempTime >= Timer){
            SpawnBullet();
            tempTime = 0f;
        }
    }

    private void SpawnBullet() {
        Vector3 BulletPosition = transform.position - new Vector3(0, transform.localScale.y, 0);
        GameObject EnemyBullet = Instantiate(Bullet, BulletPosition, Quaternion.identity);
        EnemyBullet.transform.parent = transform.parent;
        EnemyBullet.transform.tag = ("EnemyBullet");
    }
}
