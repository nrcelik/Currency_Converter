using Entities.Abstract;

namespace Entities.Concrete
{
    public class Currency : IEntity
    {
        public string CurrencyType { get; set; }
    }
}