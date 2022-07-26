﻿using System;
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

namespace DependencyPropertiesEjem1_V77
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Como implementar una propertie propia
        //Crear: Primero debemos tenet creada la dependency propertie, luego en nuestra propiedad, implementar en el setter y el getter 
        //esta dependencia
        public int MiProperty
        {
            get {return (int)GetValue(miDependencyProperty); }
            set { SetValue(miDependencyProperty, value); }
        }
        public static readonly DependencyProperty miDependencyProperty =
            DependencyProperty.Register("MiProperty", typeof(int), typeof(MainWindow), new PropertyMetadata(0));
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
