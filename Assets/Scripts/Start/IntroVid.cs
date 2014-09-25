using UnityEngine;
using System.Collections;

public class IntroVid : MonoBehaviour {
	public MovieTexture movie;

	void Start () {
		movie.Play();
	}
	void Update () {
		if (!movie.isPlaying) {
			Application.LoadLevel("start");
		}
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.LoadLevel("start");
		}
	}

	void ScaleTexture()
	{

	}
}
