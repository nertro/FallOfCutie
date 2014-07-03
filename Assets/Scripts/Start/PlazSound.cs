using UnityEngine;
using System.Collections;

public class PlazSound : MonoBehaviour {

	void Start () {
		this.GetComponent<AudioSource>().Play();
	}
}
