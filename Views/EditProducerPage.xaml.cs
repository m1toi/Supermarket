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
using Supermarket.Models.Entities;
using Supermarket.ViewModels;

namespace Supermarket.Views
{
    /// <summary>
    /// Interaction logic for EditProducerPage.xaml
    /// </summary>
    public partial class EditProducerPage : Page
    {
        public EditProducerPage()
        {
            InitializeComponent();
        }
        public EditProducerPage (Producer producer) : this()
        {
            InitializeComponent();
            DataContext = new EditProducerViewModel(producer);
        }
    }
}
