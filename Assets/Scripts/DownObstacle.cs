using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownObstacle : MonoBehaviour
{
	[SerializeField] private Animator[] animators;
	[SerializeField] private bool isDown = false;

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
			animator.SetBool("is_down", isDown);
		}
		if (firstBeat)
			BeatLessGameManager.OnFirstBeatEnter += ToggleDown;
		if (secondBeat)
			BeatLessGameManager.OnFirstBeatEnter += ToggleDown;
		if (thirdBeat)
			BeatLessGameManager.OnFirstBeatEnter += ToggleDown;
		if (fourthBeat)
			BeatLessGameManager.OnFirstBeatEnter += ToggleDown;
	}

	public void ToggleDown()
	{
		foreach (Animator animator in animators)
		{
			isDown = !isDown;
			Debug.Log("Setting " + animator.gameObject.name + " is_down to: "+isDown);
			animator.SetBool("is_down", isDown);
		}
	}
}
