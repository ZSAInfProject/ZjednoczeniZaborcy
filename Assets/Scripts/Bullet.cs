using UnityEngine;

public class Bullet : MonoBehaviour {
    public float speed = 2f;
    private float mapHeight;
    private string bulletTag;
    // Use this for initialization
    void Start() {
        Transform backgroundTransform = GameObject.FindGameObjectWithTag("Background").GetComponent<Transform>();
        //Jest Half, bo punkt (0,0) jest na srodku ekranu (ale czy powinien byc?)
        mapHeight = backgroundTransform.localScale.y;
        mapHeight -= transform.localScale.y / 2;
        bulletTag = transform.tag;

        if (bulletTag == "PlayerBullet") {}
        else if(bulletTag == "EnemyBullet"){
            speed *= -1;
        }
    }

    void Update() {
        if (Mathf.Abs(transform.position.y) >= mapHeight) {
            Destroy(gameObject);
        }
    }

    void FixedUpdate() {
        transform.Translate(0, 0.1f * speed, 0);
    }

    private void OnTriggerEnter2D (Collider2D other) {
        if (bulletTag == "EnemyBullet" && other.transform.tag == "Player"){
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if (bulletTag == "PlayerBullet" && other.transform.tag == "Enemy"){
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if (bulletTag == "PlayerBullet" && (other.transform.tag == "Powerup" || other.transform.tag == "Powerdown")){
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
