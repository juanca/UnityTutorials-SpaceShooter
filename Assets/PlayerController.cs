using UnityEngine;

public class PlayerController : MonoBehaviour {

  public float speed;
  public GameObject shot;
  public Transform shotSpawn;
  public float fireRate;

  private float nextFire;
  private Rigidbody rigidbody;

  // Use this for initialization
  void Start () {
    nextFire = 0.0f;
    rigidbody = GetComponent<Rigidbody> ();
  }

  void Update () {
    if (Input.GetButton ("Fire1") && Time.time > nextFire) {
      nextFire = Time.time + fireRate;
      Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
    }
  }

  void FixedUpdate () {
    float moveHorizontal = Input.GetAxis ("Horizontal");
    float moveVertical = Input.GetAxis ("Vertical");

    Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
    rigidbody.velocity = movement * speed;

    float clampedX = Mathf.Clamp (rigidbody.position.x, -6.0f, 6.0f);
    float clampedZ = Mathf.Clamp (rigidbody.position.z, -1.0f, 17.0f);
    rigidbody.position = new Vector3 (clampedX, 0.0f, clampedZ);

    rigidbody.rotation = Quaternion.Euler (new Vector3 (0.0f, 0.0f, rigidbody.velocity.x * -4));
  }
}
