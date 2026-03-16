using System.Media;

namespace CatchButton
{
    public partial class Form1 : Form
    {
        Random rand = new Random();//랜덤 변수 생성
        private int score = 0; // 점수 변수
        private int moveCount = 0; // 버튼이 움직인 횟수
        private const int MaxMoves = 20; // 최대 이동 횟수 (게임오버)
        private Size initialButtonSize;
        private Button RestartButton; // 런타임에 생성하는 재시작 버튼
        public Form1()
        {
            InitializeComponent();
            this.Text = $"점수: {score}"; //제목에 점수 표시
            initialButtonSize = RunningButton.Size;
            // Restart 버튼을 디자이너 수정 없이 런타임에 생성
            RestartButton = new Button();
            RestartButton.Location = new Point(12, 12);
            RestartButton.Name = "RestartButton";
            RestartButton.Size = new Size(100, 30);
            RestartButton.TabIndex = 1;
            RestartButton.Text = "다시시작";
            RestartButton.UseVisualStyleBackColor = true;
            RestartButton.Visible = false;
            RestartButton.Click += RestartButton_Click;
            this.Controls.Add(RestartButton);
        }

        private void button1_MouseEnter(object sender, EventArgs e)//마우스가 버튼 위로 이동하면 버튼의 위치를 랜덤으로 변경
        {
            if (!RunningButton.Enabled) return;

            int maxX = Math.Max(1, this.ClientSize.Width - RunningButton.Width);
            int maxY = Math.Max(1, this.ClientSize.Height - RunningButton.Height);
            int x = rand.Next(0, maxX);//랜덤으로 X좌표 생성, 버튼이 폼밖으로 나가지 않도록 설정
            int y = rand.Next(0, maxY);//랜덤으로 Y좌표 생성, 버튼이 폼밖으로 나가지 않도록 설정

            RunningButton.Location = new Point(x, y);//버튼 위치 변경
            moveCount++; // 이동 횟수 증가
            score -= 10; // 버튼이 도망가면 -10점
            SystemSounds.Beep.Play();

            // 게임오버 체크
            if (moveCount >= MaxMoves)
            {
                RunningButton.Enabled = false;
                RestartButton.Visible = true;
                SystemSounds.Hand.Play();
                MessageBox.Show("Game Over");
                this.Text = $"Game Over - 점수: {score}";
                return;
            }

            this.Text = $"점수: {score} - 버튼 위치 - X: {x}, Y: {y}";//폼 제목을 버튼의 위치와 점수로 업데이트
        }

        private void button1_Click(object sender, EventArgs e)
        {
            score += 100; // 버튼 클릭시 +100점
            SystemSounds.Asterisk.Play();
            MessageBox.Show("축하합니다~!");

            int minSize = 20;//최소 크기 제한
            int newWidth = Math.Max(minSize, (int)(RunningButton.Width * 0.9));
            int newHeight = Math.Max(minSize, (int)(RunningButton.Height * 0.9));
            RunningButton.Width = newWidth;
            RunningButton.Height = newHeight;

            this.Text = $"점수: {score}";
        }

        private void RestartButton_Click(object sender, EventArgs e)
        {
            // 게임 리셋
            score = 0;
            moveCount = 0;
            RunningButton.Enabled = true;
            RunningButton.Size = initialButtonSize;
            RestartButton.Visible = false;
            this.Text = $"점수: {score}";
        }
    }
}
