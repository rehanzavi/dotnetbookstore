using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class Category
    {
        public int catId { get; set; }
        public string catName { get; set; }

        public string desc { get; set; }

        public string imageURL { get; set; }

        public int status { get; set; }

        public int pos { get; set; }

        public DateTime date { get; set; }


        public Category(int catId, string catName, string desc, string imageURL, int status, int pos, DateTime date)
        {
            this.catId = catId;
            this.catName = catName;
            this.desc = desc;
            this.imageURL = imageURL;
            this.status = status;
            this.pos = pos;
            this.date = date;
        }
    }
}