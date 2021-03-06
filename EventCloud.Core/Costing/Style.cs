﻿using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.MultiTenancy;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITRACK.Authorization.Roles;
using ITRACK.Costing;
using ITRACK.MultiTenancy;

namespace ITRACK.Company
{
  public  class Style : FullAuditedEntity<Guid>, IMustHaveTenant
    {
        public const int MaxTitleLength = 128;
        public const int MaxDescriptionLength = 2048;

        
        public virtual int TenantId { get; set; }


        [Key]

        public virtual int StyleId { get; set; }

        [Required]
        [StringLength(MaxTitleLength)]
        public virtual string StyleNo { get; protected set; }

        public virtual string ArticleNo { get; protected set; }


        public virtual string Season { get; protected set; }

        public virtual string Remark { get; protected set; }

        public virtual string OrderType { get; set; }

        public virtual string Department { get; set; }

        [Required]
        public virtual string BocNo { get; set; }

        public virtual string ItemType { get; set; }

        [Required]
        public virtual string BuyerId { get; set; }

        public virtual string ImagePath { get; set; }

      public virtual ICollection<WorkOrder> WorkOrders { get; set; }





      


    }
}
