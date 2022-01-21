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
using WhatsUpp.ViewModel;

namespace WhatsUpp.View
{
	/// <summary>
	/// Interaction logic for ChatUC.xaml
	/// </summary>
	public partial class ChatUC : UserControl
	{
		public ChatUC()
		{
			InitializeComponent();
			this.DataContext = new ChatUCViewModel(this);
		}
		private void ChatListBox_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effects = DragDropEffects.Copy;
		}

		private void ChatListBox_Drop(object sender, DragEventArgs e)
		{
			string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
			foreach (string file in files)
				ChatListBox.Items.Add(file);
		}
	}
}
