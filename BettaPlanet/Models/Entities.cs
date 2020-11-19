using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BettaPlanet.Models
{
    public class Entities
    {
        [Table("urunler")]
        public partial class URUNLER
        {
            [Key]
            [Column("id")]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int id { get; set; }
            public string urunadi { get; set; }
            public string kuyruk { get; set; }
            public string tecrube { get; set; }
            public string yas { get; set; }
            public string fiyat { get; set; }
            public string resimb { get; set; }
            public string resimk { get; set; }
            public DateTime tarih { get; set; }
            public string aciklama { get; set; }
        }
        [Table("iletisim")]
        public class iletisim
        {
            [Key]
            [Column("id")]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int id { get; set; }
            public string name { get; set; }
            public string email { get; set; }
            public string topic { get; set; }
            public string project { get; set; }
            public DateTime tarih { get; set; }


        }
        [Table("about")]
        public class about
        {
            [Key]
            [Column("id")]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int id { get; set; }
            public string info { get; set; }

        }

        [Table("balikbilgi")]
        public class balikbilgi
        {
            [Key]
            [Column("id")]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int id { get; set; }
            public string baslik { get; set; }
            public string bilgi { get; set; }
            public DateTime tarih { get; set; }

        }
        [Table("admin")]
        public class admin
        {
            [Key]
            [Column("id")]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int id { get; set; }
            public string username { get; set; }
            public string password { get; set; }
        }
    }
}