using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsUpp.Model
{
    public class Message
    {
        public string Text { get; set; }
        public DateTime Date { get; set; }

        public Message(string text, DateTime date)
        {
            this.Text = text;
            this.Date = date;
        }
    }
}
