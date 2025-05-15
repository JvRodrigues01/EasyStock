using EasyStock.Domain.Product.Enums;
using EasyStock.SharedKernel.Core.Base;

namespace EasyStock.Domain.Product.Entities
{
    public class Product : EntityBase
    {
        public Product(string name, string description, string sku, decimal costPrice, 
            decimal salePrice, ProductUnit unit, Guid enterpriseId)
        {
            Name = name;
            Description = description;
            Sku = sku;
            CostPrice = costPrice;
            SalePrice = salePrice;
            Unit = unit;
            EnterpriseId = enterpriseId;
            Active = true;
            SetNewEntity();
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Sku { get; private set; }
        public decimal CostPrice { get; private set; }
        public decimal SalePrice { get; private set; }
        public decimal ProfitMargin => SalePrice - CostPrice;
        public ProductUnit Unit { get; private set; }
        public Guid EnterpriseId { get; private set; }
        public Enterprise.Entities.Enterprise Enterprise { get; private set; }
        public Stock.Entities.Stock Stock { get; private set; }

        public void UpdatePrice(decimal cost, decimal sale)
        {
            CostPrice = cost;
            SalePrice = sale;
        }

        public void UpdateInfo(string name, string description, string sku, decimal costPrice,
            decimal salePrice, ProductUnit unit)
        {
            Name = name;
            Description = description;
            Sku = sku;
            CostPrice = costPrice;
            SalePrice = salePrice;
            Unit = unit;
        }
    }
}
