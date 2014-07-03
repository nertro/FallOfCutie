using UnityEngine;
using System.Collections;

public class PickUpAmmo : MonoBehaviour {
	public GameObject SMGShootingPoint;
	public GameObject HeavyShootingPoint;
	public GameObject SMGSound;
	public GameObject HeavySound;

	private WayPointManager waypointManager;

	void Start()
	{
		waypointManager = GameObject.FindGameObjectWithTag("WaypointManager").GetComponent<WayPointManager>();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "HeavyAmmo") 
		{
			HeavyShootingPoint.GetComponent<ShootHeavy_sadfh>().BulletsLeft += 50;
			Instantiate(HeavySound, other.transform.position,Quaternion.identity);
			GameObject node = waypointManager.GetNearestNode(waypointManager.ReturnAllNodes(), other.transform.position, null);
			node.GetComponent<Node>().HasItem = false;
			Destroy(other.gameObject);
		}
		if (other.gameObject.tag == "SMGAmmo") 
		{
			SMGShootingPoint.GetComponent<ShootSMG>().BulletsLeft += 250;
			Instantiate(SMGSound, other.transform.position,Quaternion.identity);
			GameObject node = waypointManager.GetNearestNode(waypointManager.ReturnAllNodes(), other.transform.position, null);
			node.GetComponent<Node>().HasItem = false;
			Destroy(other.gameObject);
		}
	}
}