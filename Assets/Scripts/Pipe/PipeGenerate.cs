using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGenerate : MonoBehaviour
{ 
    public static PipeGenerate generate;

    public GameObject pipeDuplicate;
    private float countDown;
    public float timeDuration;
    public bool enablePipeGenerate; //Biến này sẽ vô hiệu hóa tạo ống trước khi con chim bay 
    // Start is called before the first frame update
    // Ta sẽ tạo 1 biến countDown gán bằng biến timeDuration :
    // Mỗi khi biến countDown về 0 thì lập tức tạo ra ống và gán giá trị ban đầu của timeDuration cho nó 
    void Start()
    {
        generate = this;
        //Biến countDown sẽ được gán bằng giá trị của TimeDuration mỗi khi bắt đầu game
        countDown = timeDuration;
        enablePipeGenerate = false; //để mặc định false 
    }

    void Update()
    {
        //Câu lệnh dừng hành động
        if (GameManager.manager.isGameOver) return;
       
            if (enablePipeGenerate == true)
            {
                countDown -= Time.deltaTime; // Mỗi frame countDown -= 1/30 FPS
                                             // Time.deltaTime = 1/ (số FPS game đang chạy ) -> 1/30s 
                                             // Hàm Update này đã chạy được 30 lần , và biến countDown sẽ giảm mỗi 30 lần hàm Update chạy :
                                             // VD : countDown = 1 - 0.03 ,...... , 0.03 - 0.03 = 0 .

                if (countDown <= 0)
                {
                    Instantiate(pipeDuplicate, new Vector3(9.8f, Random.Range(9.8f, 13f), 0), Quaternion.identity);

                    //Kiểm tra xem Game cữ mỗi 2s là tạo ra ống không , nếu có gán lại giá trị timeDuration cho countDown.
                    //Debug.Log("Tao 1 ong !");
                    countDown = timeDuration;
                }
            }     
    }    
}
