using bzDropDownListCorrelation.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace bzDropDownListCorrelation
{
    public class ProblemViewModel
    {
        public ProblemViewModel(MyClassService myClassService,
            YourClassService youClassService)
        {
            MyClassService = myClassService;
            YourClassService = youClassService;
        }
        public List<MyClass> MyClassList { get; set; } = new List<MyClass>();
        public List<YouClass> YourClassList { get; set; } = new List<YouClass>();
        public List<YouClass> HisClassList { get; set; } = new List<YouClass>();
        public QueryCondition QueryCondition { get; set; } = new QueryCondition();
        public MyClassService MyClassService { get; }
        public YourClassService YourClassService { get; }
        public bool ReadyGo { get; set; } = false;

        public async Task ProblemViewModelInit()
        {
            var myLists = await MyClassService.Get();

            #region 使用 AddRange + await 會造成資料無法讀取進來
            //MyClassList.Clear();
            //MyClassList.Insert(0, new MyClass { Name = "請選擇", Id = -1 });
            //QueryCondition.MyId = -1;
            //MyClassList.AddRange(await MyClassService.Get());
            #endregion

            MyClassList.Clear();
            MyClassList = myLists;
            MyClassList.Insert(0, new MyClass { Name = "請選擇", Id = -1 });
            QueryCondition.MyId = -1;

            YourClassList.Clear();
            YourClassList.Insert(0, new YouClass { Name = "請選擇", Id = -1 });
            QueryCondition.YourId = -1;

            HisClassList.Clear();
            HisClassList.Insert(0, new YouClass { Name = "請選擇", Id = -1 });
            QueryCondition.HisId = -1;

            ReadyGo = true;
        }

        public async Task MasterListChanged(Syncfusion.Blazor.DropDowns.ChangeEventArgs<int, MyClass> args)
        {
            if (QueryCondition.MyId <= 0) return;

            var yourList = await YourClassService.Get("你的選擇清單項目", QueryCondition.MyId);
            var hisList = await YourClassService.Get("他的選擇清單項目", QueryCondition.MyId);

            #region 使用這個方式，會造成無法連動顯示
            //YourClassList.Clear();
            //YourClassList.Insert(0, new YouClass { Name = "請選擇", Id = -1 });
            //QueryCondition.YourId = -1;
            //YourClassList.AddRange(yourList);
            //YourClassList = yourList;
            #endregion

            YourClassList.Clear();
            YourClassList = yourList;
            YourClassList.Insert(0, new YouClass { Name = "請選擇", Id = -1 });
            QueryCondition.YourId = -1;


            HisClassList.Clear();
            HisClassList = hisList;
            HisClassList.Insert(0, new YouClass { Name = "請選擇", Id = -1 });
            QueryCondition.HisId = -1;
        }
    }
    public class QueryCondition
    {
        public int MyId { get; set; }
        public int YourId { get; set; }
        public int HisId { get; set; }
    }
}
