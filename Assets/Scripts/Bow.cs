using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bow : MonoBehaviour {

	public float rotationSpeed;

	public int bonusPoints;

	bool touched;

	public GameObject projectilePrefab;
	public GameObject firePS;
	public GameObject glowFire;

	public SpriteRenderer lueurSR;
	public SpriteRenderer shadowBG;

	public Animator animBow;

	public Color noShadowColor;
	public Color shadowColor;
	public Color transparent;

	public ParticleSystem psFire;

	ParticleSystem.EmissionModule psFireEmission;

	public Text congratsTxt;

	Spawner spawnerScript;

	void Awake () {
		spawnerScript = GameObject.Find ("Spawner").GetComponent<Spawner> ();
	}

	void Start () {
		psFireEmission = psFire.emission;
	}

	void Update () {
		transform.eulerAngles += new Vector3 (0, 0, rotationSpeed * Time.deltaTime);
		if (Input.touchCount > 0 && !GameManager.gm.menu && !GameManager.gm.gameIsEnded && spawnerScript.bloonCount != 0) {
			touched = false;
			for (int i = 0; i < Input.touchCount; i++) {
				if (Input.GetTouch (i).phase == TouchPhase.Began) {
					touched = true;
				}
			}
			if (touched && LevelManager.lm.charges > 0) {
				InstantiateProjectile ();
				LevelManager.lm.ArrowShot ();
			}
		}


		if (bonusPoints == 3) {
			if (glowFire.transform.localScale != Vector3.one * 0.1f) {
				glowFire.transform.localScale = Vector3.Lerp (glowFire.transform.localScale, Vector3.one * 0.1f, 0.03f);
			}
			if (!psFireEmission.enabled) {
				psFireEmission.enabled = true;
			}
			if (shadowBG.color != shadowColor) {
				shadowBG.color = Color.Lerp (shadowBG.color, shadowColor, 0.02f);
			}
			if (lueurSR.color != Color.white) {
				lueurSR.color = Color.Lerp (lueurSR.color, Color.white, 0.02f);
			}
		} else if (bonusPoints >= 2) {
			if (!psFireEmission.enabled) {
				psFireEmission.enabled = true;
			}
			if (shadowBG.color != shadowColor) {
				shadowBG.color = Color.Lerp (shadowBG.color, shadowColor, 0.02f);
			}
			if (lueurSR.color != transparent) {
				lueurSR.color = Color.Lerp (lueurSR.color, transparent, 0.02f);
			}
		} else {
			if (psFireEmission.enabled) {
				psFireEmission.enabled = false;
			}
			if (glowFire.transform.localScale != Vector3.zero) {
				glowFire.transform.localScale = Vector3.Lerp (glowFire.transform.localScale, Vector3.zero, 0.03f);
			}
			if (shadowBG.color != noShadowColor) {
				shadowBG.color = Color.Lerp (shadowBG.color, noShadowColor, 0.02f);
			}
			if (lueurSR.color != transparent) {
				lueurSR.color = Color.Lerp (lueurSR.color, transparent, 0.02f);
			}
		}
	}

	public void InstantiateProjectile () {
		GameObject projectile = Instantiate (projectilePrefab, Vector3.zero, this.gameObject.transform.rotation);
		projectile.transform.SetParent (this.gameObject.transform);
		projectile.transform.localPosition = new Vector3 (1, 0, -2);
	}

	public void BonusPointsUp () {
		if (bonusPoints < 3) {
			bonusPoints++;
			if (bonusPoints == 2) {
				if (Random.Range (0, 2) == 0) {
					congratsTxt.text = "Woaw";
					congratsTxt.gameObject.GetComponent<Animator> ().Play ("Congrats");
				} else {
					congratsTxt.text = "On Fire !";
					congratsTxt.gameObject.GetComponent<Animator> ().Play ("Congrats");
				}
			} else if (bonusPoints == 3) {
				if (Random.Range (0, 2) == 0) {
					congratsTxt.text = "Fantastic";
					congratsTxt.gameObject.GetComponent<Animator> ().Play ("Congrats");
				} else {
					congratsTxt.text = "Amazing";
					congratsTxt.gameObject.GetComponent<Animator> ().Play ("Congrats");
				}
			}
		}
	}

	public void BonusPointsReset () {
		bonusPoints = 0;
	}

}
