using UnityEngine;
using System.Collections;

public class Dosen : MonoBehaviour {
    private GameObject[] cans;

    void Start()
    {
        cans = GameObject.FindGameObjectsWithTag("Can");
    }

    void OnCollisionEnter(Collision other)
    {
        for (int i = 0; i < cans.Length; i++)
        {
            cans[i].GetComponent<Rigidbody>().isKinematic = false;
            cans[i].GetComponent<Rigidbody>().AddForce(Vector3.down * 0.005f);
        }
    }
}
