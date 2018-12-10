using UnityEngine;

public class Bullet : MonoBehaviour {
    public float Speed = 2f;
    private float MapHeight;


    // Use this for initialization
    void Start() {
        Transform BackgroundTransform = GameObject.FindGameObjectWithTag("Background").GetComponent<Transform>();
        //Jest Half, bo punkt (0,0) jest na srodku ekranu (ale czy powinien byc?)
        MapHeight = BackgroundTransform.localScale.y;
        MapHeight -= transform.localScale.y / 2;

        if (transform.tag == "PlayerBullet") {
            //rb.velocity = new Vector2(0, 10); 
        }
    }

    void Update() {
        if (Mathf.Abs(transform.position.y) >= MapHeight) {
            Destroy(gameObject);
        }
        transform.Translate(0, 0.1f, 0);
    }

    private void OnTriggerEnter2D (Collider2D other) {
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
