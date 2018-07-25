using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class PlayerPrefManager {

	public static int GetHighscore() {
		if (PlayerPrefs.HasKey("Highscore")) {
			return PlayerPrefs.GetInt ("Highscore");
		} else {
			return 0;
		}
	}

	public static void SetHighScore(int Highscore) {
		PlayerPrefs.SetInt("Highscore",Highscore);
	}

	public static int GetLoseCount() {
		if (PlayerPrefs.HasKey("LoseCount")) {
			return PlayerPrefs.GetInt ("LoseCount");
		} else {
			return 0;
		}
	}

	public static void SetLoseCount(int LoseCount) {
		PlayerPrefs.SetInt("LoseCount",LoseCount);
	}
}
