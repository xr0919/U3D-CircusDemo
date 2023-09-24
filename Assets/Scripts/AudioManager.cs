using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //1.��������
    public static AudioManager Instance;//����һ����̬���ͣ�������������ã�����д��һ��������ģʽ

    private AudioSource player;//�õ����������
    //������Ƶ�Ͻ���u3d��ʱ����audio clip����
    public AudioClip jump;
    public AudioClip die;
    public AudioClip die2;

    // Start is called before the first frame update
    void Start()
    {
        //2.��ȡ���
        Instance = this;
        player = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayJump()
    {
        player.PlayOneShot(jump);//������Ч
    }
    public void PlayDie()
    {
        //ֹͣ��������
        player.Stop();
        player.PlayOneShot(die);//������Ч
        //1s֮�����PlayDie2����
        Invoke("PlayDie2", 1f);

    }
    public void PlayDie2()
    {
        player.PlayOneShot(die2);//������Ч
    }
}
