using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProgressBar.Command;
using ProgressBar.ViewModel;
using ProgressBar.Views;
using ProgressBar.Views.Base;

namespace ProgressBar.ViewModel
{
    public class ProcessWindowViewModel : ViewModelBase
    {
        public ProcessWindowViewModel()
        {
            ProgressBarWindow progressBar = new ProgressBarWindow();

            Task.Run(async () =>
            {
                await Task.Run(() =>
                {
                    progressBar.Show();
                });
            });

            progressBar.Close();
        }
    }
}
