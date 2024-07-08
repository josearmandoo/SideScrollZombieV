using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1f;

    public float jumpForce = 3f;

    private Rigidbody2D rb;

    private SpriteRenderer spriteRenderer;

    public float horizontalInputPublic;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void SpriteFlip(float horizontalInput)
    {
        if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }

    void FixedUpdate()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3 (horizontalInput * speed * Time.deltaTime , 0f , 0f));
        SpriteFlip(horizontalInput);

        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            PlayJump();
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    #region AnimationHandler

        private Animator animator;

        private void PlayWalk()
        {
            animator.SetTrigger("goWalk");
        }

        private void PlayJump()
        {
            animator.SetTrigger("goJump");   
        }
    #endregion
}
