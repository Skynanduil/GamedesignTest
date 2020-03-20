using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BaseStats))]
public class BasicMovement : MonoBehaviour
{
    private float MvSpeed;
    private float JumpSpeed;

    private Animator animator;
    private BaseStats baseStats;
    private Rigidbody2D rb2d;
    private BoxCollider2D bc2d;
    [SerializeField]private LayerMask platformslayerMask;


    void Start()
    {
        animator = GetComponent<Animator>();
        baseStats = GetComponent<BaseStats>();
        rb2d = GetComponent<Rigidbody2D>();
        bc2d = GetComponent<BoxCollider2D>();
        MvSpeed = baseStats.MovementSpeed;
        JumpSpeed = baseStats.JumpSpeed;
    }

    void FixedUpdate()
    {
        var movement = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(movement));

        //Direction
        var direction = Mathf.Sign(movement);
        if (movement != 0)
        {
            transform.localScale = new Vector3(direction, transform.localScale.y, transform.localScale.z);
        }

        bool isgrounded = IsGrounded();
        animator.SetBool("isGrounded", isgrounded);
        if (isgrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb2d.velocity = Vector2.up * JumpSpeed;
        }

        var horizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f) * MvSpeed;

        rb2d.position = (transform.position + horizontal*Time.deltaTime);
        //transform.position = transform.position + horizontal * Time.deltaTime;
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(bc2d.bounds.center, bc2d.bounds.size, 0f, Vector2.down , .1f, platformslayerMask)
                   .collider != null;
    }
}
