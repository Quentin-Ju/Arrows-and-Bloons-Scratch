using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager gm;

	public Text mainScoreDisplay;
	public Text highscoreDisplay;

	public Image playAgainImg;

	public GameObject gameOverCanvas;
	public GameObject menuCanvas;
	public GameObject rewardedBT;

	int score;
	int highscore;
	int loseCount;

	public bool gameIsEnded;
	public bool menu;

	void Awake () {
		menu = true;
		if (gm == null) {
			gm = this.gameObject.GetComponent<GameManager> ();
		}

		highscore = PlayerPrefManager.GetHighscore ();
		highscoreDisplay.text = "Highscore: " + highscore.ToString();
		loseCount = PlayerPrefManager.GetLoseCount();
	}

	void Update () {
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && menu) {
			Launch ();
		}

		if (gameIsEnded) {
			if (Time.timeScale > 0.3f) {
				Time.timeScale -= 0.4f * Time.deltaTime;
			} else if (Time.timeScale != 0) {
				Time.timeScale = 0;
			}
			//playAgainImg.fillAmount -= 0.125f * Time.deltaTime;
		}
	}

	public void EndGame () {
		if (!gameIsEnded) {
			gameIsEnded = true;
			/*if (GameObject.Find ("AdManager").GetComponent<AdManager> ().IsAvailable ()) {
				rewardedBT.SetActive (true);
			}*/
			loseCount++;
			PlayerPrefManager.SetLoseCount (loseCount);
			gameOverCanvas.SetActive (true);
		}
	}

	public void Score (int points) {
		score += points;
		if (score > highscore) {
			highscore = score;
			highscoreDisplay.text = "Highscore: " + highscore.ToString();
			PlayerPrefManager.SetHighScore (highscore);
		}
		mainScoreDisplay.text = score.ToString ();
	}

	public void Launch () {
		menu = false;
		menuCanvas.SetActive (false);
	}

	public void Menu () {
		Time.timeScale = 1;
		SceneManager.LoadScene ("MainScene");
	}

	/*public void ShowRewardedVideo () {
		GameObject.Find ("AdManager").GetComponent<AdManager> ().ShowRewarded ();
		gameOverCanvas.SetActive (false);
		rewardedBT.SetActive (false);
	}*/
}