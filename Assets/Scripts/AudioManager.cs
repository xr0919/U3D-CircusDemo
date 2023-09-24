using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //1.声明变量
    public static AudioManager Instance;//创建一个静态类型，方便其他类调用，所以写成一个单例的模式

    private AudioSource player;//拿到播放器组件
    //所有音频拖进来u3d的时候都是audio clip类型
    public AudioClip jump;
    public AudioClip die;
    public AudioClip die2;

    // Start is called before the first frame update
    void Start()
    {
        //2.获取组件
        Instance = this;
        player = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayJump()
    {
        player.PlayOneShot(jump);//播放音效
    }
    public void PlayDie()
    {
        //停止背景音乐
        player.Stop();
        player.PlayOneShot(die);//播放音效
        //1s之后调用PlayDie2函数
        Invoke("PlayDie2", 1f);

    }
    public void PlayDie2()
    {
        player.PlayOneShot(die2);//播放音效
    }
}
