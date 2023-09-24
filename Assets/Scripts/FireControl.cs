using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireControl : MonoBehaviour
{
    private PlayerControl pc;
    // Start is called before the first frame update
    void Start()
    {
        pc = GameObject.FindWithTag("Player").GetComponent<PlayerControl>();//根据标签获取脚本

    }

    // Update is called once per frame
    void Update()
    {
        //如果玩家死亡保持静止
        if(pc.hp < 1)
        {
            return;
        }
        //如果出了屏幕，销毁自己
        if(this.transform.position.x < -2f)
        {
            Destroy(this.gameObject);
        }
        this.transform.Translate(Vector2.left * Time.deltaTime * 0.5f);//1秒移动0.5
    }
}
