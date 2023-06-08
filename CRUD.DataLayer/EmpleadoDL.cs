using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD.EntityLayer;
using System.Data;
using System.Data.SqlClient;



namespace CRUD.DataLayer
{
    public class EmpleadoDL
    {
        public List<Empleado> Lista()
        {
            List<Empleado> lista = new List<Empleado>();

            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                // ojoo  aca en oConexional final dijo se usaba 
                SqlCommand cmd = new SqlCommand("select * from fn_Empleados()", oConexion);
                cmd.CommandType = CommandType.Text;
                try
                {
                    oConexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Empleado
                            {
                                idEmpleado = Convert.ToInt32(dr["idEmpleado"].ToString()),
                                NombreCompleto = dr["NombreCompleto"].ToString(),
                                Departamento = new Departamento
                                {
                                    idDepartamento = Convert.ToInt32(dr["idDepartamento"].ToString()),
                                    Nombre = dr["Nombre"].ToString()
                                },
                                Sueldo = (decimal)dr["Sueldo"],
                                FechaContrato = dr["FechaContrato"].ToString()
                            });
                        }
                    }
                    return lista;

                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }
        //----------fin lista-------------

        public Empleado Obtener(int idEmpleado)
        {
            Empleado entidad = new Empleado();

            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                // ojoo  aca en oConexional final dijo se usaba 
                SqlCommand cmd = new SqlCommand("select * from fn_Empleado(@idEmpleado)", oConexion);
                cmd.Parameters.AddWithValue("@idEmpleado", idEmpleado);
                cmd.CommandType = CommandType.Text;
                try
                {
                    oConexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {   

                        if(dr.Read())
                        {
                            entidad.idEmpleado = Convert.ToInt32(dr["idEmpleado"].ToString());
                            entidad.NombreCompleto = dr["NombreCompleto"].ToString();
                            entidad.Departamento = new Departamento
                            {
                                idDepartamento = Convert.ToInt32(dr["idEmpleado"].ToString()),
                                Nombre = dr["Nombre"].ToString()
                            };
                            entidad.Sueldo = (decimal)dr["Sueldo"];
                            entidad.FechaContrato = dr["FechaContrato"].ToString();

                        }
                     
                    }
                    return entidad;

                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }
    }
}
