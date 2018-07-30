﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using TourToto.Service;

namespace TourToto
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private TotoConfig Config { get; set; } = new TotoConfig("Default");
        public string HomeButton => "Thuisknopje";

        private Visibility visibilityAdmin = Visibility.Hidden;
        private Visibility visibilityLoggedIn = Visibility.Hidden;
        private Visibility visibilityLoginRegister = Visibility.Visible;

        public MainWindow()
        {
            PageManager.MainWindow = this;
            InitializeComponent();
        }

        public void WindowLoaded(object sender, RoutedEventArgs e)
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Visibility VisibilityAdmin
        {
            get => visibilityAdmin;

            set
            {
                visibilityAdmin = value;
                OnPropertyChanged();
            }
        }

        public Visibility VisibilityLoggedIn
        {
            get => visibilityLoggedIn;

            set
            {
                visibilityLoggedIn = value;
                OnPropertyChanged();
            }
        }

        public Visibility VisibilityLoginRegister
        {
            get => visibilityLoginRegister;

            set
            {
                visibilityLoggedIn = value;
                OnPropertyChanged();
            }
        }
    }
}