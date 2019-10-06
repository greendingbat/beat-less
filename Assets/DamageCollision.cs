using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollision : MonoBehaviour
{
	bool invincible;
	int timeout;
    // Start is called before the first frame update
    void Start()
    {
        invincible = false;
		timeout = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (invincible && timeout != 0) {
			timeout --;			
		} else {
			invincible = false;
			timeout = 10;
			gameObject.GetComponent<Renderer>.material.color.a = 50;
		}
    }
	
	public SoundManagerScript sms;
	public BeatLessGameManager blgm;
	
	void OnTriggerEnter(Collider collect)
    {
        if (collect.gameObject.tag == "Damage" && !invincible)
        {
			blgm.hp -= 1;
			sms.playerHit(blgm.hp);
			invincible = true;
        }
    }
	
}
