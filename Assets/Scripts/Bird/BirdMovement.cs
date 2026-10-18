using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

using UnityEngine.UI;

public class BirdMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    public float jumpForce;
    private bool levelStart; //Biến làm con chim đừng yên kho bắt đầu game , chỉ hoạt động khi người chơi nhấn nút

    //Rotation Settings :

    private bool isDead = false;  // Biến kiểm tra con chim chết chưa


    void Start()
    {
        rigidBody = this.gameObject.GetComponent<Rigidbody2D>();
        //B1: Kiểm tra Rigidbody2D có được gán không :
        if (rigidBody != null)
        {
            //Debug.Log("Đã tìm thấy RigidBody2D");
        }
        levelStart = false; 
        rigidBody.gravityScale = 0; //Làm cho con chim không rơi xuống
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead) return;//Nếu con chim chết thì không cho chạy code nhảy và code xoay bên dưới nữa 

        //B2 : Kiểm tra & truyền phím nhận dữ liệu vào -> Ng dùng có nhấn phím Space từ bán phím không :
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (levelStart == false)
            {
                levelStart = true;
                PipeGenerate.generate.enablePipeGenerate = true;

                rigidBody.gravityScale = 4;// Con chim sẽ nhận chịu tác dụng lại bởi trọng lực lại và rơi xuống

            }
            //Debug.Log("Key Pressed");

            BirdMoveUp();  
        }
        RotateBird();
    }

    void RotateBird()
    {
        // -2.5f chính là NGƯỠNG RƠI (Hang Time). 
        // Vận tốc y > -2.5f nghĩa là đang bay lên HOẶC mới bắt đầu rơi nhẹ.
        if (rigidBody.velocity.y > -5f)
        {
            // GIỮ NGUYÊN đầu ngóc lên 25 độ
            transform.rotation = Quaternion.Euler(0, 0, 20f);
        }
        else
        {
            // KHI ĐÃ RƠI NHANH (Vận tốc âm hơn -5f), bắt đầu cắm đầu

            // Lấy góc hiện tại của con chim.
            // (Unity lưu góc âm -90 độ thành 270 độ, nên ta phải chuyển đổi lại để tính toán)
            float currentAngle = transform.localEulerAngles.z;// Cho biết góc xoay hiện tại của con chim là bao nhiêu.
            if (currentAngle > 180)
            {
                currentAngle -= 360;
            }

            // Dùng Lerp để xoay dần từ góc hiện tại xuống -90 độ.
            // Số 10f là tốc độ cắm đầu (càng lớn cắm càng nhanh)
            float newAngle = Mathf.Lerp(currentAngle, -90f, Time.deltaTime * 5f);

            // Gán góc mới
            transform.rotation = Quaternion.Euler(0, 0, newAngle);
        }
    }
    public void BirdMoveUp()
    {
        //B3 : Hàm làm cho chim "Bay" : Vector2.up =  Vector2(0,1)
        rigidBody.velocity = Vector2.up * jumpForce;
        //Âm thanh chim vỗ cánh:
        SoundController.instance.PlayThisSound("wing", 0.5f);
    }

    //Hàm logic cho chim "thua" :
    public void OnCollisionEnter2D(Collision2D collision)
    {
        //Phát Combo : Tiếng va chạm trước -> tiếng thua sau 
       

        if (collision.gameObject.CompareTag("Ground"))
        {
            if (!isDead)
            {
                isDead = true;
                FlashEffect.instance.TriggerFlash();
                SoundController.instance.PlayThisSound("hit", 0.5f);
                rigidBody.gravityScale = 1.5f;
                GameManager.manager.HitGround();
            }
            

        }
        else if (collision.gameObject.CompareTag("Pipe"))
        {
            if (!isDead)
            {
                isDead = true;
                FlashEffect.instance.TriggerFlash();
                SoundController.instance.PlayThisSound("hit", 0.5f);
                rigidBody.gravityScale = 2f;

                SoundController.instance.PlayThisSound("die", 1f);
                GameManager.manager.HitPipe();
                
                // 1. Lấy cơ thể vật lý của con chim để ta yểm bùa lên nó.
                Collider2D birdCollider = GetComponent<Collider2D>();

                // 2. Tìm TẤT CẢ các ống nước đang có trên màn hình:
                //Tạo 1 mảng danh sách kiểu GameObject -> Tìm tất cả các ống xuất hiện trong Map hiện trên màn hình
                GameObject[] pipes = GameObject.FindGameObjectsWithTag("Pipe");

                // 3. Ra lệnh: Chim sẽ phớt lờ va chạm với tất cả các ống này
           
                foreach (GameObject pipe in pipes)
                    //Nv tôi sẽ đi tới từng ống nước 1 có trong danh sách và làm việc với nó.
                {
                    //Lấy collider2d( cơ thể vật lý ) của các ống và chuẩn bị cho câu lệnh :
                    Collider2D pipeCollider = pipe.GetComponent<Collider2D>();
                    
                    //Kiểm tra các ống có cơ thể vật lý không :
                    if (pipeCollider != null)
                    {
                        Physics2D.IgnoreCollision(birdCollider, pipeCollider);
                    }
                }
            }  
        }
    }
    //Hàm cộng điểm cho Game :
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Score"))
        {
            //Truy cập hàm cộng điểm :
            GameManager.manager.addScore();

            //Âm thanh cộng điểm :
            SoundController.instance.PlayThisSound("point", 0.5f);
        }
    }
}
