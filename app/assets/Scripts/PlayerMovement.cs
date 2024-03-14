using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed = 2f;
    public float jumpPower = 5f;
    private float xAxis;
    private bool moveX;
    private bool moveY;

    // for ground check point
    public LayerMask surfaceLayer;
    public float groundCheckPointRadius;
    public Transform groundCheckPointObject;
    public bool isTouchingGround;  // if true, means the Player is touching the ground

    // for dashing
    private bool canDash;
    private bool isDashing;
    public float dashingPower;
    public float dashingTime;
    public float dashingCooldownTime;
    private TrailRenderer tr;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        moveX = false;
        moveY = false;  // both movements -> x and y are false at the start of the scene 
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<TrailRenderer>();
        isDashing = false;
        canDash = true ;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDashing)
        {
            return;  // so we don't go down for further operations unless isDashing isn't false
        }


        if (Input.GetMouseButtonDown(1) && canDash)
        {
            StartCoroutine(Dash());
        }

        // always take input in Update(), and apply physics in FixedUpdate()

        // down is movement
        xAxis = Input.GetAxis("Horizontal");
        if(xAxis>0 || xAxis < 0)
        {
            moveX = true;
        }
        else
        {
            moveX = false;
        }

        // down is jump
        if (Input.GetMouseButtonDown(0))
        {
            moveY = true;
        }
        else
        {
            moveY = false;
        }

        // returns true if player object is touching the ground
        isTouchingGround = Physics2D.OverlapCircle(groundCheckPointObject.position, groundCheckPointRadius, surfaceLayer);

        // jumping 
        if (moveY && isTouchingGround)
        {
            // play jump sound and then jump
            GetComponent<AudioSource>().Play();

            ApplyJump();
        }

        // ability to start over
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;  // so we don't go down for further operations unless isDashing isn't false
        }


        if (moveX)
        {
            ApplyMovement();
        }
       // jumping is in update()s
    }

    void ApplyMovement()
    {
        rb.velocity = new Vector2(xAxis * moveSpeed, rb.velocity.y);
    }
    void ApplyJump()
    {
       // rb.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
        rb.velocity = new Vector2(rb.velocity.x, jumpPower);
    }

    IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0; // so we can dash only in x axis straight and no gravity to pull down
        rb.velocity = new Vector2(xAxis * moveSpeed * dashingPower, 0);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);  // wait for dash to complete and start other operations
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldownTime);  // a bit time when dashing completes
        canDash = true;
    }

    // this function will return whether the trail emitting is true or false
    public bool TrailEmitting()
    {
        return isDashing;
    }

    // this method is used by walkingTrailScript
    public bool IsGrounded()
    {
        return isTouchingGround;
    }


    // below both function will be controlled by that particulay special hurdle trigger
    public void EnablePlayerSpecialJump(float specialJumpPower)
    {
        jumpPower += specialJumpPower;
    }

    public void DisablePlayerSpecialJump(float specialJumpPower)
    {
        jumpPower -= specialJumpPower;
    }

}
