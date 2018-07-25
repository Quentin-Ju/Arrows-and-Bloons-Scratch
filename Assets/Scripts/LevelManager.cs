using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameAnalyticsSDK;

public class LevelManager : MonoBehaviour {

	public static LevelManager lm;

	public Spawner spawnerScript;

	public Text levelTxt;
	public Text numberArrowsTxt;

	public int level;
	public int charges;

	void Awake () {
		if (lm == null) {
			lm = this.gameObject.GetComponent<LevelManager> ();
		}
		level = 1;
		charges = 20;
		GameAnalytics.NewProgressionEvent (GAProgressionStatus.Start, "Level 1");
	}

	public void LevelUp () {
		GameAnalytics.NewProgressionEvent (GAProgressionStatus.Complete, "Level " + level.ToString());
		level++;
		GameAnalytics.NewProgressionEvent (GAProgressionStatus.Start, "Level " + level.ToString());
		if (level >= 14 && level <= 19) {
			charges = 8;
		} else if (level == 5 || level == 7 || level == 13) {
			charges = 10;
		} else if (level == 11) {
			charges = 4;
		} else if (level == 12) {
			charges = 6;
		} else {
			charges = 12;
		}
		UpdateUI ();
	}

	void UpdateUI () {
		levelTxt.text = "Level " + level.ToString ();
		numberArrowsTxt.text = "x " + charges.ToString ();
	}

	public void ArrowShot () {
		charges--;
		if (charges == 0) {
			Invoke ("Check", 0.8f);
		}
		UpdateUI ();
	}

	public void Check () {
		if (spawnerScript.bloonCount > 0 && charges <= 0) {
			GameAnalytics.NewProgressionEvent (GAProgressionStatus.Fail, "Level " + level.ToString());
			GameManager.gm.EndGame ();
		}
	}
}
