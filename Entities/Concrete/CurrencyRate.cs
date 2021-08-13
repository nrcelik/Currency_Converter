using Entities.Abstract;
using System;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class CurrencyRate : IEntity
    { 
        public Dictionary<string, string> Rates { get; set; }
    }
}
