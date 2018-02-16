using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using VkNet;
using VkNet.Exception;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TimeTableServer.Utils;
using TimeTableServer.Models;

namespace TimeTableServer.Services.VK
{
    public class VkBotService : IVkBotService
    {
        VkApi _api;
        IConfiguration _config;
        string _token;
        ILogger<VkBotService> _logger;
        ITimeTableService _timeTable;
        UtilsConvert _utilsConvert;
        public VkBotService(IConfiguration config, ILogger<VkBotService> logger, ITimeTableService timeTable, 
            UtilsConvert utilsConvert)
        {
            _config = config;
            _logger = logger;
            _timeTable = timeTable;
            _utilsConvert = utilsConvert;
            _api = new VkApi();
        }
        public Task StartAsync()
        {
            //_logger.LogCritical("StartAsync");
            return Task.Run(async () =>
            {
                _token = _config.GetConnectionString("VkTokenGroup");
                await Start();
            });
        }
        private async Task Start()
        {
            await _api.AuthorizeAsync(new ApiAuthParams
            {
                AccessToken = _token
            });
            if (_api.IsAuthorized)
            {
                _logger.LogInformation("Connection successfull!");

                LongPollServerResponse dataConnection = await _api.Messages.GetLongPollServerAsync(true);
                while (true)
                {
                    LongPollHistoryResponse history = await _api.Messages.GetLongPollHistoryAsync(
                        new MessagesGetLongPollHistoryParams
                        {
                            Ts = dataConnection.Ts,
                            Pts = dataConnection.Pts,
                        });
                    dataConnection.Pts = history.NewPts;
                    if (history.Messages.Count > 0)
                    {
                        if (history.Messages.Last().Out.Value == false)
                        {
                            _logger.LogInformation("Пришло сообщение! " + history.Messages.Last().Body);
                            User user = _api.Users.Get(new List<long> { history.Messages.Last().UserId.Value }).Last();
                            string buffer = history.Messages.Last().Body.ToLower();
                            string[] bufferArray = buffer.Split(" ");
                            string answer = "";
                            ShowCommandcs show = new ShowCommandcs(_timeTable, _utilsConvert);
                            if (show.СanExecute(bufferArray))
                            {
                                Console.WriteLine("Разрешил!");
                                answer = await show.Execute(bufferArray);
                                _logger.LogInformation("Ответ: " + answer);
                            }
                            Console.WriteLine("Начало обращения к бд!");
                            Class b = await _timeTable.GetClassAsync("9Б");
                            Console.WriteLine("Конец обращения к бд!");
                            _api.Messages.Send(new MessagesSendParams
                            {
                                UserId = user.Id,
                                Message = b.Name
                            });
                        }
                    }
                }
            }
            else
                _logger.LogWarning("No connection!");
        }
    }
}
