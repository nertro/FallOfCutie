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
            if(newLevelName == "explore")
            {
                PlayerPrefs.SetInt("foc_isExploreModeOn", 1);
                newLevelName = "game";
            }
            else if (newLevelName == "game")
            {
                PlayerPrefs.SetInt("foc_isExploreModeOn", 0);
            }

            Application.LoadLevel(newLevelName);
        }
	}
}
