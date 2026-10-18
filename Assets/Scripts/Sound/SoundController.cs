using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script này có nhiệm vụ duy nhất là xử lý âm thanh :
public class SoundController : MonoBehaviour
{
    public static SoundController instance;
    private AudioSource audioSource;// Tạo 1 cái AudioSource duy nhất
    void Start()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();  
        if(audioSource == null)// Nếu không có thì thêm AudioSource vào :
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }
    public void PlayThisSound(string clipName, float volume)
    {
        //Câu lệnh truy tìm đường dẫn : gán tệp file âm thanh thông qua địng dạng văn bản 
        AudioClip clip = Resources.Load<AudioClip>("Sounds/" + clipName);
        if (clip != null)
        {
            audioSource.PlayOneShot(clip, volume);
        }
    }
}
