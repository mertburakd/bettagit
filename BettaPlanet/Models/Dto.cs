using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace BettaPlanet.Models
{
    public class Dto
    {
        
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
            public double fiyat { get; set; }
            public string resimb { get; set; }
            public string resimk { get; set; }
            public string aciklama { get; set; }
            public DateTime tarih { get; set; }
        }
        public class LoginModel
        {
            [Required(ErrorMessage = "Please enter user name.")]
            [Display(Name = "username")]
            [StringLength(30)]
            public string username { get; set; }

            [Required(ErrorMessage = "Please enter password.")]
            [DataType(DataType.Password)]
            [Display(Name = "password")]
            [StringLength(10)]
            public string password { get; set; }

        }
        public class sip
        {

            public double fiyat { get; set; }
            public string resimk { get; set; }
            public DateTime tarih { get; set; }
            public string kuyruk { get; set; }
            public string tecrube { get; set; }
            public string yas { get; set; }
            public string aciklama { get; set; }
            public string aliciad { get; set; }
            public string urunadi { get; set; }
            public string adres { get; set; }
            public string telefon { get; set; }
        }

    }
}