﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ESChatServer.Areas.v1.Models.Database.Entities
{
    public class Room
    {
        [Required]
        public long ID { get; set; }

        [Required]
        public long IDOwner { get; set; }

        [Required, MaxLength(64)]
        public string Name { get; set; }

        [MaxLength(256)]
        public string Description { get; set; }

        [Required]
        public DateTime? UTCCreationDate { get; set; }

        #region Virtual
        [JsonIgnore]
        public virtual User Owner { get; set; }
        [JsonIgnore]
        public virtual ICollection<Participant> Participants { get; set; }
        [JsonIgnore]
        public virtual ICollection<Message> Messages { get; set; }
        #endregion
    }
}
