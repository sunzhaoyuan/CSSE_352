﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Checks whether a GameObject is on screen and can force it to stay on screen.
/// Note that this ONLY works for an orthographic Main Camera at [0,0,0]
/// </summary>
public class BoundsCheck : MonoBehaviour
{
	// a
	[Header ("Set in the Unity Inspector")]
	public float radius = 1f;
	public bool keepOnScreen = true;

	[Header ("These fields are set dynamically")]
	public bool isOnScreen = true;
	public float camWidth;
	public float camHeight;

	[HideInInspector]                                                        
	public bool     offRight, offLeft, offUp, offDown;                  // a

	void Awake ()
	{
		camHeight = Camera.main.orthographicSize;                      // b
		camWidth = camHeight * Camera.main.aspect;                     // c
	}

	void LateUpdate ()
	{                                               // d
		Vector3 pos = transform.position;
		isOnScreen = true;
		offRight = offLeft = offUp = offDown = false;                   // b

		if (pos.x > camWidth - radius) {
			pos.x = camWidth - radius;
			offRight = true;
		}
		if (pos.x < -camWidth + radius) {
			pos.x = -camWidth + radius;
			offLeft = true;
		}

		if (pos.y > camHeight - radius) {
			pos.y = camHeight - radius;
			offUp = true;
		}
		if (pos.y < -camHeight + radius) {
			pos.y = -camHeight + radius;
			offDown = true;
		}

		isOnScreen = !(offRight || offLeft || offUp || offDown);
//		print (isOnScreen);
		if (keepOnScreen && !isOnScreen) {
			transform.position = pos;
			isOnScreen = true;
			offRight = offLeft = offUp = offDown = false;
		}

//		transform.position = pos;
	}

	// Draw the bounds in the Scene pane using OnDrawGizmos()
	void OnDrawGizmos ()
	{
		if (!Application.isPlaying)
			return;
		Vector3 boundSize = new Vector3 (camWidth * 2, camHeight * 2, 0.1f);
		Gizmos.DrawWireCube (Vector3.zero, boundSize);
	}
}