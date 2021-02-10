using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using MVVM.ViewModel.Base;
using System.Windows.Input;
using MVVM.Infrastructure.Commands;
using System.Windows;

namespace MVVM.ViewModel
{
    internal class MainWindowViewModel : Base.ViewModel
    {
        private string _Title = "Анализ статистики COVID-19";
        #region Заголовок окна

        /// <summary>
        /// Заголовок окна?
        /// </summary>
        public string Title
        {
            get => _Title;
            //set
            //{
            //    if (Equals(_Title, value)) return;
            //    _Title = value;
            //    OnPropertyChanged();

            //    Set(ref _Title, value);
            //}
            set => Set(ref _Title, value);
        }

        #endregion
        #region Cтатус программы
        private string _Status = "Готово!";
        //свойство сет
        public string Status { get => _Status; set => Set(ref _Status, value); }
        #endregion


        #region Команды

        #region CloseApplicationCommand

        public ICommand CloseApplicationCommand { get;  }

        private void OnCloseApplicationCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }

        private bool CanCloseApplicationCommandExecute(object p) => true;

        #endregion
        #endregion

        public MainWindowViewModel()
        {
            #region Команды

            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);

            #endregion
        }
    }
}
