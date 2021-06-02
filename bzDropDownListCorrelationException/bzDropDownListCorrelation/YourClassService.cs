﻿using bzDropDownListCorrelation.Data;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bzDropDownListCorrelation
{
    public class YourClassService
    {
        public YourClassService(ILogger<YourClassService> logger)
        {
            Logger = logger;
        }

        public ILogger<YourClassService> Logger { get; }

        public async Task<List<YouClass>> Get(string subject, int parentId)
        {
            Logger.LogDebug($"{subject}服務產生資料 開始");
            Random random = new();
            var maxItems = random.Next(10, 60);
            var delay = random.Next(500, 3000);
            await Task.Delay(delay); // 模擬存取資料庫的非同步執行時間
            List<YouClass> result = new();
            for (int i = 1; i < maxItems; i++)
            {
                YouClass myClass = new()
                {
                    Id = i,
                    Name=$"{subject}{parentId} - {i}",
                };
                result.Add(myClass);
            }
            Logger.LogDebug($"{subject}服務產生資料 結束");
            return result;
        }
    }
}
