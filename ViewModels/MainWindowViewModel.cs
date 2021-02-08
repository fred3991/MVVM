using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using MVVM.ViewModel.Base;


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

    }
}
