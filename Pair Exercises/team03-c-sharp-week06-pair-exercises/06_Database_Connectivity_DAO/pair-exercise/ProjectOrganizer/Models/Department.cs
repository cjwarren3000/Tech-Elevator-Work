using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOrganizer.Models
{
    public class Department
    {
        /// <summary>
        /// The dept id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The dept name.
        /// </summary>
        public string Name { get; set; }

        public Department(int id, string name)
        {
            Id = id;
            Name = name;

        }

    }

}
