using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	bool vanish = false;
	bool bloonPopped = false;

	public float speed;

	Rigidbody2D rb;

	Vector3 iniRotation;

	public GameObject explosionPrefab;
	public GameObject firePS;
	public GameObject glowFire;
	public GameObject flashBG;

	public AudioSource arrowAudioSource;

	public AudioClip arrowStrike;
	public AudioClip arrowShot;

	Bow bowScript;

	Spawner spawnerScript;

	void Start () {
		bowScript = GameObject.Find ("Bow").GetComponent<Bow> ();
		spawnerScript = GameObject.Find ("Spawner").GetComponent<Spawner> ();
		rb = GetComponent<Rigidbody2D> ();
		this.gameObject.transform.SetParent (null);
		rb.velocity = rb.position.normalized * speed;
		Invoke ("ArrowVanish", 15);
		arrowAudioSource.PlayOneShot (arrowShot);
		if (bowScript.bonusPoints == 2) {
			firePS.SetActive (true);
		} else if (bowScript.bonusPoints == 3) {
			firePS.SetActive (true);
			glowFire.SetActive (true);
		}
	}

	void Update () {
		if (vanish && transform.localScale.x > 0) {
			transform.localScale -= new Vector3 (Time.deltaTime * 5, 0, 0);
		} else if (vanish) {
			Destroy (this.gameObject);
		}
	}

	void OnTriggerEnter2D (Collider2D othercoll) {
		if (othercoll.gameObject.tag == "Cadre") {
			arrowAudioSource.PlayOneShot (arrowStrike);
			rb.velocity = Vector2.zero;
			rb.isKinematic = true;
			Destroy (GetComponent<PolygonCollider2D> ());
			iniRotation = transform.eulerAngles;
			StartCoroutine (FlechePlantee ());
			if (bloonPopped) {
				bowScript.BonusPointsUp ();
			} else {
				bowScript.BonusPointsReset ();
			}
		} else if (othercoll.gameObject.tag == "Bloon") {
			bloonPopped = true;
			spawnerScript.BloonDestroyed ();
			GameObject explo = Instantiate (explosionPrefab, new Vector3 (othercoll.transform.position.x, othercoll.transform.position.y, -1), Quaternion.identity);
			explo.GetComponent<Explosion> ().hardness = othercoll.gameObject.GetComponent<Bloon> ().hardness;
			ParticleSystem exploPS = explo.GetComponent<ParticleSystem> ();
			ParticleSystem.MainModule mainModPS = exploPS.main;
			if (othercoll.gameObject.GetComponent<Bloon> ().yellow) {
				mainModPS.startColor = new Color(0.96f,0.89f,0);
			} else if (othercoll.gameObject.GetComponent<Bloon> ().purple) {
				mainModPS.startColor = new Color(0.51f,0,0.96f);
			} else {
				mainModPS.startColor = othercoll.gameObject.GetComponent<SpriteRenderer> ().color;
			}
			Instantiate (flashBG, Vector3.zero, Quaternion.identity);
			if (bowScript.bonusPoints <= 1) {
				GameManager.gm.Score (1);
			} else if (bowScript.bonusPoints == 2) {
				GameManager.gm.Score (2);
			} else {
				GameManager.gm.Score (4);
			}
			if (othercoll.gameObject.GetComponent<Bloon>().blue || othercoll.gameObject.GetComponent<Bloon>().yellow) {
				Destroy (othercoll.gameObject.transform.parent.gameObject);
			}
			Destroy (othercoll.gameObject);
		}
	}

	void ArrowVanish () {
		vanish = true;
	}

	IEnumerator FlechePlantee () {
		for (int i = 0; i < 3; i++) {
			transform.eulerAngles = iniRotation + new Vector3 (0, 0, 10f * (i/ 3f));
			yield return 0;
		}
		for (int i = 3; i > 0; i--) {
			transform.eulerAngles = iniRotation + new Vector3 (0, 0, 10f * (i/ 3f));
			yield return 0;
		}
		for (int i = 0; i < 3; i++) {
			transform.eulerAngles = iniRotation + new Vector3 (0, 0, -10f * (i/ 3f));
			yield return 0;
		}
		for (int i = 3; i > 0; i--) {
			transform.eulerAngles = iniRotation + new Vector3 (0, 0, -10f * (i/ 3f));
			yield return 0;
		}
		for (int i = 0; i < 3; i++) {
			transform.eulerAngles = iniRotation + new Vector3 (0, 0, 8f * (i/ 3f));
			yield return 0;
		}
		for (int i = 3; i > 0; i--) {
			transform.eulerAngles = iniRotation + new Vector3 (0, 0, 8f * (i/ 3f));
			yield return 0;
		}
		for (int i = 0; i < 3; i++) {
			transform.eulerAngles = iniRotation + new Vector3 (0, 0, -8f * (i/ 3f));
			yield return 0;
		}
		for (int i = 3; i > 0; i--) {
			transform.eulerAngles = iniRotation + new Vector3 (0, 0, -8f * (i/ 3f));
			yield return 0;
		}
		for (int i = 0; i < 3; i++) {
			transform.eulerAngles = iniRotation + new Vector3 (0, 0, 6f * (i/ 3f));
			yield return 0;
		}
		for (int i = 3; i > 0; i--) {
			transform.eulerAngles = iniRotation + new Vector3 (0, 0, 6f * (i/ 3f));
			yield return 0;
		}
		for (int i = 0; i < 3; i++) {
			transform.eulerAngles = iniRotation + new Vector3 (0, 0, -6f * (i/ 3f));
			yield return 0;
		}
		for (int i = 3; i > 0; i--) {
			transform.eulerAngles = iniRotation + new Vector3 (0, 0, -6f * (i/ 3f));
			yield return 0;
		}
		for (int i = 0; i < 3; i++) {
			transform.eulerAngles = iniRotation + new Vector3 (0, 0, 3f * (i/ 3f));
			yield return 0;
		}
		for (int i = 3; i > 0; i--) {
			transform.eulerAngles = iniRotation + new Vector3 (0, 0, 3f * (i/ 3f));
			yield return 0;
		}
		for (int i = 0; i < 3; i++) {
			transform.eulerAngles = iniRotation + new Vector3 (0, 0, -3f * (i/ 3f));
			yield return 0;
		}
		for (int i = 3; i > 0; i--) {
			transform.eulerAngles = iniRotation + new Vector3 (0, 0, -3f * (i/ 3f));
			yield return 0;
		}
	}
}
