using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInputManager : MonoBehaviour
{
    [Header("Assign these bits in the Editor")]
    [SerializeField] private CharacterMovementController bob = default;

    [Header("Cached in Start Function")]
    private EventSystem eventSystem;

	void Start()
	{
		eventSystem = GetComponent<EventSystem>();
	}

	void Update()
	{
		DoInputStuff();
	}

	private void DoInputStuff()
	{
		if (Input.GetAxis("Horizontal") > 0.0f)
		{
			bob.MoveRight();
		}
		else if (Input.GetAxis("Horizontal") < 0.0f)
		{
			bob.MoveLeft();
		}
	
		if (Input.GetButton("Jump")) { bob.Jump(); }
	}

}
