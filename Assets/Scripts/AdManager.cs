using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
using GameAnalyticsSDK;

public class AdManager : MonoBehaviour {

	void Awake () {
		if (!FB.IsInitialized) {
			FB.Init ();
		} else {
			FB.ActivateApp ();
		}
		GameAnalytics.Initialize ();
	}

	void Start () {
		DontDestroyOnLoad (gameObject);
	}
}
