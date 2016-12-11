using UnityEngine;

public class BackgroundController : MonoBehaviour {
  private Vector3 startPosition;

  void Start () {
    startPosition = transform.position;
  }

  void Update () {
    float newPosition = Mathf.Repeat (Time.time * -0.25f, 18);
    transform.position = startPosition + newPosition * Vector3.forward;
  }
}
