using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.EntityLayer
{
    public class Empleado
    {
        public int idEmpleado { get; set; }
        public string NombreCompleto { get; set; }
        public Departamento Departamento { get; set;}
        public decimal Sueldo { get; set; } 
        public string FechaContrato { get; set; }
    }
}
