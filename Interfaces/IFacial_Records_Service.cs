using MacucoApi.Domains;
using MacucoApi.Models;
using System.Collections.Generic;

namespace MacucoApi.Interfaces
{
    public interface IFacial_Records_Service
    {
        public ListResponse IncluirFace(Facial_Records facial_Records);
        public List_Facial_Records_Response ListarFaces();
        public List_Facial_Records_Response ListarFacesPorGestão(int gestaoId);
        public ListResponse FaceMatch(string faceTemplate);
    }
}