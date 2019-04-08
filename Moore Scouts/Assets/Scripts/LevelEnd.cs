using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour {

    public string levelToLoad;
    public GameObject youwin;
    public PlayerController pc;
    public Rigidbody2D rb2D;
    public Animator myanim;
 

    public string Main;
    public string Next;
   

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //public IEnumerator LevelEndCo()
   // {
   //     myanim.SetBool("Win", true);
   //     pc.enabled = false;
   //     rb2D.velocity = Vector2.zero;
   //     youwin.SetActive(true);
        //yield return new WaitForSeconds(2f);
        //SceneManager.LoadScene(levelToLoad);
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            myanim.SetBool("Win", true);
            pc.enabled = false;
            rb2D.velocity = Vector2.zero;
            youwin.SetActive(true);
           
           

            //StartCoroutine("LevelEndCo");
        }
    }

    public void VisitMoore()
    {
        Application.OpenURL("https://moore.edu/");
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(Next);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(Main);
    }
}
