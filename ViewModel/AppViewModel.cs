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
//using static System.Net.Mime.MediaTypeNames;
using System.Windows;
using System.Collections.ObjectModel;

namespace WpfApp18.ViewModel
{
    class AppViewModel : ViewModelBase
    {
        private string fileName = @"C:\Users\Илья\source\repos\WpfApp18\bin\Debug\Текстовый документ.txt";
        private ObservableCollection<string> listResult = new ObservableCollection<string>();
        int count = 1;
        public string FileName {
            get { return fileName; }
            set { Set(ref fileName, value); }
        }

        private string result= "Result:";
        public string Result
        {
            get { return result; }
            set { Set(ref result, value); }
        }
        
        public ObservableCollection<string> ListResult
        {
            get { return listResult; }
            set { Set(ref listResult, value); }
        }
        public AppViewModel()
        {
                Thread t = new Thread(countword);
        }
        public Thread MyProperty { get; set; }
        private RelayCommand startCommand;
        public RelayCommand StartCommand{
            get => startCommand ?? (startCommand = new RelayCommand(() => {
                ThreadPool.QueueUserWorkItem(countword, FileName);
                Task.Run(() => countword(FileName) );
                Thread t = new Thread(countword);
                t.SetApartmentState(ApartmentState.STA);
                t.Start(FileName);
            }));
        }
        void countword(object data)
        {
            var path = data as string;
            var text = File.ReadAllText(path);
            var worldls = text.Split(' ');
            //MessageBox.Show(worldls.Length.ToString());
            Result = "Result:"+count++ +") "+ worldls.Length.ToString();
            Application.Current.Dispatcher.Invoke(()=>ListResult.Add(count++ +")"+worldls.Length.ToString()));
        }
    }
}
