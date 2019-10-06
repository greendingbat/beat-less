using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatLessGameManager : MonoBehaviour
{
	public GameObject bob;
	public int hp;

	private int trackCountTotal = 5;
	private List<bool> trackEnabled;

	private float firstTrackBPM = 95f;
	private float secondTrackBPM = 115f;

	private float trackBeginTime = 0f;
	private float trackPlayTime { get { return Time.time - trackBeginTime; } }

	public float beatLength = 0f;
	public int trackLastBeatNumber = 0;
	public int trackCurrentBeatNumber = 0;

	public bool isFirstBeat { get { return trackCurrentBeatNumber % 4 == 1; } }
	public bool firstBeatEventEntered = false;
	public bool firstBeatEventExited = false;

	public bool isSecondBeat { get { return trackCurrentBeatNumber % 4 == 2; } }
	public bool secondBeatEventEntered = false;
	public bool secondBeatEventExited = false;

	public bool isThirdBeat { get { return trackCurrentBeatNumber % 4 == 3; } }
	public bool thirdBeatEventEntered = false;
	public bool thirdBeatEventExited = false;

	public bool isFourthBeat { get { return trackCurrentBeatNumber % 4 == 0; } }
	public bool fourthBeatEventEntered = false;
	public bool fourthBeatEventExited = false;

	private int trackCalculatedBeatNumber { get { return Mathf.FloorToInt(trackPlayTime / beatLength); } }

	void Start()
	{
		// SetCursorEnabled(false);
		trackEnabled = new List<bool>();
		for (int i = 0; i < trackCountTotal; i++)
		{
			trackEnabled.Add(false);
		}

		beatLength = 60f / firstTrackBPM;

		hp = 1;
	}

	void Update()
	{
		SyncBeatNumber();
		FirstBeatEvents();
		SecondBeatEvents();
		ThirdBeatEvents();
		FourthBeatEvents();
	}

	private void SyncBeatNumber()
	{
		if (trackCurrentBeatNumber != trackCalculatedBeatNumber)
		{
			trackLastBeatNumber = trackCurrentBeatNumber;
			trackCurrentBeatNumber = trackCalculatedBeatNumber;
			//Debug.Log("Beat Number: " + trackCurrentBeatNumber);
		}
	}

	public delegate void FirstBeatEnterDelegate();
	public static event FirstBeatEnterDelegate OnFirstBeatEnter;

	public delegate void FirstBeatStayDelegate();
	public static event FirstBeatStayDelegate OnFirstBeatStay;

	public delegate void FirstBeatExitDelegate();
	public static event FirstBeatExitDelegate OnFirstBeatExit;

	private void FirstBeatEvents()
	{
		if (isFirstBeat)
		{
			if (firstBeatEventEntered)
			{
				if (OnFirstBeatStay != null)
					OnFirstBeatStay();
			}
			else
			{
				if (OnFirstBeatEnter != null)
					OnFirstBeatEnter();
				firstBeatEventEntered = true;
			}
		}
		else
		{
			if (firstBeatEventExited)
			{
				firstBeatEventEntered = false;
			}
			else
			{
				firstBeatEventExited = true;
			}
		}
	}

	public delegate void SecondBeatEnterDelegate();
	public static event SecondBeatEnterDelegate OnSecondBeatEnter;

	public delegate void SecondBeatStayDelegate();
	public static event SecondBeatStayDelegate OnSecondBeatStay;

	public delegate void SecondBeatExitDelegate();
	public static event SecondBeatExitDelegate OnSecondBeatExit;

	private void SecondBeatEvents()
	{
		if (isSecondBeat)
		{
			if (secondBeatEventEntered)
			{
				if (OnSecondBeatStay != null)
					OnSecondBeatStay();
			}
			else
			{
				if (OnSecondBeatEnter != null)
					OnSecondBeatEnter();
				secondBeatEventEntered = true;
			}
		}
		else
		{
			if (secondBeatEventExited)
			{
				secondBeatEventEntered = false;
			}
			else
			{
				secondBeatEventExited = true;
			}
		}
	}

	public delegate void ThirdBeatEnterDelegate();
	public static event ThirdBeatEnterDelegate OnThirdBeatEnter;

	public delegate void ThirdBeatStayDelegate();
	public static event ThirdBeatStayDelegate OnThirdBeatStay;

	public delegate void ThirdBeatExitDelegate();
	public static event ThirdBeatExitDelegate OnThirdBeatExit;

	private void ThirdBeatEvents()
	{
		if (isThirdBeat)
		{
			if (thirdBeatEventEntered)
			{
				if (OnThirdBeatStay != null)
					OnThirdBeatStay();
			}
			else
			{
				if (OnThirdBeatEnter != null)
					OnThirdBeatEnter();
				thirdBeatEventEntered = true;
			}
		}
		else
		{
			if (thirdBeatEventExited)
			{
				thirdBeatEventEntered = false;
			}
			else
			{
				thirdBeatEventExited = true;
			}
		}
	}

	public delegate void FourthBeatEnterDelegate();
	public static event FourthBeatEnterDelegate OnFourthBeatEnter;

	public delegate void FourthBeatStayDelegate();
	public static event FourthBeatStayDelegate OnFourthBeatStay;

	public delegate void FourthBeatExitDelegate();
	public static event FourthBeatExitDelegate OnFourthBeatExit;

	private void FourthBeatEvents()
	{
		if (isFourthBeat)
		{
			if (fourthBeatEventEntered)
			{
				if (OnFourthBeatStay != null)
					OnFourthBeatStay();
			}
			else
			{
				if (OnFourthBeatEnter != null)
					OnFourthBeatEnter();
				fourthBeatEventEntered = true;
			}
		}
		else
		{
			if (fourthBeatEventExited)
			{
				fourthBeatEventEntered = false;
			}
			else
			{
				fourthBeatEventExited = true;
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
