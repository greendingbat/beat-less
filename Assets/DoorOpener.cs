using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
	Animator a;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (false) {
			a = GetComponent<Animator>();
			if (a.GetBool("is_open")) {
				a.SetBool("is_open", false);
			} else {
				a.SetBool("is_open", true);
			}
		}
    }
}
