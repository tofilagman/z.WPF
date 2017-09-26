using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace z.WPF.Dialogs
{
    public class PromptDialogViewModel : Observable
    {
        private string _Message;
        private string _PromptValue;
        
        #region Events

        public event EventHandler<OpenDialogEventArgs> ShowOpenDialogEventHandler;
        public event EventHandler<OpenDialogEventArgs> CloseOpenDialogEventHandler;

        #endregion
 
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
        } = false;

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

        public string PromptValue
        {
            get { return _PromptValue; }
            set { _PromptValue = value; NotifyChanged(); }
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
                Result = true;
                return new z.WPF.RelayCommand(() => Close());
            }
        }
         
        public ICommand Cancel
        {
            get
            {
                Result = false;
                return new z.WPF.RelayCommand(() => Close());
            }
        }

    }
}
