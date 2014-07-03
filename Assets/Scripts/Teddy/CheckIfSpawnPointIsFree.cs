using UnityEngine;
using System.Collections;

public class CheckIfSpawnPointIsFree : MonoBehaviour {
    public bool isFree = true;

    void OnCollisionEnter(Collision other)
    {
        isFree = false;
    }

    void OnCollisionExit(Collision other)
    {
        isFree = true;
    }
}
