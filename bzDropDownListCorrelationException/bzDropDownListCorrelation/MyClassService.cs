using bzDropDownListCorrelation.Data;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bzDropDownListCorrelation
{
    public class MyClassService
    {
        public MyClassService(ILogger<MyClassService> logger)
        {
            Logger = logger;
        }

        public ILogger<MyClassService> Logger { get; }

        public async Task<List<MyClass>> Get()
        {
            Logger.LogDebug($"我的服務產生資料 開始");
            Random random = new Random();
            var delay = random.Next(500, 4000);
            await Task.Delay(delay); // 模擬存取資料庫的非同步執行時間
            List<MyClass> result = new();
            for (int i = 1; i < 100; i++)
            {
                MyClass myClass = new()
                {
                    Id = i,
                    Name=$"我的選擇清單項目 {i}",
                };
                result.Add(myClass);
            }
            Logger.LogDebug($"我的服務產生資料 結束");
            return result;
        }
    }
}
