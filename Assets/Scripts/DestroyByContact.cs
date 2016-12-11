using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {
  private GameController gameController;

  public GameObject selfExplosion;
  public GameObject playerExplosion;


  void Start () {
    GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
    gameController = gameControllerObject.GetComponent<GameController> ();
  }

  void OnTriggerEnter (Collider other) {
    if (other.CompareTag ("Boundary")) {
      return;
    }

    if (other.CompareTag ("Player")) {
      Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
      gameController.GameOver ();
    }

    Instantiate (selfExplosion, transform.position, transform.rotation);
    Destroy (other.gameObject);
    Destroy (gameObject);

    gameController.IncrementScore (10);
  }
}
