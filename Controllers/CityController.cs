using Microsoft.AspNetCore.Mvc;

[Route("/api/cities/")]
public class CityController(ICityService service) : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateCityInfo city)
    => (await service.Create(city)).ToActionResult();

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
    public async Task<IActionResult> Update([FromBody] UpdateCityInfo city)
    => (await service.Update(city)).ToActionResult();
}