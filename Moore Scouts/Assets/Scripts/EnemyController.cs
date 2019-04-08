using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    // Use this for initialization
    public Rigidbody2D enemyRB;
    public float moveSpeed;

    public LayerMask playerLayer;
    public Animator myanim;
    public float jumpForce;
    public float fallMultiplier;

    bool CanMoveL()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.left;
        float distance = 15f;

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, playerLayer);
        if (hit.collider != null)
        {
            return true;
        }
        return false;
    }

    bool CanMoveR()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.right;
        float distance = 15f;

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, playerLayer);
        if (hit.collider != null)
        {
            return true;
        }
        return false;
    }
    bool CanJump()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.up;
        float distance = 5f;

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, playerLayer);
        if (hit.collider != null)
        {
            return true;
        }
        return false;
    }

    bool JumpWall()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.right;
        float distance = 5f;

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, playerLayer);
        if (hit.collider != null && hit.collider.tag == "Ground")
        {
            return true;
        }
        return false;
    }

    void Start()
        {

        }

        // Update is called once per frame
    void Update()
        {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.left;
        Vector2 direction1 = Vector2.right;

        float distance = 5f;
        Debug.DrawRay(position, direction, Color.green, distance);
        Debug.DrawRay(position, direction1, Color.green, distance);

        if (CanMoveL())
        {
            enemyRB.velocity = new Vector2(-moveSpeed, enemyRB.velocity.y);
            transform.localScale = new Vector2(-1f, 1f);
            myanim.SetBool("Seen", true);
        }
        else if (CanMoveR())
        {
            enemyRB.velocity = new Vector2(moveSpeed, enemyRB.velocity.y);
            transform.localScale = new Vector2(1f, 1f);
            myanim.SetBool("Seen", true);
        }

       
        else
        {
            enemyRB.velocity = new Vector2(0, enemyRB.velocity.y);
            myanim.SetBool("Seen", false);
        }
        if (CanJump())
        {
            enemyRB.AddForce(new Vector2(0, jumpForce));
            myanim.SetBool("Seen", true);
        }

        if (JumpWall())
        {
            enemyRB.AddForce(new Vector2(0, jumpForce));
            myanim.SetBool("Seen", true);
        }


    }

    private void FixedUpdate()
    {
        if (enemyRB.velocity.y < 0)
        {
            enemyRB.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }

        
    }
}