using UnityEngine;
using System.Collections;

public class WayPointManager : MonoBehaviour {
    private GameObject[] nodes;
    private GameObject player;

    void Start()
    {
        nodes = GameObject.FindGameObjectsWithTag("Node");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public GameObject ReturnRandomNode()
    {
        int rand = Random.Range(0, nodes.Length - 1);
        return nodes[rand];
    }

    public GameObject[] ReturnAllNodes()
    {
        return nodes;
    }

    public GameObject GetNearestNode(GameObject[] nodes, Vector3 targetPosition, GameObject lastNode)
    {
        bool minDistNotSet = true;
        float minDist = 0;
        float newDist;
        GameObject nearestNode = null;
        for (int i = 0; i < nodes.Length; i++)
        {
            if (nodes[i] != lastNode)
            {
                if (minDistNotSet)
                {
                    minDist = Vector3.Distance(nodes[i].transform.position, targetPosition);
                    minDistNotSet = false;
                }
                newDist = Vector3.Distance(nodes[i].transform.position, targetPosition);
                if (newDist <= minDist)
                {
                    minDist = newDist;
                    nearestNode = nodes[i];
                }
            }
        }


        return nearestNode;
    }

    public bool PlayerIsInRange(GameObject other)
    {
        if (Vector3.Distance(player.transform.position, other.transform.position) < 8)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

	public int NodeWithoutItems()
	{
		int z = 0;


		for (int i = 0; i < nodes.Length; i++) 
		{
			if (!nodes[i].GetComponent<Node>().HasItem) 
			{
				z++;
			}
		}

		return z;
	}
}
