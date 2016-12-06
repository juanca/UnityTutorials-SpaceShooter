using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {
  public Text scoreText;
  public GameObject hazard;

  private int score;

  void Start () {
    score = 0;
    UpdateScore ();
    StartCoroutine (SpawnWaves ());
  }

  public void IncrementScore (int value) {
    score += value;
    UpdateScore ();
  }

  void UpdateScore () {
    scoreText.text = "Score: " + score;
  }

  IEnumerator SpawnWaves () {
    yield return new WaitForSeconds (3.0f);

    while (true) {
      for (int i = 0; i < 10; i += 1) {
        Vector3 hazardPosition = new Vector3 (Random.Range (-6.0f, 6.0f), 0.0f, 18.5f);
        Quaternion hazardRotation = Quaternion.identity;
        Instantiate (hazard, hazardPosition, hazardRotation);

        yield return new WaitForSeconds (0.5f);
      }

      yield return new WaitForSeconds (2.0f);
    }
  }
}
