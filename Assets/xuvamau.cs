using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class xuvamau : MonoBehaviour
{   
    //Khai báo máu,vật phẩm,animation
    public int Health = 5;
    public int Coin = 0;
    public Animator anim;
    void Start()
    {

    }

    void Update()
    {

    }

    //Nhặt vật phẩm,trừ máu
    private void OnTriggerEnter2D(Collider2D collision)
    {   
        //Nhặt vật phẩm
        if (collision.CompareTag("xu"))
        {
            Coin++;
            Destroy(collision.gameObject);
        }
        //Trừ máu
        if (collision.CompareTag("gai"))
        {
            Health--;
        }
        if (Health <= 0)
        {
            anim.SetTrigger("die");
        }
    }
}
