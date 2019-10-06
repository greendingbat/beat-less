using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManagerScript : MonoBehaviour
{
	public List<AudioSource> musicTracks = default;
	public Dictionary<string, AudioSource> test = default;
	public int dummyHP;
	public List<int> playing;
	public List<int> notPlaying;
    // Start is called before the first frame update
    void Start()
    {
		dummyHP = 1;
		
		// Start out with only the noise track playing
		foreach(AudioSource a in musicTracks) {
			a.volume = 0;
		}
		musicTracks[0].volume = 1;

		playing = new List<int>{};
		notPlaying = new List<int>{2, 3, 4};
	}

    // Update is called once per frame
    void Update()
    {
/*         if (Input.inputString == "z") {
			if (musicTracks[0].volume < 1) {
				musicTracks[0].volume = 1;
			} else {
				musicTracks[0].volume = 0;
			}
		} else if (Input.inputString == "x") {
			if (musicTracks[1].volume < 1) {
				musicTracks[1].volume = 1;
			} else {
				musicTracks[1].volume = 0;
			}
		} else if (Input.inputString == "c") {
			if (musicTracks[2].volume < 1) {
				musicTracks[2].volume = 1;
			} else {
				musicTracks[2].volume = 0;
			}
		} else if (Input.inputString == "v") {
			if (musicTracks[3].volume < 1) {
				musicTracks[3].volume = 1;
			} else {
				musicTracks[3].volume = 0;
			}
		} else if (Input.inputString == "b") {
			if (musicTracks[4].volume < 1) {
				musicTracks[4].volume = 1;
			} else {
				musicTracks[4].volume = 0;
			}
		} */
		
		if (Input.inputString == "z" && dummyHP > 0) {
			dummyHP --;
			playerHit(dummyHP);
		} else if (Input.inputString == "x" && dummyHP < 5) {
			dummyHP ++;
			playerPowerup(dummyHP);
		}
			
    }
	
 	public void adjustTrackVols() {
		foreach (int i in playing) {
			musicTracks[i].volume = 1;
		}
		
		foreach (int i in notPlaying) {
			musicTracks[i].volume = 0;
		}
		
	} 
	
	public void playerHit(int hp) {
		print("OW");
		print("HP: " + hp);
		if (hp == 0) {
			musicTracks[0].volume = 0;
			print("GAME OVER");
			SceneManager.LoadScene("game_over");
		} else if (hp == 1) {
			musicTracks[1].volume = 0;
		} else {
			removeRandomTrack();
		}
		adjustTrackVols();
	}
	
	public void playerPowerup(int hp) {
		print("YAY!");
		print("HP: " + hp);
		if (hp == 2) {
			musicTracks[1].volume = 1;
		} else {
			print("CALLING RANDOM TRACK");
			addRandomTrack();
		}
		adjustTrackVols();
	}
	
	public void addRandomTrack() {
		// This is HACK
		int r = Random.Range(0, notPlaying.Count);
		int x = notPlaying[r];
		notPlaying.Remove(x);
		playing.Add(x);
	}
	
	public void removeRandomTrack() {
		int r = Random.Range(0, playing.Count);
		int x = playing[r];
		playing.Remove(x);
		notPlaying.Add(x);
		
	}
}
