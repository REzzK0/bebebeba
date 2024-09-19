using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace wpf_1135_EF_sample
{
    /// <summary>
    /// Логика взаимодействия для YellowPressWindow.xaml
    /// </summary>
    public partial class YellowPressWindow : Window, INotifyPropertyChanged
    {
        private List<Singer> singers;

        public List<Singer> Singers
        {
            get => singers;
            set
            {
                singers = value;
                Signal();
            }
        }

        public Singer SelectedSinger { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public YellowPressWindow()
        {
            InitializeComponent();
            DataContext=this;
            using (var db = new _1135New2024Context())
            {
                Singers = db.Singers.

                    Include(s => s.YellowPresses).
                    ToList();
            }
        }

        private void UpdateList()
        {
            using (var db = new _1135New2024Context())
            {
                Singers = db.Singers.

                    Include(s => s.YellowPresses).
                    ToList();
            }
        }

        void Signal([CallerMemberName] string prop = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));


    }
}
