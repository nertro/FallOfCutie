using UnityEngine;
using System.Collections;

public class ShootExplore : MonoBehaviour {
	public GameObject projectile;
	public float speed = 50;
	private ParticleEmitter shootParticles;
	private GameObject player;
	
	void Start()
	{
		shootParticles = this.GetComponentInChildren<ParticleEmitter>();
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void Update () {
		if (Input.GetMouseButtonDown(0))
		{
			GameObject.FindGameObjectWithTag("ShootArm").GetComponent<Animation>().Play();
			GameObject newBullet = (GameObject)Instantiate(projectile, this.transform.position, Quaternion.LookRotation(player.transform.forward));
			this.GetComponent<AudioSource>().Play();
			newBullet.GetComponent<Rigidbody>().AddForce(this.transform.forward * speed, ForceMode.Impulse);
			shootParticles.Emit();
		}
	}	
}
