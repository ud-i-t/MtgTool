﻿using MTGTool.Model;
using MTGTool.Model.Actors;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MTGTool
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            Repository.Set(typeof(ActorList), new ActorList());
            Repository.Set(typeof(MessageList), new MessageList());
            Repository.Set(typeof(SelectedMessage), new SelectedMessage());

            InitializeComponent();
        }
    }
}
