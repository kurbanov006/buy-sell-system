
using Microsoft.AspNetCore.Mvc;

[Route("/api/customerusers/")]
public class CustomerUserController(ICustomerUserService service) : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateCustomerUserInfo createCustomer)
    => (await service.Create(createCustomer)).ToActionResult();

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    => (await service.Delete(id)).ToActionResult();

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] BaseFilter filter)
    => (await service.GetAll(filter)).ToActionResult();

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    => (await service.GetById(id)).ToActionResult();

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCustomerUserInfo updateCustomer)
    => (await service.Update(updateCustomer)).ToActionResult();
}