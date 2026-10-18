using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
//File này có nhiệm vụ điều hướng logic tính điểm , kết thúc game :
public class GameManager : MonoBehaviour
{
    public static GameManager manager;

    public GameObject gameOverUI;//BIến hiển thị giao diện thua
    


    public TextMeshProUGUI scoreText; //Biến này tham chiếu đến Text ở GameObject Canvas
    public TextMeshProUGUI bestText;
    //Biến cộng điểm :
    private int currentScore = 0;
    private int highScore = 0;

    public GameObject button; //Biến nút bấm Reset

    public bool isGameOver = false;
    private bool gameStart = false;
    private void Awake()
    {
        manager = this;
    }
    void Start()
    {
        if (gameOverUI != null) gameOverUI.SetActive(false);
        

        //Load điểm kỷ lục từ máy lên 
        //"HighScore" là chìa khóa(Key) để tìm dữ liệu .
        // Số 0 là giá trị mặc định nếu chưa chơi bao giờ
        highScore = PlayerPrefs.GetInt("HighScore",0);

        //Cập nhật giao diện ban đầu :
        UpdateScore();
    }
     void Update()
    {
        //Hàm băt đầu Game :
        if(!gameStart && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
        {
            gameStart = true;
            SoundController.instance.PlayThisSound("swoosh",0.5f);
            UIFader.Instance.StartFadeOut();
        }
        //Cài đặt nút Esc để thoát :
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
        //Phím tắt Reset điểm kỷ lục Game :
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetBestScore();
        }
}

    //Hàm xử lý Thua :

    public void HitPipe()
    {
        isGameOver = true;
        if (gameOverUI != null) gameOverUI.SetActive(true);
        if (button != null) button.SetActive(true);
    }
    public void HitGround()
    {
        isGameOver = true;
        if(gameOverUI != null) gameOverUI.SetActive(true);
        if(button != null) button.SetActive(true);
    }
    //Hiển thị ra Text :
    public void UpdateScore()
    {
        scoreText.text = "Score\n " +currentScore.ToString();
        bestText.text = "Best\n " +highScore.ToString();
    }
    //Hàm tính điểm
    public void addScore()
    {
        if (isGameOver) return;
        currentScore++;
        //Kiểm tra phá kỉ lục :
        if (currentScore >= highScore)
        {
            highScore = currentScore;
            //Ghi đè kỉ lục mới vào máy ngay lập tức : 
            PlayerPrefs.SetInt("HighScore", highScore);
      
        }
        UpdateScore();

    }
    //Hàm load lại Scene khi thua :
    public void reloadScene()
    {
        SceneManager.LoadScene("_GamePlay");
    }

    public void QuitGame()
    {
        //IN ra dòng chữ test nút có hoạt động trong Unity không 
        Debug.Log("Đã thoát game thành công!!");
        //Thực thi lệnh đóng ứng dụng :
        Application.Quit();
    }
    public void ResetBestScore()
    {
        PlayerPrefs.DeleteAll();
    }
}
