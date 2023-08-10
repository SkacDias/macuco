using MacucoApi.Domains;
using MacucoApi.Interfaces;
using MacucoApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MacucoApi.Controllers
{
    [Route("/")]
    public class Facial_Records_Controller : ControllerBase
    {
        private IFacial_Records_Service _facial_records_service;

        public Facial_Records_Controller(IFacial_Records_Service facial_records_service) => _facial_records_service = facial_records_service;

        /// <summary>
        /// Inclui uma nova Face no Banco de Dados.
        /// </summary>
        /// <param name="facial_Records">Objeto com os dados de cadastro da nova Face em formato Json.</param>
        /// <returns>Retorna o ID da nova face inserida.</returns>
        [HttpPost("incluir-face")]
        public IActionResult IncluirFace([FromBody] Facial_Records facial_Records)
        {
            try
            {
                var retorno = _facial_records_service.IncluirFace(facial_Records);
                return new ObjectResult(retorno) { StatusCode = retorno.StatusCode };
            }
            catch (System.Exception)
            {
                return new ObjectResult(new { }) { StatusCode = StatusCodes.Status500InternalServerError };
            }
            
        }

        [HttpGet("listar-todas-as-faces")]
        public IActionResult ListarFaces()
        {
            try
            {
                var retorno = _facial_records_service.ListarFaces();
                return new ObjectResult(retorno) { StatusCode = retorno.StatusCode };
            }
            catch (System.Exception)
            {
                return new ObjectResult(new { }) { StatusCode = StatusCodes.Status500InternalServerError };
            }
        }

        [HttpGet("listar-faces-por-gestor-empresa")]
        public IActionResult ListarFacesPorGestão(int gestaoId)
        {
            try
            {
                var retorno = _facial_records_service.ListarFacesPorGestão(gestaoId);
                return new ObjectResult(retorno) { StatusCode = retorno.StatusCode };
            }
            catch (System.Exception)
            {
                return new ObjectResult(new { }) { StatusCode = StatusCodes.Status500InternalServerError };
            }
        }

        [HttpGet("match-faces")]
        public IActionResult FaceMatch(string faceTemplate)
        {
            try
            {
                var retorno = _facial_records_service.FaceMatch(faceTemplate);
                return new ObjectResult(retorno) { StatusCode = retorno.StatusCode };
            }
            catch (System.Exception)
            {
                return new ObjectResult(new { }) { StatusCode = StatusCodes.Status500InternalServerError };
            }
        }
    }
}