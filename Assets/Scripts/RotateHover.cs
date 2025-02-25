using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHover : MonoBehaviour {
    public bool rotate;  // Should it rotate?
	public float rotationSpeed = 50.0f;  // Speed of rotation
	public float hoverSpeed = 0.5f;  // Up and down hover speed
	public float hoverDistance = 0.8f;  // Distance hovering travels

	public Vector3 cubePos;
	private float cubeY;

	void Start() 
	{
		cubeY = transform.position.y;	
	}

	// called once per frame
	void Update()
	{
		// Use PingPong class to bounce between two points a specified speed and distance
        float y = Mathf.PingPong(Time.time * hoverSpeed, hoverDistance) + cubeY;

		// Set GameObject's Vector3 position to new y-axis position
        cubePos = new Vector3(transform.position.x, y, transform.position.z);
		transform.position = cubePos;

		if (rotate)
		{
			// Set rotate properties to a rotation speed along the y-axis -> Vector3.up
			transform.Rotate (Vector3.up * rotationSpeed * Time.deltaTime, Space.World);
		}
	}
}
