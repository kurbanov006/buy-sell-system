using Microsoft.AspNetCore.Mvc;

[Route("/api/reviews/")]
public class ReviewController(IReviewService service) : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateReviewInfo review)
    => (await service.Create(review)).ToActionResult();

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
    public async Task<IActionResult> Update([FromBody] UpdateReviewInfo review)
    => (await service.Update(review)).ToActionResult();
}