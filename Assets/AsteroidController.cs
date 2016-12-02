using UnityEngine;
using System.Collections;

public class AsteroidController : MonoBehaviour {
  void Start () {
    Rigidbody rigidbody = GetComponent<Rigidbody> ();
    rigidbody.angularVelocity = 5 * Random.insideUnitSphere;
  }

  void OnTriggerEnter (Collider other) {
    if (other.CompareTag ("Boundary")) {
      return;
    }

    Destroy (other.gameObject);
    Destroy (gameObject);
  }
}
