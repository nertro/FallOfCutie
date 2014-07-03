using UnityEngine;
using System.Collections;

public class TeddyCount : MonoBehaviour {

    public int counter;
    public bool wave = true;
    public bool waveStart = true;
    private float timer = 0;
    private float interval = 3f;
    private GameObject prepareLabel;

	public int Counter 
	{
		get {
			return counter;
		}
	}

    void Start()
    {
        prepareLabel = GameObject.FindGameObjectWithTag("UI").transform.Find("Panel/PrepareLabel").gameObject;
    }

	void Update () {
        this.gameObject.GetComponent<UILabel>().text = counter.ToString();
        if (!wave)
        {
            StartNextWave();
        }
        else if (counter == 0 && wave &! waveStart)
        {
            wave = false;
			GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().SpawningItems = false;
        }
	}

    void StartNextWave()
    {
        timer += Time.deltaTime;
        prepareLabel.gameObject.SetActive(true);
        if (timer > interval)
        {
            wave = true;
            waveStart = true;
            prepareLabel.gameObject.SetActive(false);
            timer = 0;
        }
    }
}
