using UnityEngine;
using System.Collections;

public class ShaketweenEffect : MonoBehaviour {

	// Use this for initialization
	void Start () {

		// adding the tween rotation to coin image
		iTween.ShakePosition(this.gameObject, iTween.Hash("x", 0.05,"y", 0.05, "easeType", "easeInOutCirc", "loopType", "loop", "delay", .2));

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
