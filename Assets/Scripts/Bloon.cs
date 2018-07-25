using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloon : MonoBehaviour {

	public bool blue;
	public bool green;
	public bool yellow;
	public bool purple;

	public int hardness;

	float lerpFactor;
	float angle;
	float rotationSpeed;
	float rotationTimer;

	public GameObject explosionPrefab;

	Rigidbody2D rb;

	SpriteRenderer sr;

	Color iniColor;

	void Awake () {
		rb = GetComponent<Rigidbody2D> ();
	}

	void Start () {
		sr = GetComponent<SpriteRenderer> ();
		iniColor = sr.color;
		rotationSpeed = Random.Range (-90, -50);
		angle = Random.Range (0.0f, 360.0f);
	}

	void Update () {
		if (green && sr.color != Color.black) {
			sr.color = Color.Lerp (iniColor, Color.black, lerpFactor);
			lerpFactor += Time.deltaTime / 12;
		} else if (green) {
			GameManager.gm.EndGame ();
			GameObject explo = Instantiate (explosionPrefab, new Vector3 (transform.position.x, transform.position.y, -1), Quaternion.identity);
			explo.GetComponent<Explosion> ().hardness = hardness;
			ParticleSystem exploPS = explo.GetComponent<ParticleSystem> ();
			ParticleSystem.MainModule mainModPS = exploPS.main;
			mainModPS.startColor = GetComponent<SpriteRenderer> ().color;
			Destroy (this.gameObject);
		}
			
		if (GameManager.gm.gameIsEnded && rb.isKinematic) {
			rb.isKinematic = false;
		}

		if (yellow && !GameManager.gm.gameIsEnded) {
			angle += (rotationSpeed * Time.deltaTime)%360;
			transform.localPosition = new Vector3 (Mathf.Cos (Mathf.Deg2Rad * angle) * 2.5f, Mathf.Sin (Mathf.Deg2Rad * angle) * 2.5f, 0);
		}

		if (purple && !GameManager.gm.gameIsEnded) {
			angle += (rotationSpeed * Time.deltaTime)%360;
			if (rotationTimer < 2) {
				rotationTimer += Time.deltaTime;
			} else {
				rotationSpeed = Random.Range (-100, -40);
				rotationTimer = 0;
			}
			transform.localPosition = new Vector3 (Mathf.Cos (Mathf.Deg2Rad * angle) * 2.5f, Mathf.Sin (Mathf.Deg2Rad * angle) * 2.5f, 0);
		}
	}

}
