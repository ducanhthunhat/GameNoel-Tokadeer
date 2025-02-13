using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    public float speedMove;
    public float jumpForce = 5f;
    public LayerMask ground;
    public float rayCast; 
    public int maxHealth = 100;
    private int currentHealth;

    private float horizontal;
    private string currentName;
    private bool isGround = false;
    private bool facingRight = true;
    private bool doubleJump;
    private bool isAttack;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentHealth = maxHealth; // Đặt máu bắt đầu là tối đa
                                   
    }

    void FixedUpdate()
    {
        if (!isAttack)
        {
            rb.velocity = new Vector2(horizontal * speedMove, rb.velocity.y);
        }

    }
    void Update()
    {
        if (isAttack)
        {
            return;
        }
        isGround = checkGround();
        horizontal = Input.GetAxis("Horizontal");
        //move
        if(horizontal < 0 && !facingRight || horizontal > 0 && facingRight)
        {
            Flip();
        }
        if(isGround && horizontal!= 0)
        {
            changeAnim("run");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGround)
            {
                Jump();
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                doubleJump = true;
                audioManager.PlaySFX(audioManager.jump);

            }
            else if (doubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce * 0.9f);
                doubleJump = false;
                audioManager.PlaySFX(audioManager.jump);

            }

        }


        if (horizontal == 0 && isGround && isAttack == false)
        {
            changeAnim("idle");
        }

        if(Input.GetMouseButtonDown(0) && isGround)
        {
            Attack();
            audioManager.PlaySFX(audioManager.throwball);
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }

    private void changeAnim(string animName)
    {
        if(currentName != animName)
        {
            anim.ResetTrigger(animName);
            currentName = animName;
            anim.SetTrigger(currentName);
        }
    }

    private bool checkGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, rayCast, ground);
        return hit.collider != null;
    }
    private void Jump()
    {
        changeAnim("jump");
        isGround = false;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        //Debug.Log("Player Health: " + currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
        //else
        //{
        //    changeAnim("-hp");
        //}
    }

    public void Die()
    {
        Debug.Log("Player has died!");
        Invoke("ResetScene", 1f);
    }
    private void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Attack()
    {
        isAttack = true;
        changeAnim("throw");
        rb.velocity = Vector2.zero;
        Invoke("resteAttack", 0.3f);
    }

    private void resteAttack()
    {
        isAttack = false;
        changeAnim("idle");
    }
}
