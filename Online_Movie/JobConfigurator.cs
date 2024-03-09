using BusinessLogic.Interfaces;
using Hangfire;

namespace Online_Movie
{
	public static class JobConfigurator
	{
		public static void AddJobs()
		{
			RemoveExpiredRefreshTokensJob();
		}
		public static void RemoveExpiredRefreshTokensJob()
		{
			RecurringJob.AddOrUpdate<IAccountsService>(
				nameof(RemoveExpiredRefreshTokensJob),
				service => service.RemoveExpiredRefreshTokens(),
				Cron.Weekly);
		}
	}
}
