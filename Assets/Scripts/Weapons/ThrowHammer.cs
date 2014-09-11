using UnityEngine;
using System.Collections;

public class ThrowHammer : MonoBehaviour
{
    public float speed = 50;
    public GameObject throwArm;

    private GameObject hitmarker;
    private Animator animator;
    private Quaternion startRotation;
    private Vector3 startPosition;
    private bool thrown;
    private float timer = 0;
    private bool starting = true;
    private AudioSource[] audioSources;
    public GameObject dieSound;
    private GameManager gameManager;
    public bool Activated { get; set; }

    void Start()
    {
        this.animator = throwArm.gameObject.GetComponent<Animator>();
        this.audioSources = GetComponents<AudioSource>();
        if (starting)
        {
            starting = false;
            this.startRotation = this.gameObject.transform.localRotation;
            this.startPosition = this.gameObject.transform.localPosition;
        }
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        thrown = false;
        Debug.Log("startHammer");
    }

    void Update()
    {
        if (Activated) //Set hammer to StartPosition and Rotation, when chosen as weapon
        {
            this.rigidbody.isKinematic = true;
            this.gameObject.transform.localPosition = this.startPosition;
            this.gameObject.transform.localRotation = this.startRotation;
            this.Activated = false;
            thrown = false;
            timer = 0;
            Debug.Log("activated");
        }
        if (throwArm.GetComponent<ThrowAnimation>().Throwing) //Make sure Hammer is in Startposition and throw
        {
            this.gameObject.transform.localPosition = this.startPosition;
            this.gameObject.transform.localRotation = this.startRotation;

            this.rigidbody.isKinematic = false;
            this.rigidbody.AddForce(this.transform.forward * speed, ForceMode.Impulse);
            this.audioSources[0].Play();
            this.GetComponent<BoxCollider>().enabled = true;
            throwArm.GetComponent<ThrowAnimation>().Throwing = false;

            timer = 0;
            thrown = true;
            Debug.Log("thrown");
        }
        else if (thrown && Vector3.Distance(this.transform.localPosition, this.startPosition) < 3 && timer > 0.1f) //if hammer is near start Position and was in air(timer), reset hammer position
        {
            this.rigidbody.isKinematic = true;
            this.transform.localPosition = this.startPosition;
            this.transform.localRotation = this.startRotation;
            Debug.Log("back");
            thrown = false;
            timer = 0;
        }
        if (thrown)
        {
            Debug.Log(timer);
            CountTimeInAir();
        }
        if (timer > 3) //Reset Hammer if lost
        {
            this.transform.localPosition = this.startPosition;
            this.transform.localRotation = this.startRotation;
            this.rigidbody.isKinematic = true;
            thrown = false;
            timer = 0;
            Debug.Log("timer back");
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if ((other.gameObject.tag == "Chaser" || other.gameObject.tag == "Ambusher" || other.gameObject.tag == "Basher") && thrown)
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
