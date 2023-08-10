using System;

namespace MacucoApi.Domains
{
    public class Facial_Records
    {
        public int user_id { get; set; }
        public string description { get; set; }
        public string document {get; set;}
        public string phone {get; set;}
        public string card {get; set;}
        public string email {get; set;}
        public string observation {get; set;}
        public string base64 {get; set;}
        public string user_cod {get; set;}
        public string birth_date {get; set;}
        public DateTime created_at {get; set;}
        public DateTime updated_at {get; set;}
    }
}