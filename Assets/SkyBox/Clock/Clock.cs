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

	private float degreesPerHour, degreesPerMinute, degreesPerSecond;
	private double initialHour, initialMinute, initialSecond;
	public Transform hoursTransform, minutesTransform, secondsTransform;
	
	void InitialTime()
    {
		//1 day equals to 5 min, speedup → 24*60/5
		degreesPerHour = 30f * (24 * 60 / minPerDay);
		degreesPerMinute = 360f * (24 * 60 / minPerDay);
		degreesPerSecond = 1 * (24 * 60 / minPerDay);

		TimeSpan initialTime = DateTime.Now.TimeOfDay;
		initialHour = initialTime.TotalHours;
		initialMinute = initialTime.TotalMinutes;
		initialSecond = initialTime.TotalSeconds;
	}

    private void Start()
    {
		InitialTime();
	}

    void Update () {
		UpdateContinuous();
		sky.transform.rotation = Quaternion.Euler(skydegree);
	}

	void UpdateContinuous() {
		TimeSpan time = DateTime.Now.TimeOfDay;
		hoursTransform.localRotation =
			Quaternion.Euler(0f, (float)(time.TotalHours - initialHour) * degreesPerHour, 0f);
		minutesTransform.localRotation =
			Quaternion.Euler(0f, (float)(time.TotalMinutes - initialMinute) * degreesPerMinute, 0f);
		secondsTransform.localRotation =
			Quaternion.Euler(0f, (float)(time.TotalSeconds - initialSecond) * degreesPerSecond, 0f);

		//skybox
		skydegree.x = -100 + ((float)((time.TotalHours - initialHour) * degreesPerHour) / 2) % 360;

		//UI
		date = (int)((time.TotalHours - initialHour) * degreesPerHour / 720);
		dateUI.text = "Day " + date;
	}
}