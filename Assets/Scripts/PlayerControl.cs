using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public int hp = 1;
    private Animator ani;
    private Rigidbody2D rBody;
    public BgControl bgControl;
    //是否踩在地面上--避免空中无限跳跃
    private bool isGround;

    // Start is called before the first frame update
    void Start()
    {
        //获取组件
        ani = this.GetComponent<Animator>();
        rBody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hp < 0)
        {
            return;
        }


        //水平轴
        float horizontal = Input.GetAxis("Horizontal");
        if (horizontal != 0)
        {
            ani.SetBool("IsRun", true);
            //背景向相反方向移动
            bgControl.move(horizontal);

        }
        else
        {
            ani.SetBool("IsRun", false);

        }

        if (Input.GetKeyDown(KeyCode.Space) && isGround == true)//加限制条件：在地面上才能跳，防止空中连跳
        {
            //向上跳
            rBody.AddForce(Vector2.up * 170);
            AudioManager.Instance.PlayJump();//播放音乐

            //ani.SetBool("IsJump", true);在下面写

        }
        //else
        //{
        //    ani.SetBool("IsJump", false);

        //}

    }

    //进入碰撞 内置方法
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            isGround = true;
            ani.SetBool("IsJump", false);

        }
    }
    //离开碰撞
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isGround = false;
            ani.SetBool("IsJump", true);

        }
    }
    //进入火圈碰撞器范围，hp归0
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Fire")
        {
            hp--;
            Destroy(rBody);//销毁刚体使模型停在半空
            ani.SetBool("Die", true);
            AudioManager.Instance.PlayDie();
        }
    }

}
