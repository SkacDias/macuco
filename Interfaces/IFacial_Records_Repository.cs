using MacucoApi.Domains;
using System.Collections.Generic;

namespace MacucoApi.Interfaces
{
    public interface IFacial_Records_Repository
    {
        public int IncluirFace(Facial_Records facial_Records);
        public List<Facial_Records> ListarFaces();
        public List<Facial_Records> ListarFacesPorGestão(int gestaoId);
    }
}