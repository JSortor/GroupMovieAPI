using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace GroupMovieAPI.Models
{
    public class MovieDAL
    {
        

        public static string GetData(string URL)
        {
            HttpWebRequest request = WebRequest.CreateHttp(URL);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader rd = new StreamReader(response.GetResponseStream());
            string data = rd.ReadToEnd();
            rd.Close();

            return data;
        }

        public static List<MovieDB> SearchMovies(string UserInput)
        {
            string output = GetData($"http://www.omdbapi.com/?s={UserInput}&apikey=61912d7d&type=movie");
            List<MovieDB> SearchMovies = new List<MovieDB>();
            JObject movieJSon = JObject.Parse(output);

            List<JToken> SearchMovieTokens = movieJSon["Search"].ToList();

            for (int i = 0; i < SearchMovieTokens.Count; i++)
            {

                MovieDB movie = new MovieDB();
                movie.Title = SearchMovieTokens[i]["Title"].ToString();
                string MovieYear = SearchMovieTokens[i]["Year"].ToString();
                if (MovieYear.Contains("-"))
                {
                    movie.Year = int.Parse(MovieYear.Trim('-'));
                }
                else
                {
                    movie.Year = int.Parse(MovieYear);
                }
                movie.Poster = SearchMovieTokens[i]["Poster"].ToString();
                movie.Type = SearchMovieTokens[i]["Type"].ToString();
                movie.imdbID = SearchMovieTokens[i]["imdbID"].ToString();
                SearchMovies.Add(movie);
            
            }
            return SearchMovies;
            
        }

        
    }
}