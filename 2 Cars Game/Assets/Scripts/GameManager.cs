using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public GameObject[] UI;
    public GameObject[] cars;
    public Text scoreUI;

    public static float BlueLeftTimer = 2f;
    public static float BlueRightTimer = 2f;
    public static float RedLeftTimer = 2f;
    public static float RedRightTimer = 2f;

    public static int score=0;

    // Use this for initialization
    void Start () {
        foreach (GameObject Uimenu in UI)
        {
            Uimenu.gameObject.SetActive(false);
        }
		
	}
	
	// Update is called once per frame
	void Update () {
        DecreaseTimer();
	}

    private void DecreaseTimer()
    {
        BlueLeftTimer = Mathf.Clamp(BlueLeftTimer - Time.deltaTime, 0f, 2f);
        BlueRightTimer = Mathf.Clamp(BlueRightTimer - Time.deltaTime, 0f, 2f);
        RedLeftTimer = Mathf.Clamp(RedLeftTimer - Time.deltaTime, 0f, 2f);
        RedRightTimer = Mathf.Clamp(RedRightTimer - Time.deltaTime, 0f, 2f);
    }

    public void ScoreUpdate()
    {
        score = score + 1;
        DisplayText();
    }

    public void DisplayText()
    {
        scoreUI.text = score.ToString();
    }

    public void Death()
    {
        foreach (GameObject Cars in cars)
        {
            Cars.gameObject.SetActive(false);
        }
        foreach (GameObject Uimenu in UI)
        {
            Uimenu.gameObject.SetActive(true);
        }
    }

    public void ReloadLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
