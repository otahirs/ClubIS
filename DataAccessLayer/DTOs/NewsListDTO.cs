using System;
using System.Collections.Generic;
using System.Text;

namespace clubIS.DataAccessLayer.DTOs
{
    class NewsListDTO
    {
        public string UserName { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
    }
}
