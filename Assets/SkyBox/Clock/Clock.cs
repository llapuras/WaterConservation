using System;
using UnityEngine;

public class Clock : MonoBehaviour {

	public int date = 1;
	public GameObject sky;
	public Vector3 skydegree;
	public float
		degreesPerHour = 360f,
		degreesPerMinute = 360f,
		degreesPerSecond = 180f;

	public Transform hoursTransform, minutesTransform, secondsTransform;

	public bool continuous;

	void Update () {
		if (continuous) {
			UpdateContinuous();
		}
		else {
			UpdateDiscrete();
		}
		
		sky.transform.rotation = Quaternion.Euler(skydegree);
	}

	void UpdateContinuous () {
		TimeSpan time = DateTime.Now.TimeOfDay;
		hoursTransform.localRotation =
			Quaternion.Euler(0f, (float)time.TotalHours * degreesPerHour, 0f);
		minutesTransform.localRotation =
			Quaternion.Euler(0f, (float)time.TotalMinutes * degreesPerMinute, 0f);
		secondsTransform.localRotation =
			Quaternion.Euler(0f, (float)time.TotalSeconds * degreesPerSecond, 0f);

		skydegree.x = ((float)time.TotalMinutes * degreesPerMinute)%360;
	}

	void UpdateDiscrete () {
		DateTime time = DateTime.Now;
		hoursTransform.localRotation =
			Quaternion.Euler(0f, time.Hour * degreesPerHour, 0f);
		minutesTransform.localRotation =
			Quaternion.Euler(0f, time.Minute * degreesPerMinute, 0f);
		secondsTransform.localRotation =
			Quaternion.Euler(0f, time.Second * degreesPerSecond, 0f);
	}
}