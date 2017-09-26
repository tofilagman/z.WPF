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

namespace z.WPF.Dialogs
{
    /// <summary>
    /// Interaction logic for PromptDialog.xaml
    /// </summary>
    public partial class PromptDialog : UserControl
    {
        private Window _Window;

        public PromptDialog(string Message, string Title)
        {
            InitializeComponent();
            ViewModel.Caption = Title;
            ViewModel.Message = Message;
        }

        public static bool? PromptBox(string Message, string Title)
        {
            return new PromptDialog(Message, Title).Show();
        }

        public static bool? PromptBox(string Message) => PromptBox(Message, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);

        public bool? Show()
        {
            return ViewModel.Show();
        }

        private void OnShow(object sender, OpenDialogEventArgs e)
        {
            _Window = new Window();
            _Window.Content = this;
            _Window.SizeToContent = SizeToContent.WidthAndHeight;
            _Window.ResizeMode = ResizeMode.CanResizeWithGrip;
            _Window.WindowStyle = WindowStyle.ToolWindow;
            _Window.Title = e.Caption;
            _Window.ShowInTaskbar = false;
            _Window.Topmost = true;
            _Window.ResizeMode = ResizeMode.NoResize;
            _Window.Owner = e.Owner;
            _Window.WindowStartupLocation = e.StartupLocation;
            _Window.InputBindings.Add(new KeyBinding(ViewModel.OK, Key.Enter, ModifierKeys.None)); 
            _Window.ShowDialog();
        }

        private void OnClose(object sender, OpenDialogEventArgs e)
        {
            _Window.Close();
        }
    }
}
