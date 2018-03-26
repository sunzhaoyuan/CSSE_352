using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
	 
	private BoundsCheck bndCheck;

	void Awake ()
	{
		bndCheck = GetComponent<BoundsCheck> ();
	}

	void Update ()
	{
		if (bndCheck.offUp) {                                        // a
			Destroy (gameObject);
		}
	}
}