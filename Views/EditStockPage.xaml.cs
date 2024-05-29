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
using Microsoft.Identity.Client;
using Supermarket.Models.Entities;
using Supermarket.ViewModels;

namespace Supermarket.Views
{
    /// <summary>
    /// Interaction logic for EditStockPage.xaml
    /// </summary>
    public partial class EditStockPage : Page
    {
        public EditStockPage()
        {
            InitializeComponent();
        }
        public EditStockPage(Stock stock) : this()
        {
            InitializeComponent();
            DataContext = new EditStockViewModel(stock);
        }
    }
}
