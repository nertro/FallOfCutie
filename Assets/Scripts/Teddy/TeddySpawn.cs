using UnityEngine;
using System.Collections;

public class TeddySpawn : MonoBehaviour {
    private float timer = 0;
    private int counter = 0;
    private bool nextRound = false;
    public Transform teddy;
    private int TeddyCount = 3;
    public int Interval = 2;
    public GameObject spawnFloor;


    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Counter").GetComponent<TeddyCount>().wave && GameObject.FindGameObjectWithTag("Counter").GetComponent<TeddyCount>().waveStart)
        {
            Spawn();
        }
        else if(!GameObject.FindGameObjectWithTag("Counter").GetComponent<TeddyCount>().wave)
        {
            counter = 0;
            nextRound = true;
        }
        else if (GameObject.FindGameObjectWithTag("Counter").GetComponent<TeddyCount>().wave &! GameObject.FindGameObjectWithTag("Counter").GetComponent<TeddyCount>().waveStart)
        {
            if (nextRound)
            {
                StartNewWave();
            }
            Spawn();
        }
    }

    void StartNewWave()
    {
        TeddyCount += 5;
        nextRound = false;
    }

    void Spawn()
    {
        if (counter < TeddyCount)
        {
            timer += Time.deltaTime;
            if (spawnFloor.GetComponent<CheckIfSpawnPointIsFree>().isFree == false)
            {
                timer = 0;
            }
            else if (timer > Interval)
            {
                Instantiate(teddy, this.transform.position, Quaternion.identity);
                GameObject.FindGameObjectWithTag("Counter").GetComponent<TeddyCount>().counter++;
                timer = 0;
                counter++;
                GameObject.FindGameObjectWithTag("Counter").GetComponent<TeddyCount>().waveStart = false;
            }
        }
    }
}
