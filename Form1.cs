using System.Media;

namespace CatchButton
{
    public partial class Form1 : Form
    {
        Random rand = new Random();//랜덤 변수 생성
        private int score = 0; // 점수 변수
        public Form1()
        {
            InitializeComponent();
            this.Text = $"점수: {score}"; //제목에 점수 표시
        }

        private void button1_MouseEnter(object sender, EventArgs e)//마우스가 버튼 위로 이동하면 버튼의 위치를 랜덤으로 변경
        {
            int maxX = Math.Max(1, this.ClientSize.Width - RunningButton.Width);
            int maxY = Math.Max(1, this.ClientSize.Height - RunningButton.Height);
            int x = rand.Next(0, maxX);//랜덤으로 X좌표 생성, 버튼이 폼밖으로 나가지 않도록 설정
            int y = rand.Next(0, maxY);//랜덤으로 Y좌표 생성, 버튼이 폼밖으로 나가지 않도록 설정

            RunningButton.Location = new Point(x, y);//버튼 위치 변경
            score -= 10; // 버튼이 도망가면 -10점
            SystemSounds.Beep.Play();
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
    }
}
