using UnityEngine;

public class Player : MonoBehaviour {
    public float Speed = 10f;
    public GameObject Bullet;
    private float MapWidth;
    private Transform tf;

    void Start() {
        // assigns the transform of player to tf
        tf = GetComponent<Transform>();
        Transform BackgroundTransform = GameObject.FindGameObjectWithTag("Background").GetComponent<Transform>();

        MapWidth = BackgroundTransform.localScale.x;
        //Substracts half of player width from MapWidth, because we are refering to the players' centre
        MapWidth -= (tf.localScale.x / 2);
    }

    void Update() {
        float Direction = Input.GetAxisRaw("Horizontal");
        Vector2 Move = new Vector2(Direction * Speed * Time.deltaTime, 0);
        tf.Translate(Move);
        //Clamps the players' x coordinate in order for the player not to go outside the game area
        float ClampedX = Mathf.Clamp(tf.position.x, (0 + tf.localScale.x / 2), MapWidth);
        tf.position = new Vector2(ClampedX, tf.position.y);

        if ((Input.GetKeyDown(KeyCode.Return)) && !(GameObject.FindGameObjectWithTag("PlayerBullet"))) {
            Vector3 BulletPosition = transform.position + new Vector3(0, transform.localScale.y, 0);
            GameObject PlayerBullet = Instantiate(Bullet, BulletPosition, Quaternion.identity);
            PlayerBullet.transform.parent = transform.parent;
            PlayerBullet.transform.tag = ("PlayerBullet");
        }
    }
}
