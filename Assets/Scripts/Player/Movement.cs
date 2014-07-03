using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
    private AudioSource[] audioSources;
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    private Vector3 oldPos;
    private Vector3 newPos;
    private float timer = 0;
    private float stepSoundInterval = 0.3f;

    void Start()
    {
        audioSources = gameObject.GetComponents<AudioSource>();
    }

    void Update()
    {
        oldPos = this.transform.position;
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
        newPos = this.transform.position;

        if (oldPos != newPos)
        {
            PlaySound();
        }
    }
    void PlaySound()
    {
        timer += Time.deltaTime;
        if (timer > stepSoundInterval)
        {
            audioSources[Random.Range(0, audioSources.Length-1)].Play();
            timer = 0;
        }

    }
}
