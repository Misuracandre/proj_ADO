using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proj_ADO.Model;
using proj_ADO.Models;

// ler uma tabela inteira = FullScan

namespace proj_ADO.Services
{
    public class AirPlaneService
    {
        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\Documents\fly.mdf;";
        readonly SqlConnection conn;

        public AirPlaneService()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public bool Insert(AirPlane airplane)
        {
            bool status = false;

            try
            {
                string strInsert = "insert into Airplane (Name, NumberOfPassagers, Description, IdEngine)" + "values (@Name, @NumberOfPassagers, @Description, @IdEngine)"; // os @ sao parametros para fazer replace

                SqlCommand commandInsert = new SqlCommand(strInsert, conn);

                commandInsert.Parameters.Add(new SqlParameter("@Name", airplane.Name));
                commandInsert.Parameters.Add(new SqlParameter("@NumberOfPassagers", airplane.NumberOfPassagers));
                commandInsert.Parameters.Add(new SqlParameter("@Description", airplane.Description));
                commandInsert.Parameters.Add(new SqlParameter("@IdEngine", InsertEngine(airplane)));

                commandInsert.ExecuteNonQuery(); // muito usado pra insert, update e delete
                status = true;
            }
            catch (Exception)
            {
                status = false;
                throw; // apenas para ver o nome do erro
            }
            finally// independente de inserir ou nao, ele fecha a conexao, depois abre denovo para inserir um novo
            {
                conn.Close();
            }
            return status;
        }

        private int InsertEngine(AirPlane airplane) // vai inserir o motor no aviao
        {
            string strInsert = "insert into Engine (Description)" + "values (@Description); select cast(scope_identity() as int)"; // para ele trazer na hora o id que ele criou

            SqlCommand commandInsert = new SqlCommand(strInsert, conn);
            commandInsert.Parameters.Add(new SqlParameter("@Description", airplane.Engine.Description));

            return (int)commandInsert.ExecuteScalar(); // faz a execucao e ja possibita o retorno de uma informaçao, ja vai trazer o resultado das sub query;
        }

        public List<AirPlane> FindAll()
        {
            List<AirPlane> airplanes = new();

            StringBuilder sb = new StringBuilder(); // concatena as strings, construtor de strings
            sb.Append("select a.Id, ");
            sb.Append("       a.Name, ");
            sb.Append("       a.Description, ");
            sb.Append("       a.NumberOfPassagers, ");
            sb.Append("       e.Description Engine");
            sb.Append("  from AirPlane a, ");
            sb.Append("       Engine e");
            sb.Append(" where a.IdEngine = e.Id");

            SqlCommand commandSelect = new(sb.ToString(), conn); // deixa tudo em uma lista grande com o toString, passando string e conexao
            SqlDataReader dr = commandSelect.ExecuteReader(); //receb o select como tabela

            while (dr.Read()) // esse while transforma a tabela em objeto
            {
                AirPlane airplane = new();



                airplane.Id = (int)dr["Id"];
                airplane.Name = (string)dr["Name"];
                airplane.NumberOfPassagers = (int)dr["NumberOfPassagers"];
                airplane.Description = (string)dr["Description"];
                airplane.Engine = new Engine() { Description = (string)dr["Engine"] };

                airplanes.Add(airplane);
            }
            return airplanes;
        }
    }
}
