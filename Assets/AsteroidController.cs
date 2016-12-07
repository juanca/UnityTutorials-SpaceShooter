using UnityEngine;

public class AsteroidController : MonoBehaviour {
  public GameObject asteroidExplosion;
  public GameObject playerExplosion;

  private GameController gameController;

  void Start () {
    GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
    gameController = gameControllerObject.GetComponent<GameController> ();

    Rigidbody rigidbody = GetComponent<Rigidbody> ();
    rigidbody.angularVelocity = 5 * Random.insideUnitSphere;
    rigidbody.velocity = -5 * transform.forward;
  }

  void OnTriggerEnter (Collider other) {
    if (other.CompareTag ("Boundary")) {
      return;
    }

    if (other.CompareTag ("Player")) {
      Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
      gameController.GameOver ();
    }

    Instantiate (asteroidExplosion, transform.position, transform.rotation);
    Destroy (other.gameObject);
    Destroy (gameObject);

    gameController.IncrementScore (10);
  }
}
