
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class LevelManager : MonoBehaviour {

    public AudioMixerSnapshot main;
    public AudioMixerSnapshot cave;
    public float waitToRespawn;
    public PlayerController thePlayer;
    public GameObject DieBurst;

    public Image heart1;
    public Image heart2;
    public Image heart3;

    public Sprite heartFull;
    public Sprite heartHalf;
    public Sprite heartEmpty;

    public int maxHealth;
    public int healthCount;
    public bool respawning;

    public ResetonRespawn[] objectsToReset;

    public bool invincible;

    public int currentLives;
    public int startingLives;
    public Text livesText;

    public GameObject gameOverScreen;
    public int coinCount;

    public Text gemText;
    public AudioSource explodeSound;
    public AudioSource hurtSound;
    public bool endlessLives;

    // Use this for initialization
	void Start () {
        main.TransitionTo(.1f);
        thePlayer = FindObjectOfType<PlayerController>();
        healthCount = maxHealth;
        objectsToReset = FindObjectsOfType<ResetonRespawn>();
        currentLives = startingLives;
        livesText.text = "Lives x" + currentLives;
        gemText.text = "Cookies:" + coinCount;
	}

    public void AddCoins(int coinsToAdd)
    {
        coinCount += coinsToAdd;
        gemText.text = "Cookies:" + coinCount;
    }


    public void GiveHealth(int healthtoGive)
    {
        healthCount += healthtoGive;

        if (healthCount > maxHealth)
        {
            healthCount = maxHealth;
        }

        UpdateHeartMeter();
    }
	// Update is called once per frame
	void Update () {
		
        if (healthCount <= 0 && !respawning)
        {
            Respawn();
            respawning = true;
        }
	}

    public void HurtPlayer(int damageToTake)
    {
        if (!invincible)
        {
           // hurtSound.Play();
            healthCount -= damageToTake;
            thePlayer.KnockBack();
        }
    }
    public void UpdateHeartMeter()
    {
        switch(healthCount)
        {
            case 6: 
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartFull;
                return;

            case 5:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartHalf;
                return;

            case 4:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartEmpty;
                return;

            case 3:
                heart1.sprite = heartFull;
                heart2.sprite = heartHalf;
                heart3.sprite = heartEmpty;
                return;

            case 2:
                heart1.sprite = heartFull;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                return;

            case 1:
                heart1.sprite = heartHalf;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                return;

            case 0:
                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                return;

            default:
                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                return;

        }

    }
    public void Respawn ()
    {
        if (endlessLives == false)
        {
            currentLives -= 1;
        }
       
        livesText.text = "Lives x" + currentLives;


        if (currentLives > 0)
        {
            StartCoroutine("RespawnCo");
        }
        else
        {
            thePlayer.gameObject.SetActive(false);
            gameOverScreen.SetActive(true);
            cave.TransitionTo(1f);
        }
    }

    public IEnumerator RespawnCo()
    {
        thePlayer.gameObject.SetActive(false);
        Instantiate(DieBurst, thePlayer.transform.position, thePlayer.transform.rotation);
        thePlayer.knockBackCounter = 0;
        yield return new WaitForSeconds(waitToRespawn);
        healthCount = maxHealth;
        respawning = false;
        UpdateHeartMeter();
        thePlayer.transform.position = thePlayer.respawnPosition;
        thePlayer.gameObject.SetActive(true);

        for (int i = 0; i < objectsToReset.Length; i++ )
        {
            objectsToReset[i].ResetObject();
        }
    }

    public void AddLives (int livestoAdd)
    {
        currentLives += livestoAdd;
        livesText.text = "Lives x" + currentLives;
    }

}
