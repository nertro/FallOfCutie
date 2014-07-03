using UnityEngine;
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
                gameManager.AddOneToScore();
                Destroy(other.gameObject);
            }


        }

        Destroy(this.gameObject);
    }
}
