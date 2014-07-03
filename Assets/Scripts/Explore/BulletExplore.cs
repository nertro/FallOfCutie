using UnityEngine;
using System.Collections;

public class BulletExplore : MonoBehaviour {
	void OnCollisionEnter(Collision other)
	{
		Destroy(this.gameObject);
	}
}
