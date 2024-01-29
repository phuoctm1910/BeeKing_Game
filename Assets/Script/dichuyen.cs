using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dichuyen : MonoBehaviour
{
    public float tocDo;
    private bool isGrounded = false;
    public float groundCheckDistance = 0.1f;
    public bool isfacingRight = true;
    public float traiPhai;
    [SerializeField] private float jumpucs = 15f;
    public Rigidbody2D rb;
    public Animator anim;
    [SerializeField] public float attack;
    [SerializeField] private LayerMask groundcheck;
    [SerializeField] private Transform Ground;

    public BoxCollider2D coll;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
        }
        catch (System.Exception e)
        {
            Debug.LogException(e);
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        traiPhai = Input.GetAxisRaw("Horizontal");
        // Cập nhật vận tốc chỉ một lần
        rb.velocity = new Vector2(tocDo * traiPhai, rb.velocity.y);

        // Kiểm tra nhân vật có đang đứng trên mặt đất hay không
        isGrounded = IsGround();

        // Xử lý việc nhảy
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            jump();
        }

        // Xử lý việc lật nhân vật
        flip();

        // Xử lý animation di chuyển
        anim.SetFloat("dichuyen", Mathf.Abs(traiPhai));

        // Xử lý việc tấn công
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            anim.SetTrigger("attack");
        }
    }

    void flip()
    {
        if (isfacingRight && traiPhai < 0 || !isfacingRight && traiPhai > 0)
        {
            isfacingRight = !isfacingRight;
            Vector3 kichthuoc = transform.localScale;
            kichthuoc.x = kichthuoc.x * -1;
            transform.localScale = kichthuoc;

        }
    }

    private void jump()
    {

        rb.AddForce(new Vector2(0f, jumpucs), ForceMode2D.Impulse);


    }
    private bool IsGround()
    {
        Vector2 boxcastOrigin = Ground.position;

        // Tạo một vector hướng xuống (trục y âm) để thực hiện Boxcast
        Vector2 boxcastDirection = Vector2.down;
        RaycastHit2D hitInfo = Physics2D.BoxCast(boxcastOrigin, new Vector2(0.9f, 0.1f), 0f, boxcastDirection, groundCheckDistance, groundcheck);
        if (hitInfo.collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
