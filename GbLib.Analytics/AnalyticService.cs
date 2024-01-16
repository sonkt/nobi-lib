using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace GbLib.Analytics
{
    public class AnalyticService : IAnalyticService
    {
        private AnalyticData _data;
        private AnalyticsOptions _options;
        public AnalyticService(AnalyticsOptions analyticsOptions)
        {
            _options = analyticsOptions;
            _data = new AnalyticData();
        }
        public AnalyticService(AnalyticData analyticData)
        {
            _data = analyticData;
            _options = new AnalyticsOptions();
        }

        public AnalyticService(AnalyticData analyticData, AnalyticsOptions analyticsOptions)
        {
            _data = analyticData;
            _options = analyticsOptions;
        }
        public AnalyticService()
        {
            _data = new AnalyticData();
            _options = new AnalyticsOptions();
        }

        public IAnalyticService SetActionKey(string actionKey)
        {
            if (_data == null)
            {
                _data = new AnalyticData();
            }
            _data.ActionKey = actionKey;
            return this;
        }

        public IAnalyticService SetActionTime(DateTime actionTime)
        {
            if (_data == null)
            {
                _data = new AnalyticData();
            }
            _data.ActionTime = actionTime;
            return this;
        }

        public IAnalyticService SetClientType(string clientType)
        {
            if (_data == null)
            {
                _data = new AnalyticData();
            }
            _data.ClientType = clientType;
            return this;
        }

        public IAnalyticService SetMessage(string message)
        {
            if (_data == null)
            {
                _data = new AnalyticData();
            }
            _data.Message = message;
            return this;
        }

        public IAnalyticService SetTitle(string title)
        {
            if (_data == null)
            {
                _data = new AnalyticData();
            }
            _data.Title = title;
            return this;
        }
        public Task<bool> SendAsync()
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = httpClient.PostAsJsonAsync(new Uri(_options.EndPointUri ?? ""), _data).Result;
                if (response.IsSuccessStatusCode)
                {
                    return Task.FromResult(true);
                }
                else
                {
                    return Task.FromResult(false);
                }
            }
            catch (Exception ex)
            {
                Console.Write("Có lỗi khi gửi data analytic: " + ex);
                return Task.FromResult(false);
            }
        }

        public Task<bool> SendAsync(AnalyticData analyticData)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = httpClient.PostAsJsonAsync(new Uri(_options.EndPointUri ?? ""),analyticData).Result;
                if (response.IsSuccessStatusCode)
                {
                    return Task.FromResult(true);
                }
                else
                {
                    return Task.FromResult(false);
                }
            }
            catch (Exception ex)
            {
                Console.Write("Có lỗi khi gửi data analytic: " + ex);
                return Task.FromResult(false);
            }
        }

        public IAnalyticService SetData(AnalyticData data)
        {
            _data = data;
            return this;
        }

        public IAnalyticService SetOptions(AnalyticsOptions analyticsOptions)
        {
            _options=analyticsOptions;
            return this;
        }
    }
}
