using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownObstacle : MonoBehaviour
{
	[SerializeField] private Animator[] animators;
	[SerializeField] private bool isDown = false;

	void Start()
	{
		animators = GetComponentsInChildren<Animator>();
		foreach (Animator animator in animators)
		{
			Debug.Log(animator.gameObject.name);
			animator.SetBool("is_down", isDown);
		}
		BeatLessGameManager.OnDownBeatEnter += ToggleDown;
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
