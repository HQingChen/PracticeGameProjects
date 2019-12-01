using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovingObject : MonoBehaviour
{

    public float moveTime = 0.1f;
    public LayerMask blockLayer;

    private BoxCollider2D boxCollider;
    private Rigidbody2D rb2D;
    private float speed; //Used to make movement more efficient.

    public Animator animator;

    // Start is called before the first frame update
    protected virtual void Start() // for overwritten
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb2D = GetComponent<Rigidbody2D>();
        speed = .4f / moveTime;
    }

    //Move returns true if it is able to move and false if not. 
    protected virtual void Move(int x, int y)
    {
        //Store start position to move from, based on objects current transform position.
        Vector2 start = transform.position;

        
        //boxCollider.enabled = false;

        //hit = Physics2D.Linecast(start, end, blockLayer);

        //boxCollider.enabled = true;

        //if (hit.transform == null)
        //{
        //    StartCoroutine(SmoothMovement(end));

        //    return true;
        //}
        var xPos = Mathf.Clamp(start.x + x, 0f, 9f);
        var yPos = Mathf.Clamp(start.y + y, 0f, 9f);
        Vector2 end = new Vector2(xPos, yPos);
        
        if (x>0) {
            animator.SetTrigger("MoveRight");
        }
        else if (x<0) {
            animator.SetTrigger("MoveLeft");
        }
        else if (y>0) {
            animator.SetTrigger("MoveUp");
        }
        else if (y<0) {
            animator.SetTrigger("MoveDown");
        }
        StartCoroutine(SmoothMovement(end));

    }


    //Co-routine for moving units from one space to next, takes a parameter end to specify where to move to.
    protected IEnumerator SmoothMovement(Vector3 end)
    {

        float sqrRemainingDistance = (transform.position - end).sqrMagnitude;

        //While that distance is greater than a very small amount (Epsilon, almost zero):
        while (sqrRemainingDistance > float.Epsilon)
        {
            //Find a new position proportionally closer to the end, based on the moveTime
            Vector3 newPostion = Vector3.MoveTowards(rb2D.position, end, speed * Time.deltaTime);

            //Call MovePosition on attached Rigidbody2D and move it to the calculated position.
            rb2D.MovePosition(newPostion);

            //Recalculate the remaining distance after moving.
            sqrRemainingDistance = (transform.position - end).sqrMagnitude;

            //Return and loop until sqrRemainingDistance is close enough to zero to end the function
            yield return null;
        }

        animator.SetTrigger("Idle");
        GameManager.instance.playersTurn = true;
    }

    //protected virtual void AttemptMove(int x, int y)
    //{
    //    RaycastHit2D hit;

    //    bool canMove = Move(x, y, out hit);

    //    if (hit.transform == null)
    //    {
    //        return;
    //    }

    //    GameManager.instance.playersTurn = true;
    //}

}