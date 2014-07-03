using UnityEngine;
using System.Collections;
using System;

public class ResizeTexture : MonoBehaviour {
	private GUITexture guiTexture;
	private float screenAspectRatio;
	private float textureAspectRatio;

	// Use this for initialization
	void Start () {
		this.guiTexture = gameObject.GetComponent<GUITexture>();
		screenAspectRatio = Screen.width / Screen.height;
		float tHeight = guiTexture.texture.height;
		textureAspectRatio = Convert.ToSingle(guiTexture.texture.width) / Convert.ToSingle(guiTexture.texture.height);
		Debug.Log((float)guiTexture.texture.height);
		Debug.Log(textureAspectRatio);
		ScaleScreen();
	}

	void ScaleScreen()
	{
		float scaledHeight;
		float scaledWidth;

		if (textureAspectRatio <= screenAspectRatio) 
		{
			scaledHeight = Screen.height;
			scaledWidth = Screen.height * textureAspectRatio;
			Debug.Log(1);
		}
		else
		{
			scaledWidth = Screen.width;
			scaledHeight = Screen.width / textureAspectRatio;
		}

		float xPos = Screen.width / 2 - (scaledWidth / 2);
		float yPos = Screen.height / 2 - (scaledHeight / 2);
		guiTexture.pixelInset = new Rect(xPos, yPos, scaledWidth, scaledHeight);
		Debug.Log(scaledHeight);
		Debug.Log(scaledWidth);
	}
}
