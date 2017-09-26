using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace z.WPF.Dialogs
{

    /// <summary>
    /// Interaction logic for MessageDialog.xaml
    /// </summary>
    public partial class MessageDialog : UserControl
    {

        private Window _Window;

        public MessageDialog(string Message, string Title)
        {
            InitializeComponent();
            ViewModel.Caption = Title;
            ViewModel.Message = Message;
        }

        public static void MessageBox(string Message, string Title)
        {
            Application.Current.Dispatcher.Invoke((Action)(() => {
                new MessageDialog(Message, Title).Show();
            }));
        }

        public static void MessageBox(string Message) => MessageBox(Message, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);

        public void Show()
        {
            ViewModel.Show();
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
