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
using System.Windows.Shapes;
using WhatsUpp.ViewModel;

namespace WhatsUpp.View
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			this.DataContext = new MainViewModel(this);
		}

		private void Listbox_Drop(object sender, DragEventArgs e)
		{

		}

		private void Listbox_MouseDown(object sender, MouseButtonEventArgs e)
		{

		}

		private void Listbox_DragEnter(object sender, DragEventArgs e)
		{

		}

		private void Listbox_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{

		}
	}
}
