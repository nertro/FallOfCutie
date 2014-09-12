using UnityEngine;
using System.Collections;

public class DeactivateTeddySpawn : MonoBehaviour
{
    private Component[] teddySpawns;
    private int isExploreModeOn;


    void Awake()
    {
        
    }
    // Use this for initialization
	void Start () {
        isExploreModeOn = PlayerPrefs.GetInt("foc_isExploreModeOn");
        
        Debug.Log("foc_isExploreModeOn: " + isExploreModeOn);
        
        if(isExploreModeOn == 1)
        {
            teddySpawns = GameObject.Find("fOc_arena_FINAL").GetComponentsInChildren<TeddySpawn>();
            foreach(TeddySpawn ts in teddySpawns)
            {
                ts.enabled = false;
            }
        }

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
