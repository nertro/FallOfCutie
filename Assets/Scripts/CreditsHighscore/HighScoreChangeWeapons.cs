using UnityEngine;
using System.Collections;

public class HighScoreChangeWeapons : MonoBehaviour {

    private int counter = 0;

    public GameObject[] weapons;

    void ChangeWeapon()
    {
        weapons[counter].SetActive(false);
        counter++;
        if (counter < weapons.Length)
        {
            weapons[counter].SetActive(true);
        }
        else
        {
            counter = 0;
            weapons[counter].SetActive(true);
        }
    }
}
