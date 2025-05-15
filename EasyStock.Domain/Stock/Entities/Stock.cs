using EasyStock.SharedKernel.Core.Base;

namespace EasyStock.Domain.Stock.Entities
{
    public class Stock : EntityBase
    {
        public Stock(Guid productId, decimal quantity)
        {
            ProductId = productId;
            Quantity = quantity;
            SetNewEntity();
        }

        public Guid ProductId { get; private set; }
        public Product.Entities.Product Product { get; private set; }
        public decimal Quantity { get; private set; }

        public void Add(decimal amount) => Quantity += amount;
        public void Remove(decimal amount)
        {
            if (amount > Quantity)
                throw new InvalidOperationException("Estoque insuficiente.");

            Quantity -= amount;
        }
    }
}
