using bzDropDownListCorrelation.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bzDropDownListCorrelation
{
    public class MyClassService
    {
        public async Task<List<MyClass>> Get()
        {
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
            return result;
        }
    }
}
