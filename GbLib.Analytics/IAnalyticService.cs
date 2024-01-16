namespace GbLib.Analytics
{
    public interface IAnalyticService
    {
        IAnalyticService SetTitle(string title);

        IAnalyticService SetActionKey(string actionKey);

        IAnalyticService SetClientType(string clientType);

        IAnalyticService SetActionTime(DateTime actionTime);

        IAnalyticService SetMessage(string message);

        IAnalyticService SetData(AnalyticData data);
        IAnalyticService SetOptions(AnalyticsOptions analyticsOptions);

        Task<bool> SendAsync(AnalyticData analyticData);

        Task<bool> SendAsync();
    }
}