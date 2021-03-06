﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ScreenFader : MonoBehaviour
{
	public Image FadeImg;
	private float fadeInSpeed = 0.25f;
	private float fadeOutSpeed = 0.5f;

	void Awake()
	{
		FadeImg.rectTransform.localScale = new Vector2(Screen.width, Screen.height);
	}

	void Start() {
		StartScene();
	}

	void FadeToClear()
	{
		Color c = FadeImg.color;
		c.a -= 0.1f * fadeInSpeed;
		FadeImg.color = c;
		// Lerp the colour of the image between itself and argument color.
		//FadeImg.color = Color.Lerp(FadeImg.color, c, fadeOutSpeed * Time.deltaTime);
	}

	void FadeToOpaque()
	{
		Color c = FadeImg.color;
		c.a += 0.1f * fadeOutSpeed;
		FadeImg.color = c;
		// Lerp the colour of the image between itself and argument color.
		//FadeImg.color = Color.Lerp(FadeImg.color, c, fadeInSpeed * Time.deltaTime);
	}


	void StartScene()
	{
		StartCoroutine (StartSceneRoutine (Color.white));
	}
	
	public void EndScene(int SceneNumber, bool endGame)
	{
		StartCoroutine(EndSceneRoutine(SceneNumber, Color.white, endGame));
	}

	public IEnumerator StartSceneRoutine(Color color)
	{
		// Make sure the RawImage is enabled.
		color.a = 1.0f;
		FadeImg.color = color;
		FadeImg.enabled = true;

		while(FadeImg.color.a >= 0.02) {
			FadeToClear();
			yield return null;
		}
		color.a = 0.0f;
		FadeImg.color = color;
	}

	public IEnumerator EndSceneRoutine(int SceneNumber, Color color, bool endGame)
	{
		// Make sure the RawImage is enabled.
		color.a = 0.0f;
		FadeImg.color = color;
		FadeImg.enabled = true;

		while(FadeImg.color.a <= 0.98) {
			FadeToOpaque();
			yield return null;
		}
		color.a = 1.0f;
		FadeImg.color = color;
		if (endGame) {
			Debug.Log ("THE END");
		} else {
			SceneManager.LoadScene (SceneNumber);
		}
	}
} 