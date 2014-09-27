using UnityEngine;
using System.Collections;

public class ResizeMenuScreen : MonoBehaviour {
	private float screenAspect;
	private float textureAspect;

	// Use this for initialization
	void Start () {
		screenAspect = Screen.width / Screen.height;
		float tHeight = 1080f;
		float tWidth = 1920f;
		textureAspect = tWidth / tHeight;
		ScaleScreen();
	}
	
	void ScaleScreen()
	{
		float scaledHeight;
		float scaledWidth;
		float scaledWidthPercent = (float)Screen.width / (1920f / 100f);;
		float scaledHeightPercent = (float)Screen.height / (1080f / 100f);;
		float xPos = this.gameObject.transform.localPosition.x;
		float yPos = this.gameObject.transform.localPosition.y;
		if (textureAspect <= screenAspect) 
		{
			scaledHeight = Screen.height / 1080;
			scaledWidth = textureAspect;
			Debug.Log("width "+scaledWidth);
			Debug.Log("ScreenAspect "+ screenAspect);
			Debug.Log("aspect"+ textureAspect);
			xPos = Screen.width / 2 - (scaledWidth / 2);
		}
		else
		{
			Debug.Log("Percent "+ scaledWidthPercent);
			scaledWidth = scaledWidthPercent /100f;
			scaledHeight = Screen.width / textureAspect;
			scaledHeightPercent = scaledHeight / (1080f/100f);
			scaledHeight = scaledHeightPercent / 100f;
			yPos = ((float)Screen.height - (scaledHeightPercent * 10.08f)) / 8;
			Debug.Log("ScreenWidth "+ Screen.width);
			Debug.Log("ScreenHeight "+ Screen.height);
			Debug.Log("Texture Height "+ (Screen.width / textureAspect));
			Debug.Log(yPos);
		}
		this.gameObject.transform.localScale = new Vector3( scaledWidth, scaledHeight);
		this.gameObject.transform.localPosition = new Vector2 (xPos, yPos);
	}
}
