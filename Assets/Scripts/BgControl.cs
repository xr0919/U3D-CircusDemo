using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgControl : MonoBehaviour
{
    private float offset = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //move(0.1f);

    }
    public void move(float dir)
    {
        //±³¾°ÒÆ¶¯
        if (dir > 0) //>0Ïò×ó±ßÒÆ¶¯
        {
            GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(offset += 0.3f * Time.deltaTime, 0));
        }
        else
        {
            GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(offset -= 0.3f * Time.deltaTime, 0));

        }
    }
}
