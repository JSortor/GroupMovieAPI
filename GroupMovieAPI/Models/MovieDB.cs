using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroupMovieAPI.Models
{
    public class MovieDB
    {
        private string output;
        private int i;

        public MovieDB()
        {
        }

        public MovieDB(string output, int i)
        {
            this.output = output;
            this.i = i;
        }

        public string Title { get; set; }
        public int Year { get; set; }
        public string Poster { get; set; }
        public string Type { get; set; }
        public string imdbID { get; set; }
       

    }
}