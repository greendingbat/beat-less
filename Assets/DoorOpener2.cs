using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener2 : MonoBehaviour
{
	Animator a;
    // Start is called before the first frame update
    void Start()
    {
        a = GetComponent<Animator>();
    }

	public float targetTime = 60f / 95f * 2;
    // Update is called once per frame
    void Update()
    {
		targetTime -= Time.deltaTime;
        if (targetTime <= 0.0f) {
			
			if (a.GetBool("is_open")) {
				a.SetBool("is_open", false);
			} else {
				a.SetBool("is_open", true);
			}
			targetTime = 60f / 95f * 2;
		}
    }
}
