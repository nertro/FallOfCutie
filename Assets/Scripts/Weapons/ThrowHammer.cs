using UnityEngine;
using System.Collections;

public class ThrowHammer : MonoBehaviour
{
    public float speed = 30;
    public GameObject throwArm;

    private GameObject hitmarker;
    private Animator animator;
    private bool thrown;
    private float timer = 0;
    private bool starting = true;
    private AudioSource[] audioSources;
    public GameObject dieSound;
    private GameManager gameManager;

    void Start()
    {
        this.animator = throwArm.gameObject.GetComponent<Animator>();
        this.audioSources = GetComponents<AudioSource>();
        starting = false;
        thrown = false;
    }

    void Update()
    {
        if (!thrown && this.transform.localPosition != gameManager.HammerPosition) //if weapon changes to fast, the hammer will not be in the right position
        {
            this.gameObject.transform.localRotation = gameManager.HammerRotation;
            this.gameObject.transform.localPosition = gameManager.HammerPosition;
        }

        if (throwArm.GetComponent<ThrowAnimation>().Punching)
        {
            this.GetComponent<BoxCollider>().enabled = true;
            this.throwArm.GetComponent<ThrowAnimation>().Punching = false;
        }

        if (throwArm.GetComponent<ThrowAnimation>().Throwing) //Make sure Hammer is in Startposition and throw
        {
            this.gameObject.transform.localPosition = gameManager.HammerPosition;
            this.gameObject.transform.localRotation = gameManager.HammerRotation;

            this.rigidbody.isKinematic = false;
            this.rigidbody.AddForce(this.transform.forward * speed, ForceMode.Impulse);
            this.audioSources[0].Play();
            throwArm.GetComponent<ThrowAnimation>().Throwing = false;

            this.gameObject.layer = LayerMask.NameToLayer("CollisionDetection");
            timer = 0;
            thrown = true;
            Debug.Log("thrown");
        }
        else if (thrown && Vector3.Distance(this.transform.localPosition, gameManager.HammerPosition) < 3 && timer > 0.2f) //if hammer is near start Position and was in air(timer), reset hammer position
        {
            this.rigidbody.isKinematic = true;
            this.transform.localPosition = gameManager.HammerPosition;
            this.transform.localRotation = gameManager.HammerRotation;
            this.gameObject.layer = LayerMask.NameToLayer("Weapons");
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
            this.transform.localPosition = gameManager.HammerPosition;
            this.transform.localRotation = gameManager.HammerRotation;
            this.gameObject.layer = LayerMask.NameToLayer("Weapons");
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
            other.gameObject.GetComponent<TeddyHealthAndAttack>().health = 0;
            other.gameObject.GetComponent<NavMeshAgent>().enabled = false;
            other.gameObject.rigidbody.isKinematic = true;
            other.gameObject.GetComponent<Animator>().speed = 1.7f;
            other.gameObject.GetComponent<Animator>().Play("dying");
        }
    }

    void CountTimeInAir()
    {
        timer += Time.deltaTime;
    }

    public void Activate()
    {
        this.rigidbody.isKinematic = true;
        if (gameManager == null)
        {
            gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
            gameManager.HammerRotation = this.transform.localRotation;
            gameManager.HammerPosition = this.transform.localPosition;
        }
        this.gameObject.transform.localPosition = gameManager.HammerPosition;
        this.gameObject.transform.localRotation = gameManager.HammerRotation;
        this.gameObject.layer = LayerMask.NameToLayer("Weapons");
        throwArm.GetComponent<ThrowAnimation>().Throwing = false;
        thrown = false;
        timer = 0;
    }
}
