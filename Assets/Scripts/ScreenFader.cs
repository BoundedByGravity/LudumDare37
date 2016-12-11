using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ScreenFader : MonoBehaviour
{
	public Image FadeImg;
	public float fadeSpeed = 1.5f;
	public bool sceneStarting = true;


	void Awake()
	{
		FadeImg.rectTransform.localScale = new Vector2(Screen.width, Screen.height);
	}

	void Update()
	{
		// If the scene is starting...
		if (sceneStarting)
			// ... call the StartScene function.
			StartScene();
	}


	void FadeToClear()
	{
		FadeToColor(Color.clear);
	}

	void FadeToColor(Color color)
	{
		// Lerp the colour of the image between itself and argument color.
		FadeImg.color = Color.Lerp(FadeImg.color, color, fadeSpeed * Time.deltaTime);
	}


	void StartScene()
	{
		// Fade the texture to clear.
		FadeToClear();

		// If the texture is almost clear...
		if (FadeImg.color.a <= 0.05f)
		{
			// ... set the colour to clear and disable the RawImage.
			FadeImg.color = Color.clear;
			FadeImg.enabled = false;

			// The scene is no longer starting.
			sceneStarting = false;
		}
	}


	public IEnumerator EndSceneRoutine(int SceneNumber, Color color)
	{
		// Make sure the RawImage is enabled.
		FadeImg.enabled = true;
		while(!((FadeImg.color - color).grayscale <= (Color.white * 0.05f).grayscale)) {
			// Start fading towards black.
			FadeToColor(color);
			yield return null;
		}
		SceneManager.LoadScene(SceneNumber);
	}

	public void EndScene(int SceneNumber)
	{
		sceneStarting = false;
		StartCoroutine(EndSceneRoutine(SceneNumber, Color.black));
	}
} 