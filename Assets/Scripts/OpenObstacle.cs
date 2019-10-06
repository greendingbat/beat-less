using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenObstacle : MonoBehaviour
{
	[SerializeField] private Animator[] animators;
	[SerializeField] private bool isOpen = false;

	[SerializeField] private bool firstBeat = false;
	[SerializeField] private bool secondBeat = false;
	[SerializeField] private bool thirdBeat = false;
	[SerializeField] private bool fourthBeat = false;

	void Start()
	{
		animators = GetComponentsInChildren<Animator>();
		foreach (Animator animator in animators)
		{
			Debug.Log(animator.gameObject.name);
			animator.SetBool("is_open", isOpen);
		}
		if (firstBeat)
			BeatLessGameManager.OnFirstBeatEnter += ToggleOpen;
		if (secondBeat)
			BeatLessGameManager.OnFirstBeatEnter += ToggleOpen;
		if (thirdBeat)
			BeatLessGameManager.OnFirstBeatEnter += ToggleOpen;
		if (fourthBeat)
			BeatLessGameManager.OnFirstBeatEnter += ToggleOpen;	}

	public void ToggleOpen()
	{
		foreach (Animator animator in animators)
		{
			isOpen = !isOpen;
			Debug.Log("Setting " + animator.gameObject.name + " is_open to: " + isOpen);
			animator.SetBool("is_open", isOpen);
		}
	}
}
