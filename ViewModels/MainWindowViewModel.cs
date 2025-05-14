using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Timers;

namespace MSS_Data_Server.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        /* Переменные для биндинга к MainWindow.axaml ------------------------------------------------------------------------*/
        [ObservableProperty] private string _Greeting = "Welcome to Avalonia!";
        [ObservableProperty] private bool _Drilling = false;
        [ObservableProperty] string _TimerText = "";
		/*---------------------------------------------------------------------------------------------------------------------*/

		private static System.Timers.Timer? aTimer;
		private readonly int aTimerInterval = 1000;
		
		/* Выход из программы */
		public void ExitApp() {
            
        
        }

		/* Запуск регистрации */
        public void HandleDrillingRunStopClick() {
            Drilling = !Drilling;
			if (Drilling)
			{
				SetTimer();
			}
			else 
			{
				TimerText = "";
				if (aTimer != null)
				{
					aTimer.Stop();
					aTimer.Dispose();
				}
			}
        }

		/* Запуск таймера */
		private void SetTimer()
		{
			// Создание объекта Timer с заданным интервалом
			aTimer = new System.Timers.Timer(aTimerInterval);
			// Подключение метода к срабатыванию таймера
			aTimer.Elapsed += OnTimedEvent;
			aTimer.AutoReset = true;
			aTimer.Enabled = true;
		}
		/* Обработка события срабатывания таймера */
		private void OnTimedEvent(Object source, ElapsedEventArgs e)
		{
			// Регистрация ---------------------
			// ?? запуск потока на чтение из ProxyServer
			TimerText = e.SignalTime.ToString();
			// ---------------------------------
		}
	}

    
}
