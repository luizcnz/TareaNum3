using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace App02SQLite.Models
{
    public class Personas
    {
        [PrimaryKey, AutoIncrement]
        public int id { get;set; }

        [MaxLength(250)]
        public string nombre { get; set; }

        [MaxLength(250)]
        public string apellido { get; set; }

        public int edad { get; set; }

        public string fecha { get; set; }

        [MaxLength(100)]
        public string correo { get; set; }
        
        [MaxLength(300)]
        public string direccion { get; set; }


    }
}
