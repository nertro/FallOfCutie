using UnityEngine;
using System.Collections;

public class ExitExplore : MonoBehaviour {

	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.Escape))
		{
              Application.LoadLevel("start");   
        }
	}
}
