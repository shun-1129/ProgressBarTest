using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

using ProgressBar.Command;
using ProgressBar.ViewModel;
using ProgressBar.Views;
using ProgressBar.Views.Base;

namespace ProgressBar.ViewModel
{
    public class ProgressBarWindowViewModel : ViewModelBase
    {
        private CancellationTokenSource _cancellationTokenSource;

        public Action CloseWindowAction { get; set; }

        private bool _isBusy;
        private int _prgValue;
        private string _message;

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                RaisePropertyChanged(nameof(IsBusy));
            }
        }

        public int PrgValue
        {
            get { return _prgValue; }
            set
            {
                if (_prgValue != value)
                {
                    _prgValue = value;
                    RaisePropertyChanged(nameof(PrgValue));
                }
            }
        }

        public ProgressBarWindowViewModel()
        {
            Task.Run(async () =>
            {
                await StartProcess();
            });
        }

        public async Task StartProcess()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            
            await ExecuteAsync();
        }

        private async Task ExecuteAsync()
        {
            await WorkTask();
        }

        private async Task WorkTask()
        {
            await Task.Run(() =>
            {
                for (PrgValue = 0; PrgValue < 100; PrgValue++)
                {
                    Thread.Sleep(100);
                }
            });

            IsBusy = true;
        }
    }
}
