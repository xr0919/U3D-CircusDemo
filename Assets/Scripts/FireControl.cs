using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireControl : MonoBehaviour
{
    private PlayerControl pc;
    // Start is called before the first frame update
    void Start()
    {
        pc = GameObject.FindWithTag("Player").GetComponent<PlayerControl>();//���ݱ�ǩ��ȡ�ű�

    }

    // Update is called once per frame
    void Update()
    {
        //�������������־�ֹ
        if(pc.hp < 1)
        {
            return;
        }
        //���������Ļ�������Լ�
        if(this.transform.position.x < -2f)
        {
            Destroy(this.gameObject);
        }
        this.transform.Translate(Vector2.left * Time.deltaTime * 0.5f);//1���ƶ�0.5
    }
}
