using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using MacucoApi.Domains;
using MacucoApi.Interfaces;

namespace MacucoApi.Repositories
{
    public class Facial_Records_Repository : BaseRepository, IFacial_Records_Repository
    {
        public int IncluirFace(Facial_Records facial_Records)
        {
            string query = @"
                ISERT INTO [dbo].[facial_records]
                            ([description]
                            ,[document]
                            ,[phone]
                            ,[card]
                            ,[email]
                            ,[observation]
                            ,[base64]
                            ,[user_cod]
                            ,[birth_date]
                            ,[created_at]
                            ,[updated_at])
                    OUTPUT Inserted.user_id
                    VALUES
                            (@description
                            ,@document
                            ,@phone
                            ,@card
                            ,@email
                            ,@observation
                            ,@base64
                            ,@user_cod
                            ,@birth_date
                            ,@created_at
                            ,@updated_at)
            ";

            var con = new SqlConnection(_connectionString);
            con.Open();
            return con.ExecuteScalar<int>(query, facial_Records);
        }

        public List<Facial_Records> ListarFaces()
        {
            string query = @"
                    SELECT   [user_id]
                            ,[description]
                            ,[document]
                            ,[phone]
                            ,[card]
                            ,[email]
                            ,[observation]
                            ,[base64]
                            ,[user_cod]
                            ,[birth_date]
                            ,[created_at]
                            ,[updated_at]
                    FROM [dbo].[facial_records]
            ";

            var con = new SqlConnection(_connectionString);
            con.Open();
            return con.Query<Facial_Records>(query).ToList();
        }

        public List<Facial_Records> ListarFacesPorGestão(int gestaoId)
        {
            //Sem campo de gestaoId. Metodo inutilizavel.
            string query = @"
                    SELECT   [user_id]
                            ,[description]
                            ,[document]
                            ,[phone]
                            ,[card]
                            ,[email]
                            ,[observation]
                            ,[base64]
                            ,[user_cod]
                            ,[birth_date]
                            ,[created_at]
                            ,[updated_at]
                    FROM [dbo].[facial_records]
                    WHERE user_id = @user_id
            ";

            var con = new SqlConnection(_connectionString);
            con.Open();
            return con.Query<Facial_Records>(query, new {gestaoId}).ToList();
        }
    }
}