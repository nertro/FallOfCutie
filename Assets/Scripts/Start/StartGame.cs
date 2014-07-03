using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {
    public string levelName;
    private GameObject uI;
    private bool loadLevel = false;
    private GameObject[] buttons;

    void Start()
    {
        uI = GameObject.FindGameObjectWithTag("UI");
        buttons = GameObject.FindGameObjectsWithTag("Button");
    }

	void OnClick()
    {
        LoadNewLevel();
    }

    void LoadNewLevel()
    {
        uI.GetComponent<AudioSource>().Play();
        uI.gameObject.GetComponent<StartScreenLoad>().newLevelName = levelName;
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(false);
        }
    }
}
