using bzDropDownListCorrelation.Data;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bzDropDownListCorrelation
{
    public class ProblemViewModel
    {
        public ProblemViewModel(MyClassService myClassService,
            YourClassService youClassService, ILogger<ProblemViewModel> logger)
        {
            MyClassService = myClassService;
            YourClassService = youClassService;
            Logger = logger;
        }
        public List<MyClass> MyClassList { get; set; } = new List<MyClass>();
        public List<YouClass> YourClassList { get; set; } = new List<YouClass>();
        public List<YouClass> HisClassList { get; set; } = new List<YouClass>();
        public QueryCondition QueryCondition { get; set; } = new QueryCondition();
        public MyClassService MyClassService { get; }
        public YourClassService YourClassService { get; }
        public ILogger<ProblemViewModel> Logger { get; }
        public bool ReadyGo { get; set; } = false;
        public Action DoStateHasChanged { get; set; }

        public async Task ProblemViewModelInit()
        {
            Logger.LogDebug($"資料初始化開始");
            #region 狀況 03 使用 AddRange + await 會造成資料無法讀取進來
            //MyClassList.Clear();
            //MyClassList.Insert(0, new MyClass { Name = "請選擇", Id = -1 });
            //QueryCondition.MyId = -1;
            //MyClassList.AddRange(await MyClassService.Get()); // 延遲3秒鐘，將無法建立預設選項清單
            #endregion

            #region 狀況 04 使用 先 await 再使用 AddRange ，似乎沒有問題
            //var myLists = await MyClassService.Get();
            //MyClassList.Clear();
            //MyClassList.Insert(0, new MyClass { Name = "請選擇", Id = -1 });
            //QueryCondition.MyId = -1;
            //MyClassList.AddRange(myLists); // 延遲3秒鐘，將無法建立預設選項清單
            #endregion

            #region 狀況 05 先對 DataSource 做操作，再使用 await 等待，最後使用 AddRange ，似乎有問題
            //MyClassList.Clear();
            //MyClassList.Insert(0, new MyClass { Name = "請選擇", Id = -1 });
            //QueryCondition.MyId = -1;
            //var myLists = await MyClassService.Get();
            //MyClassList.AddRange(myLists); // 延遲3秒鐘，將無法建立預設選項清單
            #endregion

            #region 狀況 06 另外一種可行做法，先 await，再同步進行下拉選單的清單項目設定(沒有使用 AddRange)
            var myLists = await MyClassService.Get();
            MyClassList.Clear();
            MyClassList = myLists;
            MyClassList.Insert(0, new MyClass { Name = "請選擇", Id = -1 });
            QueryCondition.MyId = -1;
            #endregion

            YourClassList.Clear();

            HisClassList.Clear();

            ReadyGo = true;
            Logger.LogDebug($"資料初始化結束");
        }

        public async Task MasterListChanged(Syncfusion.Blazor.DropDowns.ChangeEventArgs<int, MyClass> args)
        {
            Logger.LogDebug($"我的下拉選單變更事件開始");
            if (QueryCondition.MyId <= 0)
            {
                Logger.LogDebug($"我的下拉選單變更事件結束 MyId <= 0");
                return;
            }


            #region 狀況 07 使用這個方式，會造成無法連動顯示
            //YourClassList.Clear();
            //YourClassList.Insert(0, new YouClass { Name = "請選擇", Id = -1 });
            //QueryCondition.YourId = -1;
            //YourClassList.AddRange(await YourClassService.Get("你的選擇清單項目", QueryCondition.MyId));
            #endregion

            #region 狀況 08 使用這個方式，第一次會有連動，之後切換我的下拉選單項目，就會造成無法連動顯示
            //var yourList = await YourClassService.Get("你的選擇清單項目", QueryCondition.MyId);
            //YourClassList.Clear();
            //YourClassList.Insert(0, new YouClass { Name = "請選擇", Id = -1 });
            //QueryCondition.YourId = -1;
            //YourClassList.AddRange(yourList);
            #endregion

            #region 狀況 09 使用背景工作來進行相關清單更新，這樣也會失敗，注意全部清單項目數量數字會有更新
            //var task = Task.Run(async () =>
            //{
            //    YourClassList.Clear();
            //    YourClassList.Insert(0, new YouClass { Name = "請選擇", Id = -1 });
            //    QueryCondition.YourId = -1;
            //    YourClassList.AddRange(await YourClassService.Get("你的選擇清單項目", QueryCondition.MyId));
            //    DoStateHasChanged?.Invoke();
            //});
            #endregion

            #region 狀況 10 這樣做法可以正常運作
            var yourList = await YourClassService.Get("你的選擇清單項目", QueryCondition.MyId);
            var hisList = await YourClassService.Get("他的選擇清單項目", QueryCondition.MyId);
            YourClassList.Clear();
            YourClassList = yourList;
            YourClassList.Insert(0, new YouClass { Name = "請選擇", Id = -1 });
            QueryCondition.YourId = -1;

            HisClassList.Clear();
            HisClassList = hisList;
            HisClassList.Insert(0, new YouClass { Name = "請選擇", Id = -1 });
            QueryCondition.HisId = -1;
            #endregion
            Logger.LogDebug($"我的下拉選單變更事件結束");
        }
    }
    public class QueryCondition
    {
        public int MyId { get; set; }
        public int YourId { get; set; }
        public int HisId { get; set; }
    }
}
