using UnityEngine;

// Required for Unity
using System.Collections;

// Required for Arrays & other Collections
 
public class Enemy : MonoBehaviour
{
	[Header ("Set in the Unity Inspector")]
	public float speed = 10f;
	// The speed in m/s
	public float fireRate = 0.3f;
	// Seconds/shot (Unused)
	public float health = 10;
	public int score = 100;
	// Points earned for destroying this

	private BoundsCheck bndCheck;
	 
	// This is a Property: A method that acts like a field
	public Vector3 pos {                                                // a
		get {
			return(this.transform.position);
		}
		set {
			this.transform.position = value;
		}
	}

	void Awake ()
	{
		bndCheck = GetComponent<BoundsCheck> ();
	}

	void Update ()
	{
		Move ();

		if (bndCheck != null && bndCheck.offDown) {
			// We're off the bottom, so destroy this GameObject
			Destroy (gameObject);
		}
	}

	public virtual void Move ()
	{                                        // b
		Vector3 tempPos = pos;
		tempPos.y -= speed * Time.deltaTime;
		pos = tempPos;
	}

	void OnCollisionEnter (Collision coll)
	{
		GameObject otherRootGO = coll.transform.root.gameObject;       // a
		if (otherRootGO.tag == "ProjectileHero") {                   // b
			Destroy (otherRootGO);  // Destroy the Projectile
			Destroy (gameObject);   // Destroy this Enemy GameObject
		} else {
			print ("Enemy hit by non-ProjectileHero: " + otherRootGO.name);  // c
		}
	}
 
}