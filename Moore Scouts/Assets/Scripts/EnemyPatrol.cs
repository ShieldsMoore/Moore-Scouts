using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyPatrol : MonoBehaviour
{

    public GameObject objectToMove;
    public Transform Point1;
    public Transform Point2;
    public float moveSpeed;

    public Vector3 currentTarget;

    public LayerMask playerLayer;
    public bool playertarget;
    public GameObject player;
    

    bool CanMoveL()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.left;
        float distance = 5f;

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
        float distance = 5f;

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, playerLayer);
        if (hit.collider != null)
        {
            return true;
        }
        return false;
    }

    // Use this for initialization
    void Start()
    {

        currentTarget = Point2.position;
    }

    // Update is called once per frame
    void Update()
    {

        objectToMove.transform.position =
            Vector3.MoveTowards(objectToMove.transform.position, currentTarget, moveSpeed * Time.deltaTime);

        if (Mathf.Approximately(objectToMove.transform.position.x,Point2.position.x))
        {
            playertarget = false;
            currentTarget = Point1.position;
            transform.localScale = new Vector2(1f, 1f);
        }
        if (Mathf.Approximately(objectToMove.transform.position.x,Point1.position.x))
        {
            playertarget = false;
            currentTarget = Point2.position;
            transform.localScale = new Vector2(-1f, 1f);
        }

        if (CanMoveL())
        {
            transform.localScale = new Vector2(1f, 1f);
        }
        else if (CanMoveR())
        {
            transform.localScale = new Vector2(-1f, 1f);
        }

        if (CanMoveL() || CanMoveR() && objectToMove.transform.position.x < Point2.position.x && objectToMove.transform.position.x > Point1.position.x)
        {
            playertarget = true;
        }

        if (playertarget == true)
        {
            if (player.transform.position.x > objectToMove.transform.position.x){
                transform.localScale = new Vector2(-1f, 1f);
            }
            else
            {
                transform.localScale = new Vector2(1f, 1f);
            }

            currentTarget = new Vector2(player.transform.position.x, transform.position.y);
        }
    }
}