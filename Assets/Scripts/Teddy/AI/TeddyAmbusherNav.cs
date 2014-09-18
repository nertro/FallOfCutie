using UnityEngine;
using System.Collections;

public class TeddyAmbusherNav : MonoBehaviour {
    private bool navigate = false;
    private bool start = true;
    private NavMeshAgent navMeshAgent;
    private GameObject player;
    private GameObject lastNode;
    private GameObject newNode;
    private GameObject firstNode;
    private WayPointManager waypointManager;
	private TeddyCount teddyCount;

    void Start()
    {
        this.navMeshAgent = this.GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        waypointManager = GameObject.FindGameObjectWithTag("WaypointManager").GetComponent<WayPointManager>();
		teddyCount = GameObject.FindGameObjectWithTag("Counter").GetComponent<TeddyCount>();
        firstNode = waypointManager.ReturnRandomNode();
        newNode = firstNode;
        lastNode = newNode;
    }

    void Update()
    {
        if (navigate && this.gameObject.GetComponent<TeddyHealthAndAttack>().health > 0)
        {
            if (start)
            {
                this.navMeshAgent.enabled = true;
                navMeshAgent.SetDestination(firstNode.transform.position);
                start = false;
            }
            GetNewTarget();
        }
        if (this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Dead"))
        {
            Destroy(this.gameObject);
        }

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "SpawnGround")
        {
            navigate = true;
        }
    }

    void GetNewTarget()
    {
        if (waypointManager.PlayerIsInRange(this.gameObject) || teddyCount.Counter == 1)
        {
            navMeshAgent.destination = player.transform.position;
        }
        else
        {
            if (navMeshAgent.remainingDistance <= 2 || navMeshAgent.destination == player.transform.position)
            {
                GetWaypointIsInFrontOfPlayer(waypointManager.ReturnAllNodes());
                lastNode = newNode;
                navMeshAgent.SetDestination(newNode.transform.position);
            }
        }
    }

    private void GetWaypointIsInFrontOfPlayer(GameObject[] nodes)
    {
        for (int i = 0; i < nodes.Length; i++)
        {
            Vector3 nodeDirection = nodes[i].transform.position - player.transform.position;
            float angle = Vector3.Angle(player.transform.forward, nodeDirection);

            if (Mathf.Abs(angle) < 35 && Mathf.Abs(angle) > -35)
            {
                if (Vector3.Distance(player.transform.position, nodes[i].transform.position) > 5)
                {
                    newNode = nodes[i];
                }
            }
        }
    }
}
