using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaerControl : MonoBehaviour
{
    public float playerMoveSpeed;
    public float playerJumpForce;

    private  Rigidbody2D myRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        myRigidbody.velocity = new Vector2(playerMoveSpeed, myRigidbody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, playerJumpForce);
        }
    }
}
