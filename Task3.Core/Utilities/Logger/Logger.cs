﻿using log4net;
namespace Task3.Core.Utilities.Logger
{
	public class Logger
	{
        private readonly ILog log;
        internal Logger(Type type)
        {
            this.log = LogManager.GetLogger(type);
        }
        public void Info(string message)
        {
            this.log.Info(message);
        }

        public void Debug(string message)
        {
            this.log.Debug(message);
        }

        public void Error(string message)
        {
            this.log.Error(message);
        }
    }
}

