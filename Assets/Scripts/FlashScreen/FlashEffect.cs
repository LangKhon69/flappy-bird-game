using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashEffect : MonoBehaviour
{
    public static FlashEffect instance;
    private Image flashImage ;
    public float fadeSpeed = 2f;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()    
    {
      flashImage = GetComponent<Image>(); // Tự dộng tìm tấm ảnh đang gắn script này.
    }
    // Update is called once per frame
    void Update()
    {
        if(flashImage.color.a > 0f)
        {
            Color currentColor = flashImage.color;
            currentColor.a -= fadeSpeed * Time.unscaledDeltaTime;
            flashImage.color = currentColor;
        }
    }
    public void TriggerFlash()
    {
        Color currentColor = flashImage.color;
        currentColor.a = 1f; //Tăng độ hiển thị 100%.
        flashImage.color = currentColor;
    }
}
