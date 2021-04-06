using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float moveSpeed = 5.0f;
    float jumpPower = 7.5f;

    public Transform groundChecker;
    public float groundRadius = 0.4f;
    public LayerMask groundLayer;

    bool isGround = true;
    Rigidbody2D rb;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>() ;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            anim.SetBool("isAttack", true);
            SoundManager.instance.AttackSound();

            Collider2D col = Physics2D.OverlapCircle(transform.position, 2, (1 << LayerMask.NameToLayer("Enemy")));

            if (col != null)
            {
                col.GetComponent<Enemy>().Die();
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            anim.SetBool("isAttack", false);
        }
        isGround = Physics2D.OverlapCircle(groundChecker.position, groundRadius, groundLayer);
    }

    void FixedUpdate()
    {
        Jump();
        Move();
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W) && isGround)
        {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
    }

    void Move()
    {
        float posX = Input.GetAxis("Horizontal");
        if (posX != 0)
        {
            if (posX > 0)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
        }
        transform.Translate(Mathf.Abs(posX) * Vector3.right * moveSpeed * Time.deltaTime);
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawSphere(groundChecker.position, groundRadius);
    }
}
