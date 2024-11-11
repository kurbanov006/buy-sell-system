public static class DealMapping
{
    public static Deal CreateToDeal(this CreateDealInfo createDeal)
    {
        return new Deal()
        {
            ProductId = createDeal.DealBaseInfo.ProductId,
            SellerUserId = createDeal.DealBaseInfo.SellerUserId,
            CustomerUserId = createDeal.DealBaseInfo.CustomerUserId
        };
    }

    public static Deal UpdateToDeal(this Deal deal, UpdateDealInfo dealInfo)
    {
        deal.CustomerUserId = dealInfo.DealBaseInfo.CustomerUserId;
        deal.SellerUserId = dealInfo.DealBaseInfo.SellerUserId;
        deal.ProductId = dealInfo.DealBaseInfo.ProductId;
        deal.UpdatedAt = DateTime.UtcNow;
        return deal;
    }

    public static ReadDealInfo ToRead(this Deal deal)
    {
        return new ReadDealInfo()
        {
            Id = deal.Id,
            CreatedAt = deal.CreatedAt,
            DealBaseInfo = new()
            {
                ProductId = deal.ProductId,
                CustomerUserId = deal.CustomerUserId,
                SellerUserId = deal.SellerUserId
            }
        };
    }

    public static Deal ToDeleted(this Deal deal)
    {
        deal.IsDeleted = true;
        deal.DeletedAt = DateTime.UtcNow;
        return deal;
    }
}