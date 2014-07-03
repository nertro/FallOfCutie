using UnityEngine;
using System.Collections;

public class ExitTestLevels : MonoBehaviour {

	void Update () {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
	}
}
