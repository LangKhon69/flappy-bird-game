using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopGround : MonoBehaviour
{
    public float speed;
    private SpriteRenderer sp;
    private Vector2 startSize;
    private float width = 18f;

    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        startSize = new Vector2(sp.size.x, sp.size.y);  
    }
    void Update()
    {
        //Nếu GameOver thì không làm j cả : Ngừng trôi sang trái .
        if (GameManager.manager.isGameOver) return;

        sp.size = new Vector2(sp.size.x + speed * Time.deltaTime, sp.size.y);
        if (sp.size.x > width)
        {
            sp.size = startSize;
        } 
        
    }
}
