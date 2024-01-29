using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frog : MonoBehaviour
{

    // Khai báo di chuyển,nhảy,nhảy đôi,animation
    public Rigidbody2D rb;
    public int tocDo = 7;
    public float lucNhay = 7;
    public float diChuyen;
    public bool faceRight = true;
    public Animator anim;
    public Transform _duocPhepNhay;
    public LayerMask san;
    private bool duocPhepNhay;
    private bool nhayDoi;
    void Start()
    {

    }

    void Update()
    {

        // Code di chuyển qua lại
        diChuyen = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(tocDo * diChuyen, rb.velocity.y);

        if (faceRight == true && diChuyen == -1)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            faceRight = false;
        }
        if (faceRight == false && diChuyen == 1)
        {
            transform.localScale = new Vector3(1, 1, 1);
            faceRight = true;
        }

        // Animation di chuyển
        anim.SetFloat("run", Mathf.Abs(diChuyen));

        // Animation tấn công chuột trái
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("At1");
        }

        // Animation tấn công chuột phải
        if (Input.GetMouseButtonDown(1))
        {
            anim.SetTrigger("At2");
        }

        // Code nhảy đơn
        duocPhepNhay = Physics2D.OverlapCircle(_duocPhepNhay.position, 0.2f, san);
        if (Input.GetKeyDown(KeyCode.Space) && duocPhepNhay)
        {
            rb.velocity = new Vector2(rb.velocity.x, lucNhay);
            anim.SetTrigger("jump");
        }

        // Code nhảy đôi
        if (duocPhepNhay && !Input.GetKey(KeyCode.Space))
        {

            nhayDoi = false;

        }
        if (Input.GetKeyDown(KeyCode.Space))

        {
            if (duocPhepNhay || nhayDoi)
            {
                rb.velocity = new Vector2(rb.velocity.x, lucNhay);
                nhayDoi = !nhayDoi;
                anim.SetTrigger("doubleJump");
            }
        }
    }
}
