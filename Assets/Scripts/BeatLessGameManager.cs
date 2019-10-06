using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatLessGameManager : MonoBehaviour
{
	public GameObject bob;

	private int trackCountTotal = 5;
	private List<bool> trackEnabled;

	private float firstTrackBPM = 95f;
	private float secondTrackBPM = 115f;

	private float trackBeginTime = 0f;
	private float trackPlayTime { get { return Time.time - trackBeginTime; } }

	public float beatLength = 0f;
	public int trackLastBeatNumber = 0;
	public int trackCurrentBeatNumber = 0;

    public bool isDownBeat { get { return trackCurrentBeatNumber % 4 == 1; } }

    private int trackCalculatedBeatNumber { get { return Mathf.FloorToInt(trackPlayTime / beatLength); } }
	public int hp;
	void Start()
	{
		// SetCursorEnabled(false);
		trackEnabled = new List<bool>();
		for(int i = 0; i < trackCountTotal; i++){
			trackEnabled.Add(false);
		}

		beatLength = 60f / firstTrackBPM;
		hp = 1;
	}

	void Update()
	{
		SyncBeatNumber();
	}

	private void SyncBeatNumber()
	{
		if (trackCurrentBeatNumber != trackCalculatedBeatNumber)
		{
			trackLastBeatNumber = trackCurrentBeatNumber;
			trackCurrentBeatNumber = trackCalculatedBeatNumber;
			Debug.Log("Beat Number: " + trackCurrentBeatNumber);
			if(isDownBeat)
			{
				Debug.Log("Downbeetz");
			}
		}
	}




	private void SetCursorEnabled(bool enable)
	{
		if (enable)
		{
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}
		else
		{
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
		}
	}
}
