using UnityEngine;
using System.Collections;
using System;

public class ShowScore : MonoBehaviour {

    GameObject[] scoreObjects;
    GameObject[] textObjects;
    UILabel[] scoreTexts = new UILabel[6];
    UILabel[] nameTexts = new UILabel[6];
    GameObject inputLabel;
    string[] names = new string[6];
    int[] scores = new int[6];
    private int newScore;
    private string name;
    private bool newHighscore = false;

    void Start()
    {
        inputLabel = GameObject.FindGameObjectWithTag("NameInput");
        inputLabel.GetComponentInChildren<UILabel>().enabled = false;
        newScore = PlayerPrefs.GetInt("currentScore");

        scoreObjects = GameObject.FindGameObjectsWithTag("Score");
        for (int i = 0; i < scoreObjects.Length; i++)
        {
            scoreTexts[i] = scoreObjects[i].GetComponent<UILabel>();
        }

        textObjects = GameObject.FindGameObjectsWithTag("Name");
        for (int i = 0; i < textObjects.Length; i++)
        {
            nameTexts[i] = textObjects[i].GetComponent<UILabel>();
        }
        
        SetScores();

        WriteScore();
    }

    void Update()
    {
        if(newHighscore && Input.GetKey(KeyCode.Return))
        {
            SetNewName();
            inputLabel.GetComponentInChildren<UILabel>().enabled = false;
        }
            WriteScore();

            if (Input.GetKey(KeyCode.Escape))
            {
                Application.LoadLevel("Credits");
            }
    }

    void SetScores()
    {
        for (int i = 0; i < scores.Length; i++)
        {
            int z = i + scores.Length;
            if (!PlayerPrefs.HasKey(i.ToString()))
            {
                PlayerPrefs.SetInt(i.ToString(), 0);
                PlayerPrefs.SetString(z.ToString(), "Badass");
            }
            scores[i] = PlayerPrefs.GetInt(i.ToString());
            names[i] = PlayerPrefs.GetString(z.ToString());
            if (names[i] == "???")
            {
                names[i] = "Ted";
            }
        }
 
        if (newScore > scores[scores.Length - 1])
        {
            scores[scores.Length - 1] = newScore;
            names[names.Length - 1] = "???";
            inputLabel.GetComponentInChildren<UILabel>().enabled = true;
            newHighscore = true;
        }

        Array.Sort(scores, names);
        Array.Reverse(scores);
        Array.Reverse(names);

        for (int i = 0; i < scores.Length; i++)
        {
            int z = i+scores.Length;
            PlayerPrefs.SetInt(i.ToString(), scores[i]);
            PlayerPrefs.SetString(z.ToString(), names[i]);
        }
    }

    void WriteScore()
    {
        for (int i = 0; i < scores.Length; i++)
        {
            int z = i + scores.Length;
            scoreTexts[i].text = PlayerPrefs.GetInt(i.ToString()).ToString();
            nameTexts[i].text = PlayerPrefs.GetString(z.ToString());
        }
    }

    void SetNewName()
    {
        for (int i = 0; i < nameTexts.Length; i++)
        {
            if (nameTexts[i].text == "???")
            {
                nameTexts[i].text = inputLabel.GetComponentInChildren<UILabel>().text;
                //nameTexts[i].text = nameTexts[i].text.Remove(nameTexts[i].text.Length -1);
                int z = i + scores.Length;
                PlayerPrefs.SetString(z.ToString(), nameTexts[i].text);
            }
        }
    }

}
