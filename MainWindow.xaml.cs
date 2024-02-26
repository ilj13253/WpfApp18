using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
using WpfApp18.ViewModel;
namespace WpfApp18
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext =new AppViewModel();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Thread t = new Thread(countword);
            t.IsBackground = true;
            t.Start(FileName);
        }
        void countword(object data)
        {
            var path = data as string;
            var text = File.ReadAllText(@"C:\Users\Илья\source\repos\WpfApp17\obj\Debug\Текстовый документ.txt");
            var worldls = text.Split(' ');
            //MessageBox.Show(worldls.Length.ToString());
            Dispatcher.Invoke(() => { Result.Content = "Result:" + worldls.Length.ToString(); });
        }
    }
}