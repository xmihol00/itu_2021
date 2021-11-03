﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using itu.Common.Enums;

namespace itu.DAL.Entities.Tasks.Interfaces
{
    public interface IAcceptationEntity : ITaskEntity
    {
        public string Benefit { get; set; }
        public double PriceGues { get; set; }
        public CurrencyEnum Currency { get; set; }
        public string Reason { get; set; }
        public bool Accepted { get; set; }
    }
}