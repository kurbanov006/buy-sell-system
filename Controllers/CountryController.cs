

using Microsoft.AspNetCore.Mvc;

[Route("/api/countries/")]
public class CountryController(ICountryService service) : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateCountryInfo country)
    => (await service.Create(country)).ToActionResult();

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
    public async Task<IActionResult> Update([FromBody] UpdateCountryInfo country)
    => (await service.Update(country)).ToActionResult();
}