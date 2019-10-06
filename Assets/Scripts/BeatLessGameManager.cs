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
	public bool downBeatEventEntered = false;
	public bool downBeatEventExited = false;

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
		DownBeatEvents();
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

	public delegate void DownBeatEnterDelegate();
	public static event DownBeatEnterDelegate OnDownBeatEnter;

	public delegate void DownBeatStayDelegate();
	public static event DownBeatStayDelegate OnDownBeatStay;

	public delegate void DownBeatExitDelegate();
	public static event DownBeatExitDelegate OnDownBeatExit;

	private void DownBeatEvents()
	{
		if (isDownBeat)
		{
			if (downBeatEventEntered)
			{
				if (OnDownBeatStay != null)
					OnDownBeatStay();
			}
			else
			{
				if (OnDownBeatEnter != null)
					OnDownBeatEnter();
				downBeatEventEntered = true;
			}
		}
		else
		{
			if (downBeatEventExited)
			{
				downBeatEventEntered = false;
			}
			else
			{
				downBeatEventExited = true;
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
