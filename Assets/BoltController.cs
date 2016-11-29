using UnityEngine;
using System.Collections;

public class BoltController : MonoBehaviour {

  // Use this for initialization
  void Start () {
    Rigidbody rigidbody = GetComponent<Rigidbody> ();
    rigidbody.velocity = transform.forward * 20;
  }
}
