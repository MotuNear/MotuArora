using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnDestroyEvent : MonoBehaviour {
	public GameObject[] instantiatePrefabs;

	 bool isQuitting = false;

	void Start(){
		//don (gameObject);
		isQuitting = false;
	}

	void OnApplicationQuit () {
		isQuitting = true;
	}

	void OnDisable () {
		if (!isQuitting) {
		//	foreach (GameObject item in instantiatePrefabs) {
				//Instantiate (item, transform.position, transform.rotation);
				//Debug.Log ("Test "+gameObject.name);
			//}
			//DestroyImmediate (gameObject);
		}
	}

	void Update(){
		if (MenuManager.Instance != null) {
			if (MenuManager.Instance.Loading.activeSelf) {
				if (!isQuitting) {
					foreach (GameObject item in instantiatePrefabs) {
						Instantiate (item, transform.position, transform.rotation);
						Debug.Log ("Test " + gameObject.name);
					}
					isQuitting = true;
					//DestroyImmediate (gameObject);
				}
			}
		}
	}





}
