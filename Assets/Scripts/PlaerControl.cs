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

    private bool stoppedJumpin;
    private bool doubleJumpCan;

    private  Rigidbody2D myRigidbody;

    public bool grounCheck;
    public LayerMask whatIsGround;
    public Transform CubeCheckGround;
    public float CubeCheckGroundradiys;

    public AudioSource jumpSound;
    public AudioSource dethSound;
    

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

        stoppedJumpin = true;
        
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
                stoppedJumpin = false;
                jumpSound.Play();
            }

            if (!grounCheck && doubleJumpCan)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, playerJumpForce);
                playerJumpTimeCounter = playerJumpTime;
                stoppedJumpin = false;
                doubleJumpCan = false;
                jumpSound.Play();
            }
        }

        if ((Input.GetKey (KeyCode.Space)|| Input.GetMouseButton(0)) && !stoppedJumpin)
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
            stoppedJumpin = true;
        }

        if (grounCheck)
        {
            playerJumpTimeCounter = playerJumpTime;
            doubleJumpCan = true;
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
            dethSound.Play();
        }
    }
}
