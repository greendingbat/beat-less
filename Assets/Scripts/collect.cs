﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public SoundManagerScript sms;
    void OnTriggerEnter(Collider collect)
    {
        if (collect.gameObject.tag == "Player")
        {
			sms.playerPowerup(1);
           gameObject.SetActive(false);
        }
    }
}
