﻿using UnityEngine;
using System.Collections;

public class ShootSMG : MonoBehaviour {
    public GameObject projectile;
    public float speed = 50;
    public ParticleEmitter shootParticles;

    private GameObject player;
	private int bulletsLeft = 500;
	private GameManager gameManager;

    void Start()
    {
        shootParticles = this.GetComponentInChildren<ParticleEmitter>();
        player = GameObject.FindGameObjectWithTag("Player");
		gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
		gameManager.BulletsLeft = bulletsLeft;
        if (Input.GetMouseButton(0) && bulletsLeft > 0)
        {
            GameObject.FindGameObjectWithTag("ShootArm").animation.Play();
            GameObject newBullet = (GameObject)Instantiate(projectile, this.transform.position, Quaternion.LookRotation(player.transform.forward));
            this.GetComponent<AudioSource>().Play();
            newBullet.rigidbody.AddForce(this.transform.forward * speed, ForceMode.Impulse);
            shootParticles.Emit();
			bulletsLeft--;
        }
    }

	public int BulletsLeft {
		get {
			return bulletsLeft;
		}
		set {
			bulletsLeft = value;
		}
	}
}
