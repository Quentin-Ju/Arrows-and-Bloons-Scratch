using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	float randAngle;

	public int bloonCount;

	int place1;
	int place2;
	int place3;

	List<int> listR = new List<int>();

	public GameObject redBloon;
	public GameObject blueBloon;
	public GameObject greenBloon;
	public GameObject yellowBloon;
	public GameObject purpleBloon;
	public GameObject redPigeon;
	public GameObject bluePigeon;
	public GameObject greenPigeon;
	public GameObject yellowPigeon;
	public GameObject purplePigeon;
	public GameObject interCanvas;
	public GameObject confettiPS;

	bool canSpawn = true;

	void Update () {
		if (bloonCount == 0 && !GameManager.gm.menu && canSpawn) {
			SpawnBloons ();
		}
	}

	void SpawnBloons () {
		randAngle = Random.Range (0.0f, 360.0f);
		switch (LevelManager.lm.level) {
		case 1:
			bloonCount = 3;
			for (int i = 0; i < 3; i++) {
				Instantiate (redBloon, new Vector3 (Mathf.Cos (Mathf.Deg2Rad * (randAngle + 120 * i)) * 2.5f, Mathf.Sin (Mathf.Deg2Rad * (randAngle + 120 * i)) * 2.5f, 0), Quaternion.identity);
			}
			break;
		case 2:
			bloonCount = 8;
			for (int i = 0; i < 8; i++) {
				Instantiate (redBloon, new Vector3 (Mathf.Cos (Mathf.Deg2Rad * (randAngle + 45 * i)) * 2.5f, Mathf.Sin (Mathf.Deg2Rad * (randAngle + 45 * i)) * 2.5f, 0), Quaternion.identity);
			}
			break;
		case 3:
			bloonCount = 8;
			RangeList (8);
			place1 = listR [Random.Range (0, 8)];
			listR.Remove (place1);
			place2 = listR [Random.Range (0, 7)];
			for (int i = 0; i < 8; i++) {
				if (i == place1 || i == place2) {
					Instantiate (blueBloon, new Vector3 (Mathf.Cos (Mathf.Deg2Rad * (randAngle + 45 * i)) * 2.5f, Mathf.Sin (Mathf.Deg2Rad * (randAngle + 45 * i)) * 2.5f, 0), Quaternion.identity);
				} else {
					Instantiate (redBloon, new Vector3 (Mathf.Cos (Mathf.Deg2Rad * (randAngle + 45 * i)) * 2.5f, Mathf.Sin (Mathf.Deg2Rad * (randAngle + 45 * i)) * 2.5f, 0), Quaternion.identity);
				}
			}
			break;
		case 4:
			bloonCount = 8;
			RangeList (7);
			place1 = listR [Random.Range (0, 7)];
			listR.Remove (place1);
			place2 = listR [Random.Range (0, 6)];
			listR.Remove (place2);
			place3 = listR [Random.Range (0, 5)];
			for (int i = 0; i < 7; i++) {
				if (i == place1 || i == place2 || i == place3) {
					Instantiate (blueBloon, new Vector3 (Mathf.Cos (Mathf.Deg2Rad * (randAngle + 51.43f * i)) * 2.5f, Mathf.Sin (Mathf.Deg2Rad * (randAngle + 51.43f * i)) * 2.5f, 0), Quaternion.identity);
				} else {
					Instantiate (redBloon, new Vector3 (Mathf.Cos (Mathf.Deg2Rad * (randAngle + 51.43f * i)) * 2.5f, Mathf.Sin (Mathf.Deg2Rad * (randAngle + 51.43f * i)) * 2.5f, 0), Quaternion.identity);
				}
			}
			Instantiate (yellowBloon, Vector3.zero, Quaternion.identity);
			break;
		case 5:
			bloonCount = 8;
			RangeList (7);
			place1 = listR [Random.Range (0, 7)];
			listR.Remove (place1);
			place2 = listR [Random.Range (0, 6)];
			listR.Remove (place2);
			place3 = listR [Random.Range (0, 5)];
			for (int i = 0; i < 7; i++) {
				if (i == place1 || i == place2) {
					Instantiate (blueBloon, new Vector3 (Mathf.Cos (Mathf.Deg2Rad * (randAngle + 51.43f * i)) * 2.5f, Mathf.Sin (Mathf.Deg2Rad * (randAngle + 51.43f * i)) * 2.5f, 0), Quaternion.identity);
				} else if (i == place3) {
					Instantiate (greenBloon,new Vector3 (Mathf.Cos (Mathf.Deg2Rad * (randAngle + 51.43f * i)) * 2.5f, Mathf.Sin (Mathf.Deg2Rad * (randAngle + 51.43f * i)) * 2.5f, 0), Quaternion.identity);
				} else {
					Instantiate (redBloon, new Vector3 (Mathf.Cos (Mathf.Deg2Rad * (randAngle + 51.43f * i)) * 2.5f, Mathf.Sin (Mathf.Deg2Rad * (randAngle + 51.43f * i)) * 2.5f, 0), Quaternion.identity);
				}
			}
			Instantiate (yellowBloon, Vector3.zero, Quaternion.identity);
			break;
		case 6:
			bloonCount = 8;
			for (int i = 0; i < 8; i++) {
				Instantiate (greenBloon, new Vector3 (Mathf.Cos (Mathf.Deg2Rad * (randAngle + 45 * i)) * 2.5f, Mathf.Sin (Mathf.Deg2Rad * (randAngle + 45 * i)) * 2.5f, 0), Quaternion.identity);
			}
			break;
		case 7:
			bloonCount = 8;
			for (int i = 0; i < 8; i++) {
				Instantiate (blueBloon, new Vector3 (Mathf.Cos (Mathf.Deg2Rad * (randAngle + 45 * i)) * 2.5f, Mathf.Sin (Mathf.Deg2Rad * (randAngle + 45 * i)) * 2.5f, 0), Quaternion.identity);
			}
			break;
		case 8:
			bloonCount = 10;
			RangeList (6);
			place1 = listR [Random.Range (0, 6)];
			listR.Remove (place1);
			place2 = listR [Random.Range (0, 5)];
			listR.Remove (place2);
			place3 = listR [Random.Range (0, 4)];
			for (int i = 0; i < 6; i++) {
				if (i == place1 || i == place2) {
					Instantiate (redBloon, new Vector3 (Mathf.Cos (Mathf.Deg2Rad * (randAngle + 60 * i)) * 2.5f, Mathf.Sin (Mathf.Deg2Rad * (randAngle + 60 * i)) * 2.5f, 0), Quaternion.identity);
				} else if (i == place3) {
					Instantiate (greenBloon, new Vector3 (Mathf.Cos (Mathf.Deg2Rad * (randAngle + 60 * i)) * 2.5f, Mathf.Sin (Mathf.Deg2Rad * (randAngle + 60 * i)) * 2.5f, 0), Quaternion.identity);
				} else {
					Instantiate (blueBloon, new Vector3 (Mathf.Cos (Mathf.Deg2Rad * (randAngle + 60 * i)) * 2.5f, Mathf.Sin (Mathf.Deg2Rad * (randAngle + 60 * i)) * 2.5f, 0), Quaternion.identity);
				}
			}
			for (int i = 0; i < 4; i++) {
				Instantiate (yellowBloon, Vector3.zero, Quaternion.identity);
			}
			break;
		case 9:
			bloonCount = 10;
			RangeList (7);
			place1 = listR [Random.Range (0, 7)];
			listR.Remove (place1);
			place2 = listR [Random.Range (0, 6)];
			listR.Remove (place2);
			place3 = listR [Random.Range (0, 5)];
			for (int i = 0; i < 6; i++) {
				if (i == place1 || i == place2 || i == place3) {
					Instantiate (blueBloon, new Vector3 (Mathf.Cos (Mathf.Deg2Rad * (randAngle + 60 * i)) * 2.5f, Mathf.Sin (Mathf.Deg2Rad * (randAngle + 60 * i)) * 2.5f, 0), Quaternion.identity);
				} else {
					Instantiate (greenBloon, new Vector3 (Mathf.Cos (Mathf.Deg2Rad * (randAngle + 60 * i)) * 2.5f, Mathf.Sin (Mathf.Deg2Rad * (randAngle + 60 * i)) * 2.5f, 0), Quaternion.identity);
				}
			}
			for (int i = 0; i < 4; i++) {
				Instantiate (yellowBloon, Vector3.zero, Quaternion.identity);
			}
			break;
		case 10:
			bloonCount = 10;
			for (int i = 0; i < 8; i++) {
				Instantiate (redPigeon, new Vector3 (Mathf.Cos (Mathf.Deg2Rad * (randAngle + 45 * i)) * 2.5f, Mathf.Sin (Mathf.Deg2Rad * (randAngle + 45 * i)) * 2.5f, 0), Quaternion.identity);
			}
			for (int i = 0; i < 2; i++) {
				Instantiate (purplePigeon, Vector3.zero, Quaternion.identity);
			}
			break;
		case 11:
			bloonCount = 3;
			for (int i = 0; i < 2; i++) {
				Instantiate (yellowPigeon, Vector3.zero, Quaternion.identity);
			}
			Instantiate (purplePigeon, Vector3.zero, Quaternion.identity);
			break;
		case 12:
			bloonCount = 4;
			Instantiate (greenPigeon, new Vector3 (Mathf.Cos (Mathf.Deg2Rad * (randAngle)) * 2.5f, Mathf.Sin (Mathf.Deg2Rad * (randAngle)) * 2.5f, 0), Quaternion.identity);
			for (int i = 0; i < 2; i++) {
				Instantiate (yellowPigeon, Vector3.zero, Quaternion.identity);
			}
			Instantiate (purplePigeon, Vector3.zero, Quaternion.identity);
			break;
		case 13:
			bloonCount = 8;
			Instantiate (greenPigeon, new Vector3 (Mathf.Cos (Mathf.Deg2Rad * (randAngle)) * 2.5f, Mathf.Sin (Mathf.Deg2Rad * (randAngle)) * 2.5f, 0), Quaternion.identity);
			Instantiate (bluePigeon, new Vector3 (Mathf.Cos (Mathf.Deg2Rad * (randAngle + 180)) * 2.5f, Mathf.Sin (Mathf.Deg2Rad * (randAngle + 180)) * 2.5f, 0), Quaternion.identity);
			for (int i = 0; i < 3; i++) {
				Instantiate (yellowPigeon, Vector3.zero, Quaternion.identity);
				Instantiate (purplePigeon, Vector3.zero, Quaternion.identity);
			}
			break;
		case 14:
			bloonCount = 8;
			for (int i = 0; i < 8; i++) {
				Instantiate (redPigeon, new Vector3 (Mathf.Cos (Mathf.Deg2Rad * (randAngle + 45 * i)) * 2.5f, Mathf.Sin (Mathf.Deg2Rad * (randAngle + 45 * i)) * 2.5f, 0), Quaternion.identity);
			}
			break;
		case 15:
			bloonCount = 7;
			for (int i = 0; i < 7; i++) {
				Instantiate (bluePigeon, new Vector3 (Mathf.Cos (Mathf.Deg2Rad * (randAngle + 51.43f * i)) * 2.5f, Mathf.Sin (Mathf.Deg2Rad * (randAngle + 51.43f * i)) * 2.5f, 0), Quaternion.identity);
			}
			break;
		case 16:
			bloonCount = 7;
			for (int i = 0; i < 7; i++) {
				Instantiate (yellowPigeon, Vector3.zero, Quaternion.identity);
			}
			break;
		case 17 :
			bloonCount = 8;
			for (int i = 0; i < 8; i++) {
				Instantiate (greenPigeon, new Vector3 (Mathf.Cos (Mathf.Deg2Rad * (randAngle + 45 * i)) * 2.5f, Mathf.Sin (Mathf.Deg2Rad * (randAngle + 45 * i)) * 2.5f, 0), Quaternion.identity);
			}
			break;
		case 18:
			bloonCount = 4;
			for (int i = 0; i < 4; i++) {
				Instantiate (purplePigeon, Vector3.zero, Quaternion.identity);
			}
			break;
		case 19:
			bloonCount = 6;
			for (int i = 0; i < 6; i++) {
				Instantiate (purplePigeon, Vector3.zero, Quaternion.identity);
			}
			break;
		default:
			bloonCount = 10;
			Instantiate (purplePigeon, Vector3.zero, Quaternion.identity);
			Instantiate (yellowPigeon, Vector3.zero, Quaternion.identity);
			for (int i = 0; i < 8; i++) {
				if (Random.Range (0, 3) == 1) {
					Instantiate (redPigeon, new Vector3 (Mathf.Cos (Mathf.Deg2Rad * (randAngle + 45 * i)) * 2.5f, Mathf.Sin (Mathf.Deg2Rad * (randAngle + 45 * i)) * 2.5f, 0), Quaternion.identity);
				} else if (Random.Range (0, 3) > 0) {
					Instantiate (bluePigeon, new Vector3 (Mathf.Cos (Mathf.Deg2Rad * (randAngle + 45 * i)) * 2.5f, Mathf.Sin (Mathf.Deg2Rad * (randAngle + 45 * i)) * 2.5f, 0), Quaternion.identity);
				} else {
					Instantiate (greenPigeon, new Vector3 (Mathf.Cos (Mathf.Deg2Rad * (randAngle + 45 * i)) * 2.5f, Mathf.Sin (Mathf.Deg2Rad * (randAngle + 45 * i)) * 2.5f, 0), Quaternion.identity);
				}
			}
			break;
		}
	}

	void RangeList (int count) {
		listR.Clear ();
		for (int i = 0; i < count; i++) {
			listR.Add (i);
		}
	}

	public void NextLevel () {
		canSpawn = true;
		interCanvas.SetActive (false);
		LevelManager.lm.LevelUp ();
	}

	public void BloonDestroyed () {
		bloonCount--;
		if (bloonCount == 0) {
			Instantiate (confettiPS, Vector3.zero, Quaternion.identity);
			canSpawn = false;
			interCanvas.SetActive (true);
		}
	}
}
