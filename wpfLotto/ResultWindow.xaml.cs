using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace wpfLotto
{
    /// <summary>
    /// ResultWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ResultWindow : Window
    {
        public ResultWindow()
        {
            InitializeComponent();
            BtnChoose();
        }

        int[] lot = new int[7];

        int RandomNumber = 0;

        Random rnd = new Random();

        MainWindow mw = null;

        // 당첨 번호 비교 및 텍스트박스 뿌리기
        public void SendData(string [] data)
        {
            int dataNum = 0;

            for (int j = 1; j <= 5; j++)
            {
                int result = 0;

                int bonus = 0;

                for (int i = 0; i <= 5; i++)
                {
                    string tbName = "tb_" + j + '_' + i;


                    this.FindByName<TextBox>(tbName).Text = data[dataNum];

                    int winCheck = 0;

                    while (winCheck <= 5)
                    {
                        string winTbName = "tb_" + 0 + '_' + winCheck;

                        if (this.FindByName<TextBox>(tbName).Text == this.FindByName<TextBox>(winTbName).Text)
                        {
                            this.FindByName<TextBox>(tbName).Foreground = this.FindByName<TextBox>(winTbName).Foreground;
                            this.FindByName<TextBox>(tbName).Background = this.FindByName<TextBox>(winTbName).Background;

                            result++;
                        }
                        winCheck++;
                    }
                    if (this.FindByName<TextBox>(tbName).Text == tb_0_6.Text)
                    {
                        this.FindByName<TextBox>(tbName).Foreground = tb_0_6.Foreground;//Brushes.Blue;
                        this.FindByName<TextBox>(tbName).Background = tb_0_6.Background;//Brushes.LightSkyBlu
                        bonus++;
                    }
                    dataNum++;
                }

                string resultStr = "tb_" + j + '_' + 6;

                if (result < 3)

                {
                    this.FindByName<TextBox>(resultStr).Text = "꽝";
                }
                else if (result == 3)
                {
                    this.FindByName<TextBox>(resultStr).Text = "5등";
                    this.FindByName<TextBox>(resultStr).Foreground = Brushes.Red;
                    this.FindByName<TextBox>(resultStr).Background = Brushes.LightYellow;
                }
                else if (result == 4)
                {
                    this.FindByName<TextBox>(resultStr).Text = "4등";
                    this.FindByName<TextBox>(resultStr).Foreground = Brushes.Red;
                    this.FindByName<TextBox>(resultStr).Background = Brushes.LightYellow;
                }
                else if (result == 5 && (bonus == 0))
                {
                    this.FindByName<TextBox>(resultStr).Text = "3등";
                    this.FindByName<TextBox>(resultStr).Foreground = Brushes.Red;
                    this.FindByName<TextBox>(resultStr).Background = Brushes.LightYellow;
                }
                else if ((result == 5) && (bonus == 1))
                {
                    this.FindByName<TextBox>(resultStr).Text = "2등";
                    this.FindByName<TextBox>(resultStr).Foreground = Brushes.Red;
                    this.FindByName<TextBox>(resultStr).Background = Brushes.LightYellow;
                }
                else if (result == 6)
                {
                    this.FindByName<TextBox>(resultStr).Text = "1등";
                    this.FindByName<TextBox>(resultStr).Foreground = Brushes.Red;
                    this.FindByName<TextBox>(resultStr).Background = Brushes.LightYellow;
                }
                else
                {
                    this.FindByName<TextBox>(resultStr).Text = "오류";//"?";
                }
            }
        }

        private bool Numbers(int Num)
        {
            bool selection = false;
            for (int i = 0; i < lot.Length; i++)
            {
                if (lot[i] == Num)
                {
                    selection = true;
                    break;
                }
            }
            return selection;
        }

        // 추첨 번호 - 랜덤숫자 텍스트박스 삽입
        private int BtnChoose()
        {
            int i = 0;
            while (i != 7)
            {
                RandomNumber = rnd.Next(1, 46);
                if (!Numbers(RandomNumber))
                {
                    lot[i] = RandomNumber;
                    i++;
                }
            }
            Array.Sort(lot);

            mw = new MainWindow();

            //string[] ex = new string[7] { "1", "2", "3", "4", "5", "6", "7" };

            for (int j = 0; j < lot.Length; j++)
            {
                string jj = "tb_" + 0 + '_' + j;

                this.FindByName<TextBox>(jj).Text = lot[j].ToString();

            }
            return 0;
        }


        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            //if (MessageBox.Show("종료하시겠습니까", "EXIT", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            //{
                this.Close();
            //}
        }

    }
}
