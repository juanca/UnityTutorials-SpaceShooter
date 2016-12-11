using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
  public Text gameOverUI;
  public Text restartUI;
  public Text scoreUI;
  public GameObject[] hazards;

  private int score;
  private bool gameOver;


  //
  // Lifecycle

  private void Start () {
    gameOverUI.text = "";
    restartUI.text = "";
    score = 0;
    scoreUI.text = "";

    UpdateScore ();
    StartCoroutine (SpawnWaves ());
  }

  private void Update () {
    if (gameOver) {
      if (Input.GetKeyDown (KeyCode.R)) {
        SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
      }
    }
  }


  //
  // Controls

  public void GameOver () {
    gameOver = true;
    gameOverUI.text = "Game Over";
  }

  public void IncrementScore (int value) {
    score += value;
    UpdateScore ();
  }

  private IEnumerator SpawnWaves () {
    yield return new WaitForSeconds (3.0f);

    while (true) {
      for (int i = 0; i < 10; i += 1) {
        GameObject hazard = hazards [Random.Range (0, hazards.Length)];
        Vector3 hazardPosition = new Vector3 (Random.Range (-6.0f, 6.0f), 0.0f, 18.5f);
        Quaternion hazardRotation = Quaternion.identity;
        Instantiate (hazard, hazardPosition, hazardRotation);

        yield return new WaitForSeconds (0.5f);
      }

      yield return new WaitForSeconds (2.0f);

      if (gameOver) {
        restartUI.text = "Restart ('R')";
      }
    }
  }

  private void UpdateScore () {
    scoreUI.text = "Score: " + score;
  }
}
