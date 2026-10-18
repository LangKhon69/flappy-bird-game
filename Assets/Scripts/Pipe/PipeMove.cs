using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PipeMove : MonoBehaviour
{
    public static PipeMove instance;
    public float speedMove;
    void Update()
    {
        //Câu lệnh dừng hành động : 
        if (GameManager.manager.isGameOver) return;

        Move();

        //Xóa Pipe sau khi vượt quá màn hình game:
         if(transform.position.x < -1f)
        {
            deletePipe();
        } 
    }
    // Làm cho cột di chuyển sang trái : 
    public void Move()
    {
        //Vector3 : x, y, z.
        //Ý nghĩa: Lấy vị trí hiện tại của GameObject Tính toán (cộng) với đơn vị trục x ( từ phải sang trái )
        // Cách viết khác :  transform.position += new Vector3(-1, 0 , 0);
        //-> Trục x hiện tại sẽ bị trừ đi 1 đơn vị 
        transform.position = transform.position + (Vector3.left * speedMove) * Time.deltaTime;
        // Hoặc : transform.position = transform.position + Vector3.Left * speedMove;
    }
    void deletePipe()
    {
        Destroy(gameObject);
    }
}
