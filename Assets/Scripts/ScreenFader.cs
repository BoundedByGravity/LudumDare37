using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ScreenFader : MonoBehaviour
{
	public Image FadeImg;
	public float fadeInSpeed = 0.5f;
	public float fadeOutSpeed = 1.5f;

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
	
	public void EndScene(int SceneNumber)
	{
		StartCoroutine(EndSceneRoutine(SceneNumber, Color.white));
	}

	public IEnumerator StartSceneRoutine(Color color)
	{
		// Make sure the RawImage is enabled.
		color.a = 1.0f;
		FadeImg.color = color;
		FadeImg.enabled = true;

		while(FadeImg.color.a >= 0.05) {
			FadeToClear();
			yield return null;
		}
		color.a = 0.0f;
		FadeImg.color = color;
	}

	public IEnumerator EndSceneRoutine(int SceneNumber, Color color)
	{
		// Make sure the RawImage is enabled.
		color.a = 0.0f;
		FadeImg.color = color;
		FadeImg.enabled = true;

		while(FadeImg.color.a <= 0.95) {
			FadeToOpaque();
			yield return null;
		}
		color.a = 1.0f;
		FadeImg.color = color;
		SceneManager.LoadScene(SceneNumber);
	}
} 