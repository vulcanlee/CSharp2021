using System;
using System.Collections.Generic;
using System.Linq;

namespace bzAntTable.Pages
{
    public class MyNoteService
    {
        public List<MyNote> MyNoteItems { get; set; }
        public MyNoteService()
        {
            var rnd = new Random();
            MyNoteItems = Enumerable.Range(1, 88).Select(index =>
            {
                var temperatureC = rnd.Next(-20, 55);
                return new MyNote
                {
                    Id = index,
                    Title=$"我的記事 {index}",
                };
            }).ToList();
        }

        public (List<MyNote> items, int total) Get(int pageIndex, int pageSize)
        {
            var items = MyNoteItems
                .Skip((pageIndex - 1)* pageSize)
                .Take(pageSize)
                .ToList();
            var total = MyNoteItems.Count;
            return (items, total);
        }
        public void Add(MyNote myNote)
        {
            var rnd = new Random();
            myNote.Id = rnd.Next(1000, 9999999);
            var item = MyNoteItems.FirstOrDefault(x => x.Id == myNote.Id);
            if (item == null)
            {
                MyNoteItems.Add(myNote);
            }
        }
        public void Update(MyNote myNote)
        {
            var item = MyNoteItems.FirstOrDefault(x => x.Id == myNote.Id);
            if (item != null)
            {
                item.Title = myNote.Title;
            }
        }
        public void Delete(MyNote myNote)
        {
            MyNoteItems.Remove(MyNoteItems.FirstOrDefault(x => x.Id == myNote.Id));
        }
    }
}
