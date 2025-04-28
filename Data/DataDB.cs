using Microsoft.Data.SqlClient;
using Parcial_1__Programacion.Models;

namespace Parcial_1__Programacion.Data
{
    public class DataDB
    {
        public SqlConnection Conectar()
        {
            string Cadena = "Data Source=nico;Initial Catalog=PrimerParcial-Prog;Integrated Security=True;Trust Server Certificate=True";
            SqlConnection con = new SqlConnection(Cadena);
            con.Open();
            return con;
        }

        public void VerificarTablaObraSocial()
        {
            string query = "Select count(*) from ObraSociales";
            SqlCommand cmd = new SqlCommand(query, Conectar());
            int contador = (int)cmd.ExecuteScalar();
            cmd.Connection.Close();
            if (contador == 0)
            {
                string query2 = "insert into Obrasociales (Nombre) values ('OSDE'), ('APROSS'), ('PAMI'), ('OTRO')";
                SqlCommand cmd2 = new SqlCommand(query2, Conectar());
                cmd2.ExecuteNonQuery();
                cmd2.Connection.Close();
            }
        }
        public List<Obrasocial> ListarObras(int id)
        {
                string query = "Select * from Obrasociales";
            try
            {
                List<Obrasocial> lista = new List<Obrasocial>();
                SqlCommand cmd = new SqlCommand(query, Conectar());
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    Obrasocial obra = new Obrasocial();
                    obra.Id = (int)read["Id"];
                    obra.Nombre = (string)read["Nombre"];
                    lista.Add(obra);
                }
                read.Close();
                return lista;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Paciente> ListarPacientes(int idPaciente, int idObra)
        {
            string query = "Select Pacientes.*, Obrasociales.Nombre as Obra from Pacientes join Obrasociales on Pacientes.IdObrasocial = Obrasociales.Id";

            if (idPaciente > 0)
            {
                query += $" where Id = {idPaciente}";
            }
            if (idObra > 0)
            {
                query += $" where IdObrasocial = {idObra}";
            }

            query += " order by Obrasociales.Id";
            try
            {
                List<Paciente> lista = new List<Paciente>();
                SqlCommand cmd = new SqlCommand(query, Conectar());
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    Paciente paciente = new Paciente();
                    paciente.Id = (int)read["Id"];
                    paciente.Nombre = (string)read["Nombre"];
                    paciente.Edad = (int)read["Edad"];
                    paciente.IdObrasocial = (int)read["IdObrasocial"];
                    paciente.Sintomas = (string)read["Sintomas"];
                    paciente.obra = new Obrasocial();
                    {
                        paciente.obra.Id = (int)read["IdObrasocial"];
                        paciente.obra.Nombre = (string)read["Obra"];
                    }
                    lista.Add(paciente);
                }
                return lista;
                
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string EliminarPaciente(int id)
        {
            string query = $"delete from Pacientes where Id = {id}";
            try
            {
                SqlCommand cmd = new SqlCommand(query, Conectar());
                cmd.ExecuteNonQuery();
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
 
        public string CrearPaciente(Paciente _paciente)
        {
            string query = "insert into Pacientes (Nombre, Edad, IdObrasocial, Sintomas) " +
                $"values ('{_paciente.Nombre}',{_paciente.Edad}, {_paciente.IdObrasocial},'{_paciente.Sintomas}') ";
            try
            {
                SqlCommand cmd = new SqlCommand(query, Conectar());
                cmd.ExecuteNonQuery();
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
