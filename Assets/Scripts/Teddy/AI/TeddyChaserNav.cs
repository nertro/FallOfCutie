using UnityEngine;
using System.Collections;

public class TeddyChaserNav : MonoBehaviour {
    private GameObject player;
    private GameObject chasePoint;
    private bool navigate = false;
    private bool start = true;
    private NavMeshAgent navMeshAgent;
    private GameObject lastNode;
    private GameObject newNode;
    private GameObject firstNode;
    private WayPointManager waypointManager;
	private TeddyCount teddyCount;

    void Start() {
        this.navMeshAgent = this.GetComponent<NavMeshAgent>();
        waypointManager = GameObject.FindGameObjectWithTag("WaypointManager").GetComponent<WayPointManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        chasePoint = GameObject.Find("Player/ChasePoint");
		teddyCount = GameObject.FindGameObjectWithTag("Counter").GetComponent<TeddyCount>();
        firstNode = waypointManager.ReturnRandomNode();
        newNode = firstNode;
        lastNode = newNode;
    }

	void Update () {
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
            if (navMeshAgent.destination == player.transform.position)
            {
                newNode = waypointManager.ReturnRandomNode();
            }
            if (navMeshAgent.remainingDistance <= 2)
            {
                newNode = waypointManager.GetNearestNode(newNode.GetComponent<Node>().availableNodes, player.transform.position, lastNode);
                lastNode = newNode;
                navMeshAgent.SetDestination(newNode.transform.position);
            }
        }
    }

    public Vector3 VectorToChasePoint()
    {
        Vector3 vect = chasePoint.transform.position - this.transform.position;
        return vect;
    }
}
