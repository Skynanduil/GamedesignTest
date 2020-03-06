using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicMovement : MonoBehaviour
{
    private float MvSpeed;

    private Animator animator;
    private BaseStats baseStats;
    private Rigidbody2D rb2d;


    void Start()
    {
        animator = GetComponent<Animator>();
        baseStats = GetComponent<BaseStats>();
        rb2d = GetComponent<Rigidbody2D>();
        MvSpeed = baseStats.MovementSpeed;
    }
    void Update()
    {

    }

    void FixedUpdate()
    {
        var movement = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(movement));

        var direction = Mathf.Sign(movement);
        if (movement != 0)
        {
            transform.localScale = new Vector3(direction, transform.localScale.y, transform.localScale.z);
        }


        var horizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f) * MvSpeed;

        transform.position = transform.position + horizontal * Time.deltaTime;
    }
}
