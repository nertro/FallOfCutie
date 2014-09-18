using UnityEngine;
using System.Collections;

public class TeddyBasherNav : MonoBehaviour {
    private bool navigate = false;
    private bool start = true;
    private NavMeshAgent navMeshAgent;
    private GameObject player;
    private GameObject chaser;
    private GameObject lastNode;
    private GameObject newNode;
    private GameObject firstNode;
    private WayPointManager waypointManager;
	private TeddyCount teddyCount;

    private Vector3 DebugStart;
    private Vector3 DebugEnd;

    void Start()
    {
        this.navMeshAgent = this.GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        chaser = GameObject.FindGameObjectWithTag("Chaser");
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

    void OnDrawGizmos()
    {
        Gizmos.DrawLine(DebugStart, DebugEnd);
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
        else if (chaser == null && navMeshAgent.destination != player.transform.position)
        {
            if (chaser == null)
            {
                navMeshAgent.destination = player.transform.position;
            }
        }
        else
        {
            if (navMeshAgent.destination == player.transform.position && chaser != null)
            {
                newNode = waypointManager.GetNearestNode(waypointManager.ReturnAllNodes(), GetTargetPosition(), lastNode);
            }
            if (navMeshAgent.remainingDistance <= 2)
            {
                newNode = waypointManager.GetNearestNode(waypointManager.ReturnAllNodes(), GetTargetPosition(), lastNode);
                lastNode = newNode;
                navMeshAgent.SetDestination(newNode.transform.position);
            }
        }
    }

    Vector3 GetTargetPosition()
    {
        Vector3 chaserVectorToChasingPoint = chaser.GetComponent<TeddyChaserNav>().VectorToChasePoint();
        Vector3 chaserVectorToTargetPoint = chaserVectorToChasingPoint * 1.5f;
        Vector3 targetPoint = chaser.transform.position + chaserVectorToTargetPoint;
        DebugStart = chaser.transform.position;
        DebugEnd = targetPoint;
        return targetPoint;
    }
}
