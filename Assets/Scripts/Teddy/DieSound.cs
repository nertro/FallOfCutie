using UnityEngine;
using System.Collections;

public class DieSound : MonoBehaviour {
    private AudioSource[] sources;
    private int currentSource;

	void Start () {
        sources = GetComponents<AudioSource>();
        currentSource = Random.Range(0, sources.Length);
        sources[currentSource].Play();
	}
	
	// Update is called once per frame
	void Update () {
        if (!sources[currentSource].isPlaying)
        {
            Destroy(this.gameObject);
        }
	}
}
