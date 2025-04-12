using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace miForumulario.Clases
{
    public class Crud
    {
        string connectionString = "Server=PREDATORHELIOS-\\SQLEXPRESS01;Database=umg;Integrated Security=True; TrustServerCertificate=True; ";


        public void MostrarAlumno()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "SELECT * FROM tb_alumnos where seccion = 'C' order by estudiante";
                    SqlCommand command = new SqlCommand(query, connection);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"Carnet:{reader["seccion"]} Nombre: {reader["Estudiante"]}");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("ups error al conectar a la base de datos: " + ex.Message);
                }
                connection.Close();
            }
        }


        public int AgregarAlumno(string carnet, string nombre, string seccion, string email)
        {
           
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "INSERT INTO tb_alumnos (carnet, estudiante, seccion, email) VALUES (@carnet, @nombre, @seccion, @email)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@carnet", carnet);
                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.Parameters.AddWithValue("@seccion", seccion);
                    command.Parameters.AddWithValue("@email", email);
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Alumno agregado exitosamente.");
                    }
                    else
                    {
                        Console.WriteLine("No se pudo agregar el alumno.");
                    }
                    return rowsAffected;

                }
                catch (Exception ex)
                {
                    Console.WriteLine("ups error al conectar a la base de datos: " + ex.Message);
                    return -1;
                }
                connection.Close();
            }




        }



        public void ActualizarAlumno()
        {
            Console.WriteLine("Ingrese el carnet del alumno a actualizar:");
            string carnet = Console.ReadLine();
            Console.WriteLine("Ingrese el nuevo nombre del alumno:");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese la nueva seccion del alumno:");
            char seccion = Console.ReadKey().KeyChar;
            Console.WriteLine("Ingrese el nuevo Email del alumno:");
            string email = Console.ReadLine();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "UPDATE tb_alumnos SET estudiante = @nombre, seccion = @seccion, email = @email WHERE carnet = @carnet";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@carnet", carnet);
                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.Parameters.AddWithValue("@seccion", seccion);
                    command.Parameters.AddWithValue("@email", email);
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Alumno actualizado exitosamente.");
                    }
                    else
                    {
                        Console.WriteLine("No se pudo actualizar el alumno.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ups error al conectar a la base de datos: " + ex.Message);
                }
                connection.Close();
            }
        }


        public void EliminarAlumno()
        {
            Console.WriteLine("Ingrese el carnet del alumno a eliminar:");
            string carnet = Console.ReadLine();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "DELETE FROM tb_alumnos WHERE carnet = @carnet";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@carnet", carnet);
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Alumno eliminado exitosamente.");
                    }
                    else
                    {
                        Console.WriteLine("No se pudo eliminar el alumno.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ups error al conectar a la base de datos: " + ex.Message);
                }
                connection.Close();
            }
        }


    }
}
