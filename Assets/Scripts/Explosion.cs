using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

	public int hardness;

	public AudioClip popSound;
	public AudioClip clayBreakSound;

	public AudioSource audioSourcePop;

	void Start () {
		if (hardness == 0) {
			audioSourcePop.PlayOneShot (popSound);
		} else if (hardness == 1) {
			audioSourcePop.PlayOneShot (clayBreakSound);
		}
	}

}
