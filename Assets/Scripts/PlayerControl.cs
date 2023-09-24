using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public int hp = 1;
    private Animator ani;
    private Rigidbody2D rBody;
    public BgControl bgControl;
    //�Ƿ���ڵ�����--�������������Ծ
    private bool isGround;

    // Start is called before the first frame update
    void Start()
    {
        //��ȡ���
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


        //ˮƽ��
        float horizontal = Input.GetAxis("Horizontal");
        if (horizontal != 0)
        {
            ani.SetBool("IsRun", true);
            //�������෴�����ƶ�
            bgControl.move(horizontal);

        }
        else
        {
            ani.SetBool("IsRun", false);

        }

        if (Input.GetKeyDown(KeyCode.Space) && isGround == true)//�������������ڵ����ϲ���������ֹ��������
        {
            //������
            rBody.AddForce(Vector2.up * 170);
            AudioManager.Instance.PlayJump();//��������

            //ani.SetBool("IsJump", true);������д

        }
        //else
        //{
        //    ani.SetBool("IsJump", false);

        //}

    }

    //������ײ ���÷���
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            isGround = true;
            ani.SetBool("IsJump", false);

        }
    }
    //�뿪��ײ
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isGround = false;
            ani.SetBool("IsJump", true);

        }
    }
    //�����Ȧ��ײ����Χ��hp��0
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Fire")
        {
            hp--;
            Destroy(rBody);//���ٸ���ʹģ��ͣ�ڰ��
            ani.SetBool("Die", true);
            AudioManager.Instance.PlayDie();
        }
    }

}
