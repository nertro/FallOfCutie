using UnityEngine;
using System.Collections;

public class ExitExplore : MonoBehaviour {

	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Application.loadedLevelName == "explore")
            {
                Application.LoadLevel("start");
            }
            else if(Application.loadedLevelName == "game")
            {
                
            }
        }
	}
}
