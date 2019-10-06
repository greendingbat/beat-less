using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenObstacle : MonoBehaviour
{
	[SerializeField] private Animator[] animators;
	[SerializeField] private bool isOpen = false;

	void Start()
	{
		animators = GetComponentsInChildren<Animator>();
		foreach (Animator animator in animators)
		{
			Debug.Log(animator.gameObject.name);
			animator.SetBool("is_open", isOpen);
		}
		BeatLessGameManager.OnDownBeatEnter += ToggleOpen;
	}

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
