using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalStateController : MonoBehaviour {

	int levelNum;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (transform.gameObject);
		levelNum = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setLevel(int level) {
		levelNum = level;
		Debug.Log ("new level: " + levelNum);
	}

	public int getLevel() {
		return levelNum;
	}

	public bool gameIsOver() {
		return levelNum == 3;
	}
}
