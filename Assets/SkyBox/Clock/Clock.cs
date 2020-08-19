using System;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour {

	[Header("Date and Time UI")]
	public Text dateUI;
	public Text timeUI;

	public float minPerDay = 5;

	public int date = 1;
	public int time = 1;

	[Header("GO")]
	public GameObject sky;
	public Vector3 skydegree;

	public bool isPause = false;

	private float degreesPerHour, degreesPerMinute, degreesPerSecond;
	private double initialHour, initialMinute, initialSecond;
	private double gapHour = 0f, gapMinute = 0f, gapSecond = 0f;
	private bool getStopTime = false;
	public Transform hoursTransform, minutesTransform, secondsTransform;

	private TimeSpan stopTime;

	private double oldTotal; 

	[Header("UI Button")]
	public GameObject pauseBtn;
	public GameObject playBtn;
	public GameObject UIMask;

	void InitialDegrees()
    {
		//1 day equals to 5 min, speedup → 24*60/5
		degreesPerHour = 30f * (24 * 60 / minPerDay);
		degreesPerMinute = 360f * (24 * 60 / minPerDay);
		degreesPerSecond = 1 * (24 * 60 / minPerDay);
	}

	void InitialTime()
    {	
		TimeSpan initialTime = DateTime.Now.TimeOfDay;
		initialHour = initialTime.TotalHours;
		initialMinute = initialTime.TotalMinutes;
		initialSecond = initialTime.TotalSeconds;
	}

	//暂停后开始计时
	//重启后→当前时间-初始时间+暂停时间
	void GetGapTime()
    {
		TimeSpan currentTime = DateTime.Now.TimeOfDay;

		if (getStopTime == false)
		{
			stopTime = DateTime.Now.TimeOfDay;//获得暂停时的时间
			getStopTime = true;
		}
	
		gapHour = currentTime.TotalHours - stopTime.TotalHours;//获得当前时间和暂停时时间差
		gapMinute = currentTime.TotalMinutes - stopTime.TotalMinutes;
		gapSecond = currentTime.TotalSeconds - stopTime.TotalSeconds;

	}


	public void SetPause()
    {
		isPause = !isPause;

		if (!isPause)
        {
			pauseBtn.SetActive(true);
			playBtn.SetActive(false);
			UIMask.SetActive(false);
		}
        else
        {
			pauseBtn.SetActive(false);
			playBtn.SetActive(true);
			UIMask.SetActive(true);
		}
    }


    private void Start()
    {
		InitialDegrees();
		InitialTime();
		dateUI.text = "Day " + date;
	}

    void Update () {

		if (isPause)
		{
			GetGapTime();
		}
		else
		{
			if (getStopTime == true)
			{
				getStopTime = false;
				initialHour += gapHour;
			}

			UpdateContinuous();
			sky.transform.rotation = Quaternion.Euler(skydegree);
		}	
	}

	void UpdateContinuous() {
		TimeSpan time = DateTime.Now.TimeOfDay;
		hoursTransform.localRotation =//弥补暂停多出来的时间差
			Quaternion.Euler(0f, (float)(time.TotalHours - initialHour) * degreesPerHour, 0f);
		minutesTransform.localRotation =
			Quaternion.Euler(0f, (float)(time.TotalMinutes - initialMinute) * degreesPerMinute, 0f);
		secondsTransform.localRotation =
			Quaternion.Euler(0f, (float)(time.TotalSeconds - initialSecond) * degreesPerSecond, 0f);

		//skybox
		skydegree.x = -100 + ((float)((time.TotalHours - initialHour) * degreesPerHour) / 2) % 360;

		//UI
		date = (int)((time.TotalHours - initialHour) * degreesPerHour / 720) + 1;
		dateUI.text = "Day " + date;
	}

	public double ReturnDeltaTime()
	{
        if (oldTotal == null)
        {
			//第一次
			oldTotal = initialHour;

        }
        
		TimeSpan time = DateTime.Now.TimeOfDay;
		double delta = (time.TotalHours - oldTotal);
		oldTotal = time.TotalHours;

		Debug.Log(delta);
		return delta;
	}
}