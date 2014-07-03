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
	}
}
