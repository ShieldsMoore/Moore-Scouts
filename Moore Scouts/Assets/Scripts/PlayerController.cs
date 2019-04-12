using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public float jumpSpeed;
    private Rigidbody2D myRB;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float speed;

    public LayerMask groundLayer;
    public Transform raycaster;
    public Transform raycaster2;
    public Transform raycaster3;

    private Animator myAnim;

    public Vector3 respawnPosition;
    public LevelManager theLevelManager;

    public GameObject stompBox;

    public float knockBackForce;
    public float knockBackLength;
    public float knockBackCounter;

    public float invincibilityLength;
    public float invincibilityCounter;

    public AudioSource jumpSound;

    public float bulletSpeed;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    public int jumpCount;
    public float jumpgrace;
    public float jumpgracetime;

    public bool moveR;
    public CinemachineVirtualCamera cv;
    public bool canShoot;
    public bool canMove;

    public Text Ready;
    public Button b;
    public bool block;

    public bool accel;



    // Use this for initialization

    bool IsGrounded()
    {
        Vector2 position = new Vector2(raycaster.position.x, raycaster.position.y);
        Vector2 position2 = new Vector2(raycaster2.position.x, raycaster2.position.y);
        Vector2 position3 = new Vector2(raycaster3.position.x, raycaster3.position.y);

        Vector2 direction = Vector2.down;
        float distance = .25f;

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        RaycastHit2D hit2 = Physics2D.Raycast(position2, direction, distance, groundLayer);
        RaycastHit2D hit3 = Physics2D.Raycast(position3, direction, distance, groundLayer);

        if (hit.collider != null)
        {
            return true;
        }
        if (hit2.collider != null)
        {
            return true;
        }
        if (hit3.collider != null)
        {
            return true;
        }
        return false;
    }
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        theLevelManager = FindObjectOfType<LevelManager>();
        respawnPosition = transform.position;
        StartCoroutine("ReadySet");
    }

    // Update is called once per frame
    void Update()
    {
        if(accel == true)
        {
            transform.Translate(Input.acceleration.x, 0, 0);
        }
        
        jumpgrace -= Time.deltaTime;

        Vector2 position = new Vector2(raycaster.position.x, raycaster.position.y);
        Vector2 position2 = new Vector2(raycaster2.position.x, raycaster.position.y);
        Vector2 position3 = new Vector2(raycaster3.position.x, raycaster.position.y);

        Vector2 direction = Vector2.down;
        float distance = .25f;
        Debug.DrawRay(position, direction, Color.green, distance);
        Debug.DrawRay(position2, direction, Color.green, distance);
        Debug.DrawRay(position3, direction, Color.green, distance);

        if(IsGrounded() == true)
        {
            jumpCount = 2;
        }

        if (transform.localScale.x == 1)
        {
            bulletSpeed = 15f;
        }

        if(transform.localScale.x == -1)
        {
            bulletSpeed = -15f;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                // Check if finger is over a UI element
                if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                {
                    block = true;
                }
                else
                {
                    block = false;
                }
            }

        if (knockBackCounter <= 0 && canMove == true)

        {
            

            if (Input.GetMouseButtonDown(0) && EventSystem.current.IsPointerOverGameObject() == false && block == false)
            {

                jumpgrace = jumpgracetime;
            }

            if (jumpgrace > 0 && IsGrounded())
            {
                jumpgrace = 0;
                jumpCount -= 1;
                myRB.velocity = new Vector2(myRB.velocity.x, jumpSpeed);
                jumpSound.Play();
             }


            if (moveR == true  && accel == false)
            {
                myRB.velocity = new Vector2(moveSpeed, myRB.velocity.y);
            }
            if (moveR == false && accel == false)
            {
                myRB.velocity = new Vector2(-moveSpeed, myRB.velocity.y);
            }
            
            if (Input.GetAxisRaw("Horizontal") > 0f)
            {
                myRB.velocity = new Vector2(moveSpeed, myRB.velocity.y);
                transform.localScale = new Vector2(1f, 1f);
            }
            else if (Input.GetAxisRaw("Horizontal") < 0f)
            {
                myRB.velocity = new Vector2(-moveSpeed, myRB.velocity.y);
                transform.localScale = new Vector2(-1f, 1f);
            }

            else
            {
               // myRB.velocity = new Vector2(0, myRB.velocity.y);
            }

            //if (Input.GetButtonDown("Jump"))
            //{
            //    jumpgrace = jumpgracetime;
            //}

            //if (Input.GetButtonDown("Jump") && jumpCount > 0 && IsGrounded() == false)
            //{
            //    jumpCount -= 1;
            //    myRB.velocity = new Vector2(myRB.velocity.x, jumpSpeed);
            //    jumpSound.Play();

            //}

            //if (jumpgrace > 0 && IsGrounded() && jumpCount > 0)
            //{
            //    jumpgrace = 0;
            //    jumpCount -= 1;
            //    myRB.velocity = new Vector2(myRB.velocity.x, jumpSpeed);
            //    jumpSound.Play();
           // }

            if (Input.GetButtonDown("Fire1") && theLevelManager.coinCount > 0 && canShoot == true)
            {
                theLevelManager.coinCount -= 1;
                theLevelManager.gemText.text = "Cookies:" + theLevelManager.coinCount;
                Fire();
            }
        }

        if (knockBackCounter > 0)
        {
            StartCoroutine("Hit");
            knockBackCounter -= Time.deltaTime;

            if (transform.localScale.x > 0)
            {
                myRB.velocity = new Vector2(-knockBackForce, knockBackForce);
            }
            else
            {
                myRB.velocity = new Vector2(knockBackForce, knockBackForce);
            }
        }
        if (invincibilityCounter > 0)
        {
            invincibilityCounter -= Time.deltaTime;
        }

        if (invincibilityCounter <= 0)
        {
            theLevelManager.invincible = false;
        }
            myAnim.SetFloat("MoveSpeed", Mathf.Abs(myRB.velocity.x));
        myAnim.SetFloat("JumpSpeed", myRB.velocity.y);
        myAnim.SetBool("Grounded", IsGrounded());

        if (myRB.velocity.y < 0 && knockBackCounter <= 0)
        {
            stompBox.SetActive(true);
        }
        else 
        {
            stompBox.SetActive(false);
        }
    }

    IEnumerator ReadySet()
    {
        Ready.text = "Get Ready";
        yield return new WaitForSeconds(2f);
        Ready.text = "GO!!";
        canMove = true;
    }

    public void Switch()
    {
        if (!moveR)
        {
            moveR = true;
            transform.localScale = new Vector2(1f, 1f);
            cv.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenX = .21f;
        }
        else
        {
            moveR = false;
            transform.localScale = new Vector2(-1f, 1f);
            cv.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenX = .75f;
        }
        

    }

    void Fire ()
    {
        var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector3(bulletSpeed, 0, 0);
        Destroy(bullet, .35f);
    }

    public IEnumerator Hit ()
    {
        myAnim.SetBool("Hurt", true);
        yield return new WaitForSeconds(.25f);
        myAnim.SetBool("Hurt", false);
    }
    private void FixedUpdate()
    {
        if (myRB.velocity.y < 0)
        {
           myRB.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }

        else if (myRB.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            myRB.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    public void Jump()
    {
        if (jumpCount > 1)
        {
            jumpCount -= 1;
            myRB.velocity = new Vector2(myRB.velocity.x, jumpSpeed);
            jumpSound.Play();
        }
                

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Checkpoint")
        {
            respawnPosition = collision.transform.position;
        }
        if (collision.tag == "killplane")
        {
            theLevelManager.Respawn();
            //transform.position = respawnPosition;
            //gameObject.SetActive(false);
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {

  
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MovingPlatform")
        {
         transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "MovingPlatform")
        {
            transform.parent = null;
        }


    }

    public void KnockBack()
    {
        knockBackCounter = knockBackLength;
        invincibilityCounter = invincibilityLength;
        theLevelManager.invincible = true;
    }

    
}