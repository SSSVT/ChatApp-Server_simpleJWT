﻿//using Newtonsoft.Json;
//using System;
//using System.ComponentModel.DataAnnotations;

//namespace ESChatServer.Areas.v1.Models.Database.Entities
//{
//    public class Login
//    {
//        [Required]
//        public Guid ID { get; set; }

//        [Required]
//        public long IDUser { get; set; }

//        [Required]
//        public DateTime? UTCLoginTime { get; set; }

//        public DateTime? UTCLogoutTime { get; set; }

//        [Required, MaxLength(256)]
//        public string UserAgent { get; set; }

//        [Required, MaxLength(15)]
//        public string IPAddress { get; set; }

//        #region Virtual
//        [JsonIgnore]
//        public virtual User User { get; set; }
//        #endregion
//    }
//}
