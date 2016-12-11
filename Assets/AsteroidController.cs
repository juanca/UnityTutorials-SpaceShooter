using UnityEngine;

public class AsteroidController : MonoBehaviour {
  void Start () {
    Rigidbody rigidbody = GetComponent<Rigidbody> ();
    rigidbody.angularVelocity = 5 * Random.insideUnitSphere;
    rigidbody.velocity = -5 * transform.forward;
  }
}
