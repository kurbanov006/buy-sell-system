using Microsoft.AspNetCore.Mvc;

[Route("/api/deals/")]
public class DealController(IDealService service) : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateDealInfo deal)
    => (await service.Create(deal)).ToActionResult();

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
    public async Task<IActionResult> Update([FromBody] UpdateDealInfo deal)
    => (await service.Update(deal)).ToActionResult();
}