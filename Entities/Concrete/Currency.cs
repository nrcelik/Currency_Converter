using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Currency : IEntity
    {
        public string CurrencyType { get; set; }
    }
}
