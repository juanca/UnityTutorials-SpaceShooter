using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
  public GameObject hazard;

  void Start () {
    Vector3 hazardPosition = new Vector3 (Random.Range (-6.0f, 6.0f), 0.0f, 18.5f);
    Quaternion hazardRotation = Quaternion.identity;
    Instantiate (hazard, hazardPosition, hazardRotation);
  }
}
