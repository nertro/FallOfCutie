using UnityEngine;
using System.Collections;

public class StartScreenLoad : MonoBehaviour {
    private bool newLevel = false;
    public string newLevelName;

	void Update () {
        if (this.GetComponent<AudioSource>().isPlaying )
        {
            newLevel = true;
        }
        if (!this.GetComponent<AudioSource>().isPlaying && newLevel)
        {
            Application.LoadLevel(newLevelName);
        }
	}
}
