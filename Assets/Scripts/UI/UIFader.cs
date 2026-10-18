using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFader : MonoBehaviour
{
    public static UIFader Instance;
    private SpriteRenderer spriteUI;
    public float fadespeed = 2f;
    private bool isFading = false;
    void Start()
    {

        Instance = this;
        spriteUI = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFading)
        {
            //Trừ dần alpha theo thời gian thực :
            Color currentColor = spriteUI.color;
            currentColor.a -= fadespeed * Time.deltaTime;
            spriteUI.color = currentColor;

            if (spriteUI.color.a <= 0) 
            {
                //Tắt luôn GameObject này đi cho đỡ tốn tài nguyên máy tính .
                gameObject.SetActive(false);
            }
        }
    }
        public void StartFadeOut()
        {
            isFading = true;
        }
}
