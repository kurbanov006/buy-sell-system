using Microsoft.AspNetCore.Mvc;

[Route("/api/products/")]
public class ProductController(IProductService service) : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateProductInfo product)
    => (await service.Create(product)).ToActionResult();

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
    public async Task<IActionResult> Update([FromBody] UpdateProductInfo product)
    => (await service.Update(product)).ToActionResult();
}