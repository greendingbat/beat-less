using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatLessGameManager : MonoBehaviour
{
	public GameObject bob;
	public GameObject [] enemies;
	public CharacterMovementController characterMovement;
	

	void Start()
	{
        // SetCursorEnabled(false);
    }

	void Update()
	{
		
	}

    private void SetCursorEnabled(bool enable)
    {
        if (enable)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
