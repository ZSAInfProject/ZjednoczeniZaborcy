using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    enum Direction{
        Left = -1,
        Right = 1
    }

    public float speed = 8f;
    private float mapWidth;
    public GameObject bullet;
    private Direction dir;
    public float timer = 2.5f;
    private float tempTime;
    // Use this for initialization
    void Start() {
        Transform BackgroundTransform = GameObject.FindGameObjectWithTag("Background").GetComponent<Transform>();
        mapWidth = BackgroundTransform.localScale.x;
        mapWidth -= (transform.localScale.x / 2);
        dir = Direction.Right; 
    }

    // Update is called once per frame
    void Update() {
        Vector2 Move = new Vector2((int)dir * speed * Time.deltaTime, 0);
        transform.Translate(Move);
        float ClampedX = Mathf.Clamp(transform.position.x, (0 + transform.localScale.x / 2), mapWidth);
        transform.position = new Vector2(ClampedX, transform.position.y);

        if (transform.position.x == mapWidth){
            dir = Direction.Left;
            transform.Translate(new Vector2(0, -1));
        }
        else if (transform.position.x == 0.5f){
            dir = Direction.Right;
            transform.Translate(new Vector2(0, -1));
        }

        if (transform.position.y == 0){
            Destroy(gameObject);
        }

        tempTime += Time.deltaTime;
        
        if(tempTime >= timer){
            SpawnBullet();
            tempTime = 0f;
        }
    }

    private void SpawnBullet() {
        Vector3 bulletPosition = transform.position - new Vector3(0, transform.localScale.y, 0);
        GameObject enemyBullet = Instantiate(bullet, bulletPosition, Quaternion.identity);
        enemyBullet.transform.parent = transform.parent;
        enemyBullet.transform.tag = ("EnemyBullet");
    }
}
