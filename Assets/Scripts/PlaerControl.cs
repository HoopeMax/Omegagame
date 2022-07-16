using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaerControl : MonoBehaviour
{
    public float playerMoveSpeed;
    public float speedMulteplier;
    private float playerMoveSpeedStore;

    public float speedIncreaseMilestone;
    private float speedIncreaseMilestoneStore;

    private float speedMilestoneCount;
    private float speedMilestoneCountStore;

    public float playerJumpForce;
    public float playerJumpTime;
    private float playerJumpTimeCounter;

    private  Rigidbody2D myRigidbody;

    public bool grounCheck;
    public LayerMask whatIsGround;
    public Transform CubeCheckGround;
    public float CubeCheckGroundradiys;

    //private Collider2D  myCollider;

    private Animator myAnimator;

    public GameManager theGameManager;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();

        //myCollider = GetComponent<Collider2D>();

        myAnimator= GetComponent<Animator>();

        playerJumpTimeCounter = playerJumpTime;

        speedMilestoneCount = speedIncreaseMilestone;

        playerMoveSpeedStore = playerMoveSpeed;
        speedMilestoneCountStore = speedMilestoneCount;
        speedIncreaseMilestoneStore= speedIncreaseMilestone;
        
    }

    // Update is called once per frame
    void Update()
    {
        //grounCheck = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

        grounCheck = Physics2D.OverlapCircle(CubeCheckGround.position, CubeCheckGroundradiys ,whatIsGround);

        if(transform.position.x > speedMilestoneCount)
        {
            speedMilestoneCount += speedIncreaseMilestone;

            speedIncreaseMilestone = speedIncreaseMilestone * speedMulteplier;

            playerMoveSpeed = playerMoveSpeed * speedMulteplier;
        }

        myRigidbody.velocity = new Vector2(playerMoveSpeed, myRigidbody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if(grounCheck)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, playerJumpForce);
            }
        }

        if (Input.GetKey (KeyCode.Space)|| Input.GetMouseButton(0))
        {
            if (playerJumpTimeCounter > 0)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, playerJumpForce);
                playerJumpTimeCounter -= Time.deltaTime;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            playerJumpTimeCounter = 0;
        }

        if (grounCheck)
        {
            playerJumpTimeCounter = playerJumpTime;
        }

        myAnimator.SetFloat("playerSpeed", myRigidbody.velocity.x);
        myAnimator.SetBool("GrounCheck", grounCheck);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "killbox")
        {
            theGameManager.RestartGame();
            playerMoveSpeed = playerMoveSpeedStore;
            speedMilestoneCount = speedMilestoneCountStore;
            speedIncreaseMilestone=speedIncreaseMilestoneStore;
        }
    }
}
