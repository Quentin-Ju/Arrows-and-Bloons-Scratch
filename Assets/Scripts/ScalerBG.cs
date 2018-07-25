using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalerBG : MonoBehaviour {


	void Start () {
		float height = Camera.main.ScreenToWorldPoint (Vector3.up * Screen.height).y;
		float width = Camera.main.ScreenToWorldPoint (Vector3.right * Screen.width).x;
		transform.localScale = new Vector3 (width/4,height/4,0);
	}

}
