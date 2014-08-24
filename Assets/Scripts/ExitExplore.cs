using UnityEngine;
using System.Collections;

public class ExitExplore : MonoBehaviour {

	void Update () {
        if (Application.loadedLevelName == "explore" && Input.GetKeyDown(KeyCode.Escape))
        {
            Application.LoadLevel("start");
        }
	}
}
