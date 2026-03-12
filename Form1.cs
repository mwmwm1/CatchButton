namespace CatchButton
{
    public partial class Form1 : Form
    {
        Random rand = new Random();//랜덤 변수 생성
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_MouseEnter(object sender, EventArgs e)//마우스가 버튼 위로 이동하면 버튼의 위치를 랜덤으로 변경
        {
            int x = rand.Next(0, this.ClientSize.Width - RunningButton.Width);//랜덤으로 X좌표 생성, 버튼이 폼밖으로 나가지 않도록 설정
            int y = rand.Next(0, this.ClientSize.Height - RunningButton.Height);//랜덤으로 Y좌표 생성, 버튼이 폼밖으로 나가지 않도록 설정

            RunningButton.Location = new Point(x, y);//버튼 위치 변경
            this.Text = $"버튼 위치 - X: {x}, Y: {y}";//폼 제목을 버튼의 위치로 업데이트
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
