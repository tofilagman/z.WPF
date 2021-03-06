﻿// -----------------------------------------------------------------------
// <copyright file="RelayCommand.cs" company="">
//
// The MIT License (MIT)
// 
// Copyright (c) 2012 Christoph Gattnar
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated
// documentation files (the "Software"), to deal in the Software without restriction, including without limitation the
// rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of
// the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING
// BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY
// CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
// ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
//
// </copyright>
// -----------------------------------------------------------------------

namespace z.WPF.Dialogs.Framework
{
	using System;
	using System.Windows.Input;

	internal class RelayCommand : ICommand
	{
		private readonly Action<object> _Execute;
		private readonly Func<object, bool> _CanExecute;

		public RelayCommand(Action<object> execute)
			: this(execute, null)
		{

		}

		public RelayCommand(Action<object> execute, Func<object, bool> canExecute)
		{
			if(execute == null)
			{
				throw new ArgumentNullException("execute", "Execute cannot be null.");
			}

			_Execute = execute;
			_CanExecute = canExecute;
		}

		public event EventHandler CanExecuteChanged
		{
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}

		public void Execute(object parameter)
		{
			_Execute(parameter);
		}

		public bool CanExecute(object parameter)
		{
			if(_CanExecute == null)
			{
				return true;
			}

			return _CanExecute(parameter);
		}
	}

}
