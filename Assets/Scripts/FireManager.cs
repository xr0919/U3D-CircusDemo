using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireManager : MonoBehaviour
{
    public GameObject Fire;
    //���ֵļ��ʱ��
    private float cd = 2f;
    //��ȡ���
    private PlayerControl pc;
    // Start is called before the first frame update
    void Start()
    {
        pc = GameObject.FindWithTag("Player").GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(pc.hp);

        if (pc.hp <= 0)
        {
            return;
        }
        cd -= Time.deltaTime;//����ʱ����
        if(cd <= 0)
        {
            Instantiate(Fire,transform.position, Quaternion.identity);
            //����cd
            cd = 2f + Random.Range(-0.5f, 0.5f);
        }
    }
}
