using UnityEngine;
using System.Collections;

public class CreditsChangeTeddyAndText : MonoBehaviour {
    public GameObject[] nameLabels;
    private int counter = 0;

    public GameObject[] teddys;

    void ChangeNameAndTeddy()
    {
        nameLabels[counter].SetActive(false);
        teddys[counter].SetActive(false);
        counter++;
        if (counter < nameLabels.Length)
        {
            nameLabels[counter].SetActive(true);
            teddys[counter].SetActive(true);
        }
        else
        {
            Application.LoadLevel("start");
        }
    }
}
