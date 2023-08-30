using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProgressBar;
using ProgressBar.Views;
using ProgressBar.Views.Base;
using ProgressBar.ViewModel;
using ProgressBar.Command;
using System.Windows.Input;

namespace ProgressBar.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        public DelegateCommand ButtonCommand { get; }
        public DelegateCommand ProcessWindowCommand { get; }
        
        private bool _flag = true;
        public bool Flag
        {
            get { return _flag; }
            set
            {
                _flag = value;

                // コマンド実行可否の変更通知メソッド
                ButtonCommand.DelegateCanExecute();
            }
        }

        #region コンストラクタ
        public MainWindowViewModel()
        {
            // DelegateCommandのインスタンス化
            //ButtonCommand = new DelegateCommand(async () =>
            //{
            //    Flag = false;            // フラグの更新（false：ボタンクリック不可）
            //    await Task.Delay(5000);  // 5秒間待機
            //    Flag = true;             // フラグの更新（true：ボタンクリック可）

            //}, canExcuteCommand);

            ProcessWindowCommand = new DelegateCommand(() =>
            {
                OpneProcessWindow();
            }, canExcuteCommand);

        }
        #endregion

        private void OpneProcessWindow()
        {
            ProcessWindow process = new ProcessWindow();
            process.Show();
        }

        private bool canExcuteCommand()
        {
            return Flag;
        }
    }
}
