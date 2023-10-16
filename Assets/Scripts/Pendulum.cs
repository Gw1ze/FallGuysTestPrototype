using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
	public float speed = 10f;
	public float limit = 60f;
	public bool randomStart = true;
	private float random = 0;

	void Awake()
    {
		if(randomStart)
			random = Random.Range(0f, 5f);
	}

    void Update()
    {
		float angle = limit * Mathf.Sin(Time.time + random * speed);
		transform.localRotation = Quaternion.Euler(0, 0, angle);
	}
}
