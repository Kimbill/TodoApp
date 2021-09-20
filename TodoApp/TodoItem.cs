using System;
using System.Collections.Generic;
using System.Text;

namespace TodoApp
{
    public class TodoItem
    {
        public int ItemId { get; set; }
        public string Item { get; set; }
        public bool Status { get; set; }

        public TodoItem(int ItemId, string Item)
        {
            this.ItemId = ItemId;
            this.Item = Item;
        }

    }
}
