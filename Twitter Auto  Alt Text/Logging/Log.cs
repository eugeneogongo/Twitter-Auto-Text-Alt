
using Microsoft.Extensions.Logging;

namespace FileUploadService.Logging
{
    public class Log
    {
		private static ILoggerFactory _Factory = null;

		public static void ConfigureLogger(ILoggerFactory factory)
		{

			_Factory = factory;
			
		}
		public static ILoggerFactory LoggerFactory
		{
			get
			{
				if (_Factory == null)
				{
					_Factory = new LoggerFactory();
					ConfigureLogger(_Factory);
				}
				return _Factory;
			}
			set { _Factory = value; }
		}
		public static ILogger CreateLogger(string Tag)
		{
			return LoggerFactory.CreateLogger(Tag);
		}

		public static void D(string message, string Tag = "Debug")
        {
			CreateLogger(Tag).LogDebug(message);
		}

		public static void I(string message, string Tag = "Info")
		{
			CreateLogger(Tag).LogInformation(message);
		}


		public static void E(string message, string Tag = "Error")
		{
			CreateLogger(Tag).LogError(message);
		}
	}
}
