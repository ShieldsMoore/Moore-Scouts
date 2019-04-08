using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseGame : MonoBehaviour {

    public string mainMenu;
    public GameObject pauseScreen;
    private PlayerController pc;
	// Use this for initialization
	void Start () {
        pc = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
          if (Time.timeScale == 0)
            {
                ResumeGame();
            }
            else
            {
                PauseG();
            }
        }
	}

    public void PauseG()
    {
        AudioListener.pause = true;
        Time.timeScale = 0;
        pc.enabled = false;
        pauseScreen.SetActive(true);

    }

    public void ResumeGame()
    {
        AudioListener.pause = false;
        Time.timeScale = 1;
        pc.enabled = true;
        pauseScreen.SetActive(false);
    }

    public void QuitToMain()
    {
        AudioListener.pause = false;
        Time.timeScale = 1;
        pc.enabled = true;
        pauseScreen.SetActive(false);
        SceneManager.LoadScene(mainMenu);
    }
}
