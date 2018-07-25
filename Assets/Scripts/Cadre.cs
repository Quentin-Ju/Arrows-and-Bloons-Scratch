using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cadre : MonoBehaviour {

	BoxCollider2D[] bc;

	float width;

	void Start () {
		width = Camera.main.ScreenToWorldPoint (Vector3.right * Screen.width).x;
		bc = this.gameObject.GetComponents<BoxCollider2D> ();
		bc [0].offset = new Vector2 (width + 0.5f, 0);
		bc [1].offset = new Vector2 (-width - 0.5f, 0);
		bc [2].offset = new Vector2 (0, 5.5f);
		bc [3].offset = new Vector2 (0, -5.5f);
	}

}
