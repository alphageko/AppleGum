using UnityEngine;
using System.Collections;
/*
Description: This script will make a platform fall after a given timer.

Components needed on your falling platform:
	Rigidbody 2D
		"Is Kinematic" needs to be checked
	Box Collider2D
	This script
*/
public class FallingPlatform : MonoBehaviour {

	private Rigidbody2D rb2d;

	public float fallDelay;

	void Start()
	{
		rb2d = GetComponent<Rigidbody2D> ();
	}
	void OnCollisionEnter2D(Collision2D collider)
	{
		if (collider.collider.CompareTag ("Player")) {
			StartCoroutine (Fall ());
		}
	}

	IEnumerator Fall()
	{
		yield return new WaitForSeconds (fallDelay);
		rb2d.isKinematic = false;
		GetComponent<Collider2D> ().isTrigger = true;
		yield return 0;
	}
	
}

