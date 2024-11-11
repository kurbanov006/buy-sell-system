public static class CustomerUserMapping
{
    public static CustomerUser CreateToCustomerUser(this CreateCustomerUserInfo createCustomer)
    {
        return new CustomerUser()
        {
            UserName = createCustomer.BaseUserInfo.UserName,
            FullName = createCustomer.BaseUserInfo.FullName,
            Email = createCustomer.BaseUserInfo.Email,
            Age = createCustomer.BaseUserInfo.Age,
            Phone = createCustomer.BaseUserInfo.Phone
        };
    }

    public static CustomerUser UpdateToSellerUser(this CustomerUser customerUser, UpdateCustomerUserInfo updateCustomer)
    {

        customerUser.UserName = updateCustomer.BaseUserInfo.UserName;
        customerUser.FullName = updateCustomer.BaseUserInfo.FullName;
        customerUser.Email = updateCustomer.BaseUserInfo.Email;
        customerUser.Age = updateCustomer.BaseUserInfo.Age;
        customerUser.Phone = updateCustomer.BaseUserInfo.Phone;
        customerUser.UpdatedAt = DateTime.UtcNow;
        return customerUser;
    }

    public static ReadCustomerUserInfo ToRead(this CustomerUser customerUser)
    {
        return new ReadCustomerUserInfo()
        {
            BaseUserInfo = new BaseUserInfo()
            {
                UserName = customerUser.UserName,
                FullName = customerUser.FullName,
                Email = customerUser.Email,
                Age = customerUser.Age,
                Phone = customerUser.Phone
            }
        };
    }

    public static CustomerUser ToDeleted(this CustomerUser customerUser)
    {
        customerUser.IsDeleted = true;
        customerUser.DeletedAt = DateTime.UtcNow;
        return customerUser;
    }
}