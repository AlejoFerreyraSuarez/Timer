using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.ServiceProcess;
using System.Timers;

namespace Timer_AlejoFerreyra
{
    public class ServicioIncrementoProgramado : ServiceBase
    {
        private Timer temporizador;
        private DateTime fechaHoraProgramada;
        private int intervaloMinutos;

        public ServicioIncrementoProgramado()
        {
            this.ServiceName = "ServicioIncrementoProgramado";
            this.CanStop = true;
            this.CanPauseAndContinue = true;
            this.AutoLog = true;
        }

        protected override void OnStart(string[] args)
        {
            CargarConfiguracion(); 
            TimeSpan tiempoHastaEjecucionProgramada = fechaHoraProgramada - DateTime.Now;
            if (tiempoHastaEjecucionProgramada.TotalMilliseconds < 0)
            {
                tiempoHastaEjecucionProgramada = tiempoHastaEjecucionProgramada.Add(TimeSpan.FromDays(1));
            }

            temporizador = new Timer();
            temporizador.Interval = tiempoHastaEjecucionProgramada.TotalMilliseconds;
            temporizador.Elapsed += new ElapsedEventHandler(EnTemporizador);
            temporizador.Start();
        }

        protected override void OnStop()
        {
            temporizador.Stop();
        }

        private void EnTemporizador(object sender, ElapsedEventArgs e)
        {
            temporizador.Interval = TimeSpan.FromDays(1).TotalMilliseconds;
        }

        private void CargarConfiguracion()
        {
        }
    }
}

