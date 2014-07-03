using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    public GameObject dieSound;
	private GameObject hitmarker;
	private GameManager gameManager;
	
	void Start()
	{
		hitmarker = GameObject.FindGameObjectWithTag("UI").GetComponent<GameGUI>().hitmarker;
		gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
	}
    
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Chaser" || other.gameObject.tag == "Ambusher" || other.gameObject.tag == "Basher")
        {
			hitmarker.SetActive(true);
            other.gameObject.GetComponent<TeddyHealthAndAttack>().health -= 3;

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
