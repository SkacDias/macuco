using MacucoApi.Domains;
using MacucoApi.Repositories;
using System.Collections.Generic;
using Luxand;
using MacucoApi.Interfaces;
using System.Text;
using MacucoApi.Models;
using Microsoft.AspNetCore.Http;
using System;

namespace MacucoApi.Services
{
    public class Facial_Records_Service : IFacial_Records_Service
    {
        string LicenseKey = "nt0TasI3lufjIY4MJ2lTOVqVfkNueLC1ILcCZRLcsyUT9A4/xV/gbVgaTGAdaBgXtpyFnrdDahUgDizcs+O4LKjo5zvpu7H3ZZ4UZk3Gt1E/40uh9+7OT2x9/4yhbbsOdXTW7dSPPYxYez621lD0eoIjEAs7vpAjsj41d2+trOA=";

        private IFacial_Records_Repository _facial_Records_Repository;

        public Facial_Records_Service(IFacial_Records_Repository facial_Records_Repository) => _facial_Records_Repository = facial_Records_Repository;

        public ListResponse IncluirFace(Facial_Records facial_Records)
        {
            var listResponse = new List<string>();

            //início das tratativas de erros
            if (facial_Records == null)
                listResponse.Add("Informações de cadastro não devem estar vazias.");

            if (listResponse.Count > 0)
                return new ListResponse()
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Mensagem = "Bad Request",
                    Erros = listResponse
                };
            //fim das tratativas

            facial_Records.user_id = _facial_Records_Repository.IncluirFace(facial_Records);
            facial_Records.created_at = DateTime.Now;

            return new ListResponse()
            {
                StatusCode = StatusCodes.Status201Created,
                Mensagem = "Cadastro realizado com sucesso."
            };
        }

        public List_Facial_Records_Response ListarFaces()
        {
            var lista = _facial_Records_Repository.ListarFaces();
            return new List_Facial_Records_Response() { Facial_Records_List = lista, StatusCode = StatusCodes.Status200OK };
        }

        public List_Facial_Records_Response ListarFacesPorGestão(int gestaoId)
        {
            var lista = _facial_Records_Repository.ListarFacesPorGestão(gestaoId);
            return new List_Facial_Records_Response() { Facial_Records_List = lista, StatusCode = StatusCodes.Status200OK };
        }

        public ListResponse FaceMatch(string faceTemplate)
        {
            var listResponse = new List<string>();
            //início das tratativas de erros
            if (faceTemplate == null)
                listResponse.Add("Face Template não deve estar vazio.");

            if (listResponse.Count > 0)
                return new ListResponse()
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Mensagem = "Bad Request",
                    Erros = listResponse
                };
            //fim das tratativas

            var lista = _facial_Records_Repository.ListarFaces();
            byte[] faceTemplate1 = Encoding.ASCII.GetBytes(faceTemplate);

            int returnActivate = FSDK.ActivateLibrary(LicenseKey);
            int returnInitialize = FSDK.InitializeLibrary();
            float Similarity = 0.98f;

            foreach (Facial_Records facial_Records2 in lista)
            {
                byte[] faceTemplate2 = Encoding.ASCII.GetBytes(facial_Records2.base64);
                int returnMatchFaces = FSDK.MatchFaces(ref faceTemplate1, ref faceTemplate2, ref Similarity);

                if (returnMatchFaces >= Similarity)
                    return new ListResponse()
                    {
                        StatusCode = StatusCodes.Status200OK,
                        Mensagem = "Face Autenticada com sucesso."
                    };
                else
                    continue;
            }

            return new ListResponse()
            {
                StatusCode = StatusCodes.Status404NotFound,
                Mensagem = "Face não corresponde a nenhuma face conhecida.",
                Erros = listResponse
            }; ;
        }
    }
}