using System;
using System.Collections.Generic;
using System.Text;

namespace AspEFCore.Domain
{
    public class Mayor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
        public Gender Gender { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }
    }

    public enum Gender { 男 = 0, 女 = 1 }
}
