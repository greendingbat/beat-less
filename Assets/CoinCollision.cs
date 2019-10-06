using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollision : MonoBehaviour
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
	public BeatLessGameManager blgm;
	
	void OnTriggerEnter(Collider collect)
    {
        if (collect.gameObject.tag == "Coin")
        {
			blgm.hp += 1;
			sms.playerPowerup(blgm.hp);
        }
    }
}
