using UnityEngine;
using System.Collections;

public class AsteroidController : MonoBehaviour {
  public GameObject asteroidExplosion;
  public GameObject playerExplosion;

  void Start () {
    Rigidbody rigidbody = GetComponent<Rigidbody> ();
    rigidbody.angularVelocity = 5 * Random.insideUnitSphere;
  }

  void OnTriggerEnter (Collider other) {
    if (other.CompareTag ("Boundary")) {
      return;
    }

    if (other.CompareTag ("Player")) {
      Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
    }

    Instantiate (asteroidExplosion, transform.position, transform.rotation);
    Destroy (other.gameObject);
    Destroy (gameObject);
  }
}
