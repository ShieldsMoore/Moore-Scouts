using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public string firstlevel;
    public string level1;
    public string level2;
    public string level3;
    public string level4;
    public string level5;
    public string level6;
    public GameObject levelSelect;
	// Use this for initialization
	void Start () {
        levelSelect.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void NewGame()
    {
        levelSelect.SetActive(true);
    }

    public void Level1()
    {
        PlayerPrefs.SetInt("Scene", 2);
        SceneManager.LoadScene(firstlevel);
       
    }

    public void Level2()
    {
        PlayerPrefs.SetInt("Scene", 3);
        SceneManager.LoadScene(firstlevel);

    }

    public void Level3()
    {
        PlayerPrefs.SetInt("Scene", 4);
        SceneManager.LoadScene(firstlevel);

    }

    public void Level4()
    {
        PlayerPrefs.SetInt("Scene", 5);
        SceneManager.LoadScene(firstlevel);

    }

    public void Level5()
    {
        PlayerPrefs.SetInt("Scene", 6);
        SceneManager.LoadScene(firstlevel);

    }

    public void Level6()
    {
        PlayerPrefs.SetInt("Scene", 7);
        SceneManager.LoadScene(firstlevel);

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
