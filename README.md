# 🐦 Flappy Bird - Unity

Game Flappy Bird 2D được xây dựng bằng **Unity** và **C#**, tái hiện lối chơi kinh điển: điều khiển chú chim bay qua các cặp ống và ghi điểm cao nhất có thể.


▶️ **[Chơi thử ngay trên trình duyệt]

## ✨ Tính năng

- Chim bay lên khi bấm phím Space / click chuột, rơi theo trọng lực
- Ống sinh ngẫu nhiên theo thời gian, độ cao khe hở thay đổi
- Phát hiện va chạm với ống và mặt đất → Game Over
- Hệ thống tính điểm khi bay qua mỗi cặp ống
- Lưu điểm cao nhất (High Score)
- Màn hình Game Over và nút chơi lại

## 🛠 Công nghệ sử dụng

| Thành phần | Chi tiết |
|---|---|
| Engine | Unity 2022.3.62f1 |
| Ngôn ngữ | C# |
| IDE | Visual Studio / VS Code |
| Quản lý mã nguồn | Git, GitHub |

## 🎮 Cách chơi

| Thao tác | Phím |
|---|---|
| Vỗ cánh bay lên | `Space` hoặc click chuột trái |
| Chơi lại | Bấm nút **Restart** |

## 🚀 Cách mở dự án trên máy

1. Cài **Unity Hub** và phiên bản Unity **2022.3.62f1** (xem trong file `ProjectSettings/ProjectVersion.txt`).
2. Tải dự án về máy:
   ```bash
   git clone https://github.com/TEN_BAN/flappy-bird-game.git
   ```
3. Mở Unity Hub → **Add → Add project from disk** → chọn thư mục vừa clone.
4. Lần mở đầu Unity sẽ tự tạo lại thư mục `Library` nên sẽ hơi lâu, đó là bình thường.
5. Mở scene `Assets/Scenes/NOI_DUNG_SCENE_CHINH.unity` và bấm nút **Play**.

## 📁 Cấu trúc thư mục

```
Assets/
├── Scenes/      # Các màn chơi
├── Scripts/     # Mã C# (điều khiển chim, sinh ống, tính điểm...)
├── Sprites/     # Hình ảnh
└── Audio/       # Âm thanh
```

## 📚 Điều mình học được

- Dùng **Rigidbody2D** và **Collider2D** để mô phỏng vật lý và va chạm
- Sinh và hủy đối tượng liên tục (Instantiate / Destroy) để game chạy mượt
- Tổ chức code thành các script nhỏ, mỗi script làm một việc
- Dùng Git để quản lý phiên bản và đưa dự án lên GitHub

## 🔮 Hướng phát triển

- [ ] Thêm menu chính và cài đặt âm lượng
- [ ] Thêm nhiều nhân vật / nền khác nhau
- [ ] Tăng độ khó theo điểm số

## 👤 Tác giả

**TÊN_CỦA_BẠN**
- GitHub: https://github.com/LangKhon69
- Email: lekhangls101@gmail.com

## 📄 Giấy phép

Phát hành theo giấy phép [MIT](LICENSE).
