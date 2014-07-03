using UnityEngine;
using System.Collections;

public class ThrowHammer : MonoBehaviour {
    public float speed = 50;
    public GameObject throwArm;

	private GameObject hitmarker;
    private Animator animator;
    private Quaternion startRotation;
    private Vector3 startPosition;
    private bool thrown;
	private bool inAir;
	private float timer = 0;
    private AudioSource[] audioSources;
    public GameObject dieSound;
	private GameManager gameManager;
	private bool activated;

	public bool Activated {
		get {
			return activated;
		}
		set {
			activated = value;
		}
	}

    void Start()
    {
        this.animator = throwArm.gameObject.GetComponent<Animator>();
        this.audioSources = GetComponents<AudioSource>();
        this.startRotation = this.gameObject.transform.localRotation;
        this.startPosition = this.gameObject.transform.localPosition;
		gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
		thrown =false;
		inAir = false;
    }

    void Update()
    {
		if (activated) 
		{
			this.rigidbody.isKinematic = true;
			this.transform.localPosition = this.startPosition;
			this.transform.localRotation = this.startRotation;
			Debug.Log(startPosition);
			Debug.Log(startRotation);
			activated = false;
			Debug.Log("muddi");
		}
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("zuruck") &! thrown)
        {
            this.rigidbody.isKinematic = false;
            this.rigidbody.AddForce(this.transform.forward * speed, ForceMode.Impulse);
            this.audioSources[0].Play();
            this.gameObject.layer = LayerMask.NameToLayer("Default");
            this.GetComponent<BoxCollider>().enabled = true;
            thrown = true;
			Debug.Log(1);
        }
		else if (Vector3.Distance(this.transform.localPosition, this.startPosition) > 2) 
		{
			this.GetComponent<BoxCollider>().enabled = true;
			inAir = true;
			timer = 0;
		}
		else if (inAir && Vector3.Distance(this.transform.localPosition, this.startPosition) < 3 )
        {
            this.transform.localPosition = this.startPosition;
            this.transform.localRotation = this.startRotation;
			Debug.Log("2 " + startRotation);
            this.rigidbody.isKinematic = true;
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("idle") && this.transform.localPosition == this.startPosition)
        {
            this.gameObject.layer = LayerMask.NameToLayer("Weapons");
            this.GetComponent<BoxCollider>().enabled = false;
            thrown = false;
			inAir = false;
        }
		if (thrown) 
		{
			CountTimeInAir();
		}
		if (timer > 3) 
		{
			this.transform.localPosition = this.startPosition;
			this.transform.localRotation = this.startRotation;
			this.rigidbody.isKinematic = true;
		}
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Chaser" || other.gameObject.tag == "Ambusher" || other.gameObject.tag == "Basher" && thrown)
        {
            Instantiate(dieSound, this.transform.position, Quaternion.identity);
            gameManager.AddOneToScore();
            Destroy(other.gameObject);
        }
    }

	void CountTimeInAir()
	{
		timer += Time.deltaTime;
	}
}
