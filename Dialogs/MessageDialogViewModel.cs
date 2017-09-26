using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using z.WPF.Dialogs.Framework;

namespace z.WPF.Dialogs
{
    public class MessageDialogViewModel : Observable
    {
        private string _Message;

        #region Events

        public event EventHandler<OpenDialogEventArgs> ShowOpenDialogEventHandler;
        public event EventHandler<OpenDialogEventArgs> CloseOpenDialogEventHandler;

        #endregion

        public MessageDialogViewModel()
        {

        }

        private void Close()
        {
            if (CloseOpenDialogEventHandler != null)
            {
                CloseOpenDialogEventHandler(this, new OpenDialogEventArgs());
            }
        }

        public System.Windows.Window Owner
        {
            get;
            set;
        }

        public string Caption
        {
            get;
            set;
        }

        public bool? Result
        {
            get;
            set;
        }
        public string Message
        {
            get
            {
                return _Message;
            }
            set
            {
                _Message = value;
                NotifyChanged();
            }
        }

        public bool? Show()
        {
            if (ShowOpenDialogEventHandler != null)
            {
                ShowOpenDialogEventHandler(this, new OpenDialogEventArgs() { Caption = Caption, StartupLocation = System.Windows.WindowStartupLocation.CenterOwner, Owner = Owner });
            }
            return Result;
        }

        public ICommand OK
        {
            get
            {
                return new z.WPF.RelayCommand(() => Close());
            }
        }
         
    }
}
