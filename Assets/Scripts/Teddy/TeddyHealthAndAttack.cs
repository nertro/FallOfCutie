using UnityEngine;
using System.Collections;

public class TeddyHealthAndAttack : MonoBehaviour {
    private float timer = 0;
    public float interval = 2;
    public int health = 100;
    private AudioSource[] audioSources;
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        this.navMeshAgent = this.GetComponent<NavMeshAgent>();
        audioSources = GetComponents<AudioSource>();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            audioSources[Random.Range(0, audioSources.Length)].Play();
            other.gameObject.GetComponent<PlayerHealth>().health--;
            GameObject.FindGameObjectWithTag("HP").GetComponent<UILabel>().text = other.gameObject.GetComponent<PlayerHealth>().health.ToString();
            GameObject.FindGameObjectWithTag("UI").GetComponent<GameGUI>().showPlush = true;
        }
    }

    void OnCollisionStay(Collision other)
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            if (other.gameObject.tag == "Player")
            {
                other.gameObject.GetComponent<PlayerHealth>().health--;
                GameObject.FindGameObjectWithTag("HP").GetComponent<UILabel>().text = other.gameObject.GetComponent<PlayerHealth>().health.ToString();
                timer = 0;
            }
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            timer = interval;
            GameObject.FindGameObjectWithTag("UI").GetComponent<GameGUI>().showPlush = false;
            GameObject.FindGameObjectWithTag("UI").GetComponent<GameGUI>().fadePlush = true;
        }
    }

    void OnDestroy()
    {
        if (GameObject.FindGameObjectWithTag("Counter").GetComponent<TeddyCount>().counter != null)
        {
            GameObject.FindGameObjectWithTag("Counter").GetComponent<TeddyCount>().counter--;
        }
    }

}
