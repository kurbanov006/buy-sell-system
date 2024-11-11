public static class ProductMapping
{
    public static Product CreateToProduct(this CreateProductInfo productInfo)
    {
        return new Product()
        {
            ProductName = productInfo.ProductBaseInfo.ProductName,
            SellerUserId = productInfo.ProductBaseInfo.SellerUserId,
            Quantity = productInfo.ProductBaseInfo.Quantity,
            Price = productInfo.ProductBaseInfo.Price
        };
    }

    public static Product UpdateProduct(this Product product, UpdateProductInfo productInfo)
    {
        product.ProductName = productInfo.ProductBaseInfo.ProductName;
        product.SellerUserId = productInfo.ProductBaseInfo.SellerUserId;
        product.Quantity = productInfo.ProductBaseInfo.Quantity;
        product.Price = productInfo.ProductBaseInfo.Price;
        product.UpdatedAt = DateTime.UtcNow;
        return product;
    }

    public static ReadProductInfo ToRead(this Product product)
    {
        return new ReadProductInfo()
        {
            Id = product.Id,
            CreatedAt = product.CreatedAt,
            ProductBaseInfo = new ProductBaseInfo()
            {
                ProductName = product.ProductName,
                SellerUserId = product.SellerUserId,
                Quantity = product.Quantity,
                Price = product.Price
            }
        };
    }

    public static Product ToDeleted(this Product product)
    {
        product.DeletedAt = DateTime.UtcNow;
        product.IsDeleted = true;
        return product;
    }
}