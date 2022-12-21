using System.Threading;
using WallPaperChanger_NameSpace;

namespace Service_Valorant_WallPaper_Changer
{
	public class Worker : BackgroundService
	{
		private readonly ILogger<Worker> _logger;

		public Worker(ILogger<Worker> logger)
		{
			_logger = logger;
		}

		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			WallPaperChanger wallPaper = new("WALLPAPER");
			Thread.Sleep(Timeout.Infinite);
			while (!stoppingToken.IsCancellationRequested)
			{
				_logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
				await Task.Delay(1000, stoppingToken);
			}
		}
	}
}