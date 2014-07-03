using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
    public int health = 100;
	private bool isDead = false;

	void Start () {
        PlayerPrefs.SetInt("currentScore", 0);
	}
	
	// Update is called once per frame
	void Update () {
        if (health <= 0)
        {
			isDead = true;
        }
	}

	public bool IsDead()
	{
		return isDead;
	}
}
