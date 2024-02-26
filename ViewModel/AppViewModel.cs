using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace WpfApp18.ViewModel
{
    class AppViewModel : ViewModelBase
    {
        private string fileName = @"C:\Users\Илья\source\repos\WpfApp18\obj\Debug\Текстовый документ.txt";
        public string FileName {
            get { return fileName; }
            set { Set(ref fileName, value); }
        }
        private string result;
        public string Result
        {
            get { return result; }
            set { Set(ref result, value); }
        }
        private RelayCommand startCommand;
        public RelayCommand StartCommand{
            get => startCommand ?? (startCommand = new RelayCommand(() => { Thread t = new Thread(countword);t.Start(FileName); }));
        }
        void countword(object data)
        {
            var path = data as string;
            var text = File.ReadAllText(path);
            var worldls = text.Split(' ');
            //MessageBox.Show(worldls.Length.ToString());
            Result = "Result:" + worldls.Length.ToString();
        }
    }
}
