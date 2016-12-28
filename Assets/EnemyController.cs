using UnityEngine;

public class EnemyController : MonoBehaviour {
  public GameObject bolt;
  public Transform shotSpawn;

  private AudioSource weaponSound;

  void Start () {
    weaponSound = GetComponent<AudioSource> ();
    InvokeRepeating ("Fire", 1.0f, 0.7f);
  }

  void Fire () {
    Instantiate (bolt, shotSpawn.position, shotSpawn.rotation);
    weaponSound.Play ();
  }
}
