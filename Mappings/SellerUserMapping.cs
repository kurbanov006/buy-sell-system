public static class SellerUserMapping
{
    public static SellerUser CreateToSellerUser(this CreateSellerUserInfo createSellerUser)
    {
        return new SellerUser()
        {
            UserName = createSellerUser.BaseUserInfo.UserName,
            FullName = createSellerUser.BaseUserInfo.FullName,
            Email = createSellerUser.BaseUserInfo.Email,
            Age = createSellerUser.BaseUserInfo.Age,
            Phone = createSellerUser.BaseUserInfo.Phone
        };
    }

    public static SellerUser UpdateToSellerUser(this SellerUser sellerUser, UpdateSellerUserInfo updateSeller)
    {

        sellerUser.UserName = updateSeller.BaseUserInfo.UserName;
        sellerUser.FullName = updateSeller.BaseUserInfo.FullName;
        sellerUser.Email = updateSeller.BaseUserInfo.Email;
        sellerUser.Age = updateSeller.BaseUserInfo.Age;
        sellerUser.Phone = updateSeller.BaseUserInfo.Phone;
        sellerUser.UpdatedAt = DateTime.UtcNow;
        return sellerUser;

    }

    public static ReadSellerUserInfo ToRead(this SellerUser sellerUser)
    {
        return new ReadSellerUserInfo()
        {
            BaseUserInfo = new BaseUserInfo()
            {
                UserName = sellerUser.UserName,
                FullName = sellerUser.FullName,
                Email = sellerUser.Email,
                Age = sellerUser.Age,
                Phone = sellerUser.Phone
            }
        };
    }

    public static SellerUser ToDeleted(this SellerUser sellerUser)
    {
        sellerUser.IsDeleted = true;
        sellerUser.DeletedAt = DateTime.UtcNow;
        return sellerUser;
    }
}