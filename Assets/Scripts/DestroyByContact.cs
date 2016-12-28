using UnityEngine;

public class DestroyByContact : MonoBehaviour {
  private GameController gameController;

  public GameObject selfExplosion;
  public GameObject playerExplosion;


  void Start () {
    GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
    gameController = gameControllerObject.GetComponent<GameController> ();
  }

  void OnTriggerEnter (Collider other) {
    if (other.CompareTag ("Boundary") || (CompareTag ("Enemy") && other.CompareTag ("Enemy"))) {
      return;
    }

    if (CompareTag ("Player")) {
      Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
      gameController.GameOver ();
    }

    if (selfExplosion) {
      Instantiate (selfExplosion, transform.position, transform.rotation);
    }

    Destroy (other.gameObject);
    Destroy (gameObject);

    gameController.IncrementScore (10);
  }
}
