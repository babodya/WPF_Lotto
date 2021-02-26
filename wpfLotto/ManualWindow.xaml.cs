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
    /// ManualWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ManualWindow : Window
    {
        public ManualWindow()
        {
            InitializeComponent();
        }

        // ManualWindow 에서 데이터 받아 오는 Delegate Event Handeler
        public delegate void OnChildTextHandeler(int[] Parameters);
        public event OnChildTextHandeler OnChildTextInputEvent;

        string selectOk = "";

        int count = 0;

        int[] send = new int[6];

        // 종료 버튼
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {

            //if (MessageBox.Show("종료하시겠습니까", "EXIT", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
           // {
                this.Close();
            //}
          
        }
        
        // 체크박스 체크시 체크 개수 검사 및 저장
         private int isChecked()
        {
            int chkCount = 0;

            string addNum = "";

            for (int j = 1; j <= 45; j++)
            {

                string tbName = "chb_" + j;

                if (this.FindByName<CheckBox>(tbName).IsChecked == true)
                {
                    send[chkCount] = j;
                    chkCount++;
                    addNum += j + Environment.NewLine;
                }
                
                if(chkCount > 5)
                {
                    allCheck();
                    MessageBox.Show("6개 모두 선택 완료 되었습니다." + Environment.NewLine + addNum);
                    selectOk = addNum;
                    count = chkCount;
                    return 0;
                }
            }
            return 0;
        }

        // 6개의 숫자 선택 시 모든 체크박스 선택 불가
        private int allCheck()
        {
            btnChooseOk.IsEnabled = true;

            for (int k = 1; k <= 45; k++)
            {
                string tbName = "chb_" + k;
                this.FindByName<CheckBox>(tbName).IsEnabled = false;
            }
            return 0;
        }

        // 모든 체크박스 체크 해제 및 선택가능
        private int allUnCheck()
        {
            selectOk = "";
            count = 0;

            btnChooseOk.IsEnabled = false;

            for (int k = 1; k <= 45; k++)
            {
                string tbName = "chb_" + k;
                this.FindByName<CheckBox>(tbName).IsEnabled = true;
                this.FindByName<CheckBox>(tbName).IsChecked = false;
            }
            return 0;
        }

        //체크박스 체크 시 이벤트
        private void chb_Click(object sender, EventArgs e)
        {
            CheckBox ckb = sender as CheckBox;
            //if (chb_1.IsChecked == true)
            //{
            //    MessageBox.Show("체크확인");
            //}
            isChecked();
        }

        // 다시 선택 버튼 이벤트
        private void btnReplay_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("다시 선택하시겠습니까?", "AGAIN", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                allUnCheck();
            }
        }

        // 선택 완료 버튼 이벤트
        private void btnChooseOk_Click(object sender, EventArgs e)
        {
            if (OnChildTextInputEvent != null)  {
                OnChildTextInputEvent(send);
                this.Close();
            }  
        }
    }

}
