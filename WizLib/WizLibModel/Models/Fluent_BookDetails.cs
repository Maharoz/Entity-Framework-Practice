using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WizLib_Model.Models
{
   public class Fluent_BookDetails
    {
        public int BookDetail_Id { get; set; }
        public string NumberOfChapters{ get;set;}
        public string NumberOfPages { get; set; }
        public double Weight { get; set; }
        public Book Book { get; set; }
    }
}
