using UnityEngine;
using System.Collections;

public class ChangeWeapon : MonoBehaviour {

    public GameObject[] weapons;
    public GameObject otherArm;
    public GameObject thisArm;
	public GameObject bulletLabel;
	public GameObject cross;
	public GameObject bulletSprite;
	public GameObject hammer;

    private int currentWeapon = 0;


	void Start () {
        otherArm.gameObject.SetActive(false);

	}
	
	void Update () {
        if (Input.GetMouseButtonDown(1))
        {
            currentWeapon++;

            if (currentWeapon == weapons.Length)
            {
                SwitchArm();
            }
            if (currentWeapon < weapons.Length /*& !weapons[currentWeapon].activeInHierarchy*/)
            {
                SwitchWeapon(currentWeapon);
            }
        }
	}

    void SwitchWeapon(int index)
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            if (i == index)
            {
                weapons[i].gameObject.SetActive(true);
            }
            else
            {
                weapons[i].gameObject.SetActive(false);
            }
        }
    }

    void SwitchArm()
    {
        currentWeapon = 0;

        otherArm.gameObject.SetActive(true);
		if (otherArm.name == "Arm_Wurf_anim_NEU") 
		{
			bulletLabel.SetActive(false);
			cross.SetActive(false);
			bulletSprite.SetActive(false);
			Debug.Log("Hammer arm activated");
            otherArm.GetComponent<Animator>().Play("idle");
            hammer.GetComponent<ThrowHammer>().Activate();
			
		}
		else
		{
			bulletLabel.SetActive(true);
			cross.SetActive(true);
			bulletSprite.SetActive(true);		
		}
        thisArm.gameObject.SetActive(false);
    }
}
