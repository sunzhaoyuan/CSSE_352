using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour {
	[Header("Set in Inspector")]
	public static float		bottomY = -20f;

	void Start () {
		
	}
	
	void Update () {
		if ( transform.position.y < bottomY ) {
			Destroy( this.gameObject );

			// Get a reference to the ApplePicker component of Main Camera
			ApplePicker asScript = Camera.main.GetComponent<ApplePicker>();
			// Call the public AppleDestroyed() method of apScript
			asScript.AppleDestroyed();
		}		
	}
}
