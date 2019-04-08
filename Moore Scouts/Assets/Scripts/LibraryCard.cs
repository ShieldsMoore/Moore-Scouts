using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibraryCard : MonoBehaviour
{

    public Animator myanim;
    private LevelManager theLM;
    public int coinValue;
    public AudioSource gemSound;

    // Use this for initialization
    void Start()
    {
        theLM = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            theLM.AddCoins(coinValue);
            myanim.SetBool("Dead", true);
            gemSound.Play();
        }
    }
}
