using UnityEngine;
using System.Collections;

public class Node : MonoBehaviour {
	private bool hasItem = false;

    public GameObject[] availableNodes;

	public bool HasItem {
		get {
			return hasItem;
		}
		set {
			hasItem = value;
		}
	}
}
