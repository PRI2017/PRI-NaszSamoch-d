using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PRI_NaszSamochód.Models
{
    public class PhotoModel
    {
        [Key]
        public int Id { get; set; }
        public string Path { get; set; }

        public PhotoModel()
        {
            
        }

        public PhotoModel(string path)
        {
            this.Path = path;
        }
    }
}