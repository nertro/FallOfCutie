using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    private GameObject player;
    private int score;
	private int bulletsLeft;
	private bool spawnItems = false;
	private bool spawningItems = false;
	private WayPointManager wayPointManager;
	private Vector3 hammerPosition;
	private Quaternion hammerRotation;

	public Quaternion HammerRotation {
		get {
			return hammerRotation;
		}
		set {
			hammerRotation = value;
		}
	}

	public Vector3 HammerPosition {
		get {
			return hammerPosition;
		}
		set {
			hammerPosition = value;
		}
	}

	public GameObject SMGMag;
	public GameObject HeavyMag;

	public bool SpawningItems {
		get {
			return spawningItems;
		}
		set {
			spawningItems = value;
		}
	}

	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        PlayerPrefs.SetInt("currentScore", 0);
		wayPointManager = GameObject.FindGameObjectWithTag("WaypointManager").GetComponent<WayPointManager>();
	}

	void Update () {
        if (player.GetComponent<PlayerHealth>().IsDead())
        {
            PlayerPrefs.SetInt("currentScore", score);
            Application.LoadLevel("highscore");
        }
		if (!GameObject.FindGameObjectWithTag("Counter").GetComponent<TeddyCount>().wave) 
		{
			spawnItems = true;
		}
		if(spawnItems)
		{
			if(!spawningItems)
			{
			 	SpawnItems();
			}
			spawnItems = false;
		}
	}

    public GameObject Player()
    {
        return player;
    }

    public void AddOneToScore()
    {
        score++;
    }

	public int GetScore()
	{
		return score;
	}

	public int BulletsLeft {
		get {
			return bulletsLeft;
		}
		set {
			bulletsLeft = value;
		}
	}

	void SpawnItems()
	{
		spawningItems = true;
		int freeNodes = wayPointManager.NodeWithoutItems();
		int magCount = Random.Range(1,10);
		while (magCount * 2 > freeNodes) 
		{
			magCount = Random.Range(1,10);
			if(freeNodes <= 0)
			{
				magCount = 0;
				break;
			}
		}

		InstantiateAmmo(SMGMag, magCount);
		InstantiateAmmo(HeavyMag, magCount);
	}

	void InstantiateAmmo(GameObject ammo, int magCount)
	{
		for (int i = 0; i < magCount; i++) 
		{
			GameObject[] nodes = wayPointManager.ReturnAllNodes();
			for (int z = 0; z < nodes.Length; z++) {
				if(!nodes[z].GetComponent<Node>().HasItem)
				{
					Instantiate(ammo, nodes[z].transform.position, Quaternion.identity);
					nodes[z].GetComponent<Node>().HasItem = true;
					break;
				}
			}
		}
	}
}
