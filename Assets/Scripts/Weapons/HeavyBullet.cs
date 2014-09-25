﻿using UnityEngine;
using System.Collections;

public class HeavyBullet : MonoBehaviour {

    public GameObject dieSound;
	private GameObject hitmarker;
	private GameManager gameManager;
	
	void Start()
	{
		gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
		hitmarker = GameObject.FindGameObjectWithTag("UI").GetComponent<GameGUI>().hitmarker;
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Chaser" || other.gameObject.tag == "Ambusher" || other.gameObject.tag == "Basher")
        {
			hitmarker.SetActive(true);
            other.gameObject.GetComponent<TeddyHealthAndAttack>().health -= 50;

            if (other.gameObject.GetComponent<TeddyHealthAndAttack>().health <= 0)
            {
                Instantiate(dieSound, this.transform.position, Quaternion.identity);
                other.gameObject.GetComponent<NavMeshAgent>().enabled = false;
                other.gameObject.rigidbody.isKinematic = true;
                other.gameObject.GetComponent<Animator>().speed = 1.7f;
                other.gameObject.GetComponent<Animator>().Play("dying");
				if (!other.gameObject.GetComponent<TeddyHealthAndAttack>().scoreAdded) 
				{
					gameManager.AddOneToScore();
					other.gameObject.GetComponent<TeddyHealthAndAttack>().scoreAdded = true;
				}
            }
            else
            {
                other.gameObject.GetComponent<Animator>().Play("Hit");
            }


        }

        Destroy(this.gameObject);
    }
}
