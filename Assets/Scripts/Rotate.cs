using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

	float speed;
	float angle;

	void Start () {
		speed = Random.Range (100, 180);
		angle = Random.Range (0, 360);
	}

	void Update () {
		if (!GameManager.gm.gameIsEnded) {
			angle += (speed * Time.deltaTime) % 360;
			transform.localPosition = new Vector3 (Mathf.Cos (Mathf.Deg2Rad * angle) * 0.7f, Mathf.Sin (Mathf.Deg2Rad * angle) * 0.7f, 0);
		}
	}
}
