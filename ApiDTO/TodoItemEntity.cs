using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidMvc.ApiDTO
{
    public class TodoItemEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool SetReminder { get; set; }
        public DateTime AlarmTime { get; set; }
        public bool Repeat { get; set; }
        public bool IsComplete { get; set; }
        //public char Status { get; set; }
    }
}
