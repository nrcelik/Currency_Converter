using Entities.Abstract;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class Rate : IEntity
    {
        public Dictionary<string, string> Rates { get; set; }
    }
}