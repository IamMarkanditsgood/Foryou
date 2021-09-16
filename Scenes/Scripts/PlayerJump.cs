using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    Rigidbody2D player;

    private bool isUp;
    public Transform upCheck;
    public float checkRadiusup;
    public LayerMask whatIsUp;
    bool crouching = false;
    bool DoJamp = true;


    public BoxCollider2D box;
    public CircleCollider2D cirkle;
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        isUp = Physics2D.OverlapCircle(upCheck.position, checkRadiusup, whatIsUp);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if(Input.GetKeyDown(KeyCode.C) && crouching == false )
        {

            box.enabled = true;
            cirkle.enabled = false;
            crouching = true;
        }
        else if (Input.GetKeyDown(KeyCode.C) && crouching == true && isUp == false)
        {
 
            box.enabled = true;
            cirkle.enabled = true;
            crouching = false;
        }
        Jump();
    }
    void Jump()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space) && DoJamp)
        {
            StartCoroutine(time());
            DoJamp = false;
        }
    }
    IEnumerator time()
    {
        player.AddForce(Vector2.up * Data.JumpForse, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.2f);
        DoJamp = true;
    }
}
