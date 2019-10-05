using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementController : MonoBehaviour
{
	[Header("Cached in Start Function")]
	[SerializeField] private CharacterMovement state;

	void Start()
	{
		state = GetComponent<CharacterMovement>();
	}

    public void MoveLeft()
    {
        state.horizDir = (state.horizDir + Vector3.left).normalized;
        state.moveLeft = true;
    }
    public void MoveRight()
    {
        state.horizDir = (state.horizDir + Vector3.right).normalized;
        state.moveRight = true;
    }

    public void Jump() { state.jumpRequested = true; }
    public void jumpBoost() { state.jumpBoostRequested = true; }

}