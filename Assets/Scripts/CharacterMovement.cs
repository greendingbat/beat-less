using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
	[Header("Assign these bits in the Editor")]
	[SerializeField] private Animator animator;
	[SerializeField] private Rigidbody rb;

    [SerializeField] private Transform spawnpoint;

	[Header("Character Stats")]
	[SerializeField] private float speed = 10f;
	[SerializeField] private float jumpSpeed = 20f;
	[SerializeField] private float fallSpeed = 60f;

	[Header("Shown in Editor for Debugging")]

	[SerializeField] public bool moveRight = false;
	[SerializeField] public bool moveLeft = false;
	[SerializeField] public bool jumpRequested = false;
    [SerializeField] public bool jumpBoostRequested = false;
    [SerializeField] public float jumpStartedTime = 0f;
    [SerializeField] public float jumpBoostTimeAllowance = 0f;

    private bool jumpBoostAllowed { get { return Time.time - jumpStartedTime < jumpBoostTimeAllowance; } }

    [SerializeField] public Vector3 calculatedVelocity;
	[SerializeField] public Vector3 vertVelocity;
	[SerializeField] public Vector3 horizVelocity;
	[SerializeField] public Vector3 horizDir;
	[SerializeField] public bool grounded = false;
	[SerializeField] public float lastGroundedTime = 0f;
	[SerializeField] public Vector3 previousPosition;
<<<<<<< HEAD
	public bool inDamage;
	public SoundManagerScript sms;
	public BeatLessGameManager blgm;
=======
>>>>>>> c4a5e51e7d12f9e5866c68fcec57958bb383eacd

	public Vector3 velocity { get { return calculatedVelocity; } }

	void Start()
	{
		// animator = GetComponent<Animator>();
	}

	void Update()
	{
		// animator.SetBool("right", moveRight);
		// animator.SetBool("left", moveLeft);
		// animator.SetBool("jump", !grounded && vertVelocity.y > 0f);
		// animator.SetBool("fall", !grounded && vertVelocity.y < 0f);

		ApplyHorizontallVelocity();
		ApplyVerticalVelocty();
		calculatedVelocity = (horizVelocity + vertVelocity) * Time.deltaTime;
		rb.MovePosition(transform.position + new Vector3(calculatedVelocity.x, calculatedVelocity.y, 0f));
		previousPosition = transform.position;
		ResetStates();
<<<<<<< HEAD
		inDamage = false;
=======
>>>>>>> c4a5e51e7d12f9e5866c68fcec57958bb383eacd
	}

    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "KILLBOX")
        {
<<<<<<< HEAD
			if (inDamage) {
				return;
			}
			inDamage = true;
=======
>>>>>>> c4a5e51e7d12f9e5866c68fcec57958bb383eacd
            // teleport back to beginning if you fall off
            transform.position = spawnpoint.position;
            vertVelocity = Vector3.zero;
        }

    }

    private void ResetStates()
	{
		horizDir = Vector3.zero;
		jumpRequested = false;
		moveLeft = false;
		moveRight = false;
	}

	private void ApplyHorizontallVelocity()
	{
		horizVelocity = horizDir * speed;
	}

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Terrain")
        {
            //Debug.Log("CharacterHitbox enter collision with a : " + collision.gameObject.tag);
            grounded = true;
        }
    }
	void OnCollisionExit(Collision collision)
	{
		if (collision.gameObject.tag == "Terrain")
		{
			//Debug.Log("CharacterHitbox exit colliding with a : " + collision.gameObject.tag);
			grounded = false;
		}
	}

	private void ApplyVerticalVelocty()
	{
        if (grounded && jumpRequested)
        {
            lastGroundedTime = 0f;
            jumpStartedTime = Time.time;
            vertVelocity = Vector3.up * jumpSpeed;
        }
        else
        {
            if (jumpBoostRequested && jumpBoostAllowed)
            {
                vertVelocity = Vector3.up * jumpSpeed;
            }
            else
            {
                jumpStartedTime = 0f;
                if (grounded)
                {
                    vertVelocity = Vector3.zero;
                }
                else
                {
                    vertVelocity += Vector3.down * fallSpeed * Time.deltaTime;
                }
            }
        }
	}
}
