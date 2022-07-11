using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaerControl : MonoBehaviour
{
    public float playerMoveSpeed;
    public float playerJumpForce;

    private  Rigidbody2D myRigidbody;

    public bool grounCheck;
    public LayerMask whatIsGround;

    private Collider2D  myCollider;

    private Animator myAnimator;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();

        myCollider = GetComponent<Collider2D>();

        myAnimator= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        grounCheck = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

        myRigidbody.velocity = new Vector2(playerMoveSpeed, myRigidbody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if(grounCheck)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, playerJumpForce);
            }
        }

        myAnimator.SetFloat("playerSpeed", myRigidbody.velocity.x);
        myAnimator.SetBool("GrounCheck", grounCheck);
    }
}
