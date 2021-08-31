﻿using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidReader.Windows.Infrastructure.Services
{
    public class SnackbarService
    {
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        //public SnackbarMessageQueue MessageQueue { get; } = new SnackbarMessageQueue();

        public void ShowMessage(string messaage)
        {
            //MessageQueue.Enqueue(messaage);
            _logger.Info("[Message] " + messaage);
        }
    }
}