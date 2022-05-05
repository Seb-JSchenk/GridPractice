using System;
namespace GridPractice.Models
{
    public class Things
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Stars { get; set; }

        public Things()
        {
            Name = "Jeff";
        }
    }
}
