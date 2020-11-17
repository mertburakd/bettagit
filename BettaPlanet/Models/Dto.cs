using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BettaPlanet.Models
{
    public class Dto
    {
        [Table("Iletisim")]
        public class Iletisim
        {
            [Key]
            [Column("id")]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int id { get; set; }
            public string name { get; set; }
            public string email { get; set; }
            public string topic { get; set; }
            public string project { get; set; }

        }


        public class MethodStatus
        {
            public bool success { get; set; }
            public string ErrorMessage { get; set; }
            public int Error { get; set; }
            public List<AddData> AdditionalData { get; set; }
            public int ReturnId { get; set; }

        }

        public class AddData
        {
            public string text { get; set; }
            public string value { get; set; }
        }
        public partial class uruncuk
        {
            public int id { get; set; }
            public string urunadi { get; set; }
            public string kuyruk { get; set; }
            public string tecrube { get; set; }
            public string yas { get; set; }
            public string fiyat { get; set; }
            public string resim { get; set; }
            public DateTime tarih { get; set; }
        }

    }
}