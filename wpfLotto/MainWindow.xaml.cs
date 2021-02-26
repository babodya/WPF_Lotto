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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections;

namespace wpfLotto
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Button 에 isCancel을 넣지 않았을 경우 ESC에 이벤트 값 주는것 - 1

            //this.PreviewKeyDown += new KeyEventHandler(HandleEsc);

        }

        ManualWindow mw = null;

        int[] lot = new int[6];

        int RandomNumber = 0;

        Random rnd = new Random();

        // ResultWindow로 보낼 텍스트 박스 값 담는 배열 변수
        string[] data = new string[30];

        // 어떤 버튼을 눌렀는지 알려주는 값
        int btnNum = 0;

        // 난수 생성
        private bool Numbers(int Num)
        {
            bool selection = false;
            for(int i = 0; i< lot.Length; i++)
            {
                if(lot[i] == Num)
                {
                    selection = true;
                    break;
                }
            }
            return selection;
        }

        // 랜덤숫자 텍스트박스 삽입
        private int BtnChoose(int Num)
        {
            int i = 0;
            while (i != 6)
            {
                RandomNumber = rnd.Next(1, 46);
                if (!Numbers(RandomNumber))
                {
                    lot[i] = RandomNumber;
                    i++;
                }
            }
            Array.Sort(lot);



            for (int j = 1; j <= lot.Length; j++)
            {

                string tbName = "tb_" + Num + '_' + j;


                this.FindByName<TextBox>(tbName).Text = lot[j - 1].ToString();

            }
            return 0;
        }
      
        // 수동 버튼 클릭
        private void btnManual_1_Click(object sender, RoutedEventArgs e)
        {
            btnNum = 1;
            mw = new ManualWindow();
            mw.OnChildTextInputEvent += new ManualWindow.OnChildTextHandeler(mw_OnChildTextInputEvent);
            mw.Show();
        }
        private void btnManual_2_Click(object sender, RoutedEventArgs e)
        {
            btnNum = 2;
            mw = new ManualWindow();
            mw.OnChildTextInputEvent += new ManualWindow.OnChildTextHandeler(mw_OnChildTextInputEvent);
            mw.Show();
        }
        private void btnManual_3_Click(object sender, RoutedEventArgs e)
        {
            btnNum = 3;
            mw = new ManualWindow();
            mw.OnChildTextInputEvent += new ManualWindow.OnChildTextHandeler(mw_OnChildTextInputEvent);
            mw.Show();
        }
        private void btnManual_4_Click(object sender, RoutedEventArgs e)
        {
            btnNum = 4;
            mw = new ManualWindow();
            mw.OnChildTextInputEvent += new ManualWindow.OnChildTextHandeler(mw_OnChildTextInputEvent);
            mw.Show();
        }
        private void btnManual_5_Click(object sender, RoutedEventArgs e)
        {
            btnNum = 5;
            mw = new ManualWindow();
            mw.OnChildTextInputEvent += new ManualWindow.OnChildTextHandeler(mw_OnChildTextInputEvent);
            mw.Show();
        }

        //수동 선택 창에서 데이터 받아서 텍스트 박스에 뿌리기
        private void mw_OnChildTextInputEvent(int[] Parameters)
        {
            for (int j = 1; j <= lot.Length; j++)
            {

                string tbName = "tb_" + btnNum + '_' + j;


                this.FindByName<TextBox>(tbName).Text = Parameters[j - 1].ToString();

            }

            if (mw != null)
            {
                mw.Close();
                mw.OnChildTextInputEvent -= new ManualWindow.OnChildTextHandeler(mw_OnChildTextInputEvent);
            }
        }

        // 자동 버튼 클릭
        private void btnAuto_1_Click(object sender, RoutedEventArgs e)
        {
            BtnChoose(1);
        }
        private void btnAuto_2_Click(object sender, RoutedEventArgs e)
        {
            BtnChoose(2);
        }
        private void btnAuto_3_Click(object sender, RoutedEventArgs e)
        {
            BtnChoose(3);
        }
        private void btnAuto_4_Click(object sender, RoutedEventArgs e)
        {
            BtnChoose(4);
        }
        private void btnAuto_5_Click(object sender, RoutedEventArgs e)
        {
            BtnChoose(5);
        }

        // 로또 추첨 버튼 클릭
        private void btnResult_Click(object sender, RoutedEventArgs e)
        {

            ResultWindow win2 = new ResultWindow();


            win2.Show();

            string tbName = "";

            int dataNum = 0;

            for (int j = 1; j <= 5; j++)
            {
                for (int i = 1; i <= 6; i++)
                {
                    tbName = "tb_" + j + '_' + i;


                    data[dataNum] = this.FindByName<TextBox>(tbName).Text;
                    dataNum++;
                }

            }

            win2.SendData(data);
        }

        // 컨트롤 지우기
        private int ctrlClear()
        {

            for (int k = 1; k<lot.Length; k++)
            {
                for (int j = 1; j <= lot.Length; j++)
                {

                    string tbName = "tb_" + k + '_' + j;


                    this.FindByName<TextBox>(tbName).Text = "";

                }
            }
            return 0;
        }

        // 다시하기 버튼
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            ctrlClear();
        }

        // Button 에 isCancel을 넣지 않았을 경우 ESC Esc 누를 경우 종료 메세지창 생성

        //private void HandleEsc(object sender, KeyEventArgs e)
        //{

        //    if (e.Key == Key.Escape)
        //    {
        //        if (MessageBox.Show("종료하시겠습니까", "EXIT", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
        //        {
        //            Close();
        //        }
        //    }
        //}

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            //if (MessageBox.Show("종료하시겠습니까", "EXIT", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            // {
            this.Close();
            //}
        }
    }

    // 컨트롤 배열 사용 클래스
    public static class FindControl
    {
        public static T FindByName<T>(this object obTarget, string strName) where T : class
        {
            System.Reflection.FieldInfo[] fis = obTarget.GetType().GetFields(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            System.Reflection.FieldInfo fi = null;

            for(int iIndex = 0; iIndex < fis.Length; iIndex ++)
            {
                if(fis[iIndex].Name.ToLower()==strName.ToLower())
                {
                    fi = fis[iIndex];
                    break;
                }
            }
            return fi.GetValue(obTarget) as T;
        }
        public static T FindByName<T>(this string strName, object obTarget) where T : class
        {
            System.Reflection.FieldInfo[] fis = obTarget.GetType().GetFields(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            System.Reflection.FieldInfo fi = null;

            for(int iIndex = 0; iIndex < fis.Length; iIndex ++)
            {
                if (fis[iIndex].Name.ToLower() == strName.ToLower())
                {
                    fi = fis[iIndex];
                    break;
                }
            }
            return fi.GetValue(obTarget) as T;
        }

    }
}
