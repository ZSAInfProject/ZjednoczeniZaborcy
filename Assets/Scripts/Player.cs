using UnityEngine;

public class Player : MonoBehaviour {
    public float speed = 10f;
    public GameObject bullet;
    private float mapWidth;
    private Transform tf;

    void Start() {
        // assigns the transform of player to tf
        tf = GetComponent<Transform>();
        Transform backgroundTransform = GameObject.FindGameObjectWithTag("Background").GetComponent<Transform>();

        mapWidth = backgroundTransform.localScale.x;
        //Substracts half of player width from MapWidth, because we are refering to the players' centre
        mapWidth -= (tf.localScale.x / 2);
    }

    void Update() {
        float direction = Input.GetAxisRaw("Horizontal");
        Vector2 move = new Vector2(direction * speed * Time.deltaTime, 0);
        tf.Translate(move);
        //Clamps the players' x coordinate in order for the player not to go outside the game area
        float clampedX = Mathf.Clamp(tf.position.x, (0 + tf.localScale.x / 2), mapWidth);
        tf.position = new Vector2(clampedX, tf.position.y);

        if ((Input.GetKeyDown(KeyCode.Return)) && !(GameObject.FindGameObjectWithTag("PlayerBullet"))) {
            Vector3 bulletPosition = transform.position + new Vector3(0, transform.localScale.y, 0);
            GameObject playerBullet = Instantiate(bullet, bulletPosition, Quaternion.identity);
            playerBullet.transform.parent = transform.parent;
            playerBullet.transform.tag = ("PlayerBullet");
        }
    }
}
