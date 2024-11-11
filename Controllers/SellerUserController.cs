using Microsoft.AspNetCore.Mvc;

[Route("/zpi/sellerusers")]
public class SellerUserController(ISellerUserService service) : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateSellerUserInfo createSellerUser)
    => (await service.Create(createSellerUser)).ToActionResult();

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
    public async Task<IActionResult> Update([FromBody] UpdateSellerUserInfo sellerUserInfo)
    => (await service.Update(sellerUserInfo)).ToActionResult();
}