using UnityEngine;
using System.Collections;

public class SetScoresToZero : MonoBehaviour {

	void Update () {
        if (Input.GetKey(KeyCode.E))
        {
            PlayerPrefs.DeleteAll();
        }
	}
}
