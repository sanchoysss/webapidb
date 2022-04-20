using Microsoft.AspNetCore.Mvc;

namespace webapidb.Controllers;

[ApiController]
[Route("api/v1/creditors")]
public class CreditController : ControllerBase {

    private readonly CreditDB db;

    public CreditController(CreditDB db) {
        this.db =db;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllCredits() {
        var Credits = await db.FindAsync<Credit>();
        return Ok(Credits);
    }

    [HttpGet(Name = "${id:int:min(1)}")]
    public async Task<IActionResult> GetCreditById(int id) {
        return await db.Credits.FindAsync(id)
        is Credit credit
        ? Ok(credit)
        : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> AddCredit([FromBody] Credit credit) {
         db.Credits.Add(credit);
        await db.SaveChangesAsync();

    return Ok(credit.Id);
    }

    [HttpPut("{id:int:min(1)}")]
    public async Task<IActionResult> EditCredit(int Id, [FromBody] Credit credit) {
        if (credit.Id != Id) {
            return BadRequest();
        }

        var creditFromDb = await db.Credits.FindAsync(Id);

        if (creditFromDb is null) return NotFound();

        creditFromDb.Customer = credit.Customer;
        creditFromDb.amountOfCredit = credit.amountOfCredit;
        creditFromDb.percentPerYear = credit.percentPerYear;
        creditFromDb.startDate = credit.startDate;
        creditFromDb.endDate = credit.endDate;
        creditFromDb.moneyPayed = credit.moneyPayed;

        await db.SaveChangesAsync();

        return Ok(creditFromDb);
    }

    [HttpDelete("{id:int:min(1)}")]
    public async Task<IActionResult> DeleteCredit(int Id) {
        var Creditor = await db.Credits.FindAsync(Id);
        if (Creditor != null) {
            db.Credits.Remove(Creditor);

            await db.SaveChangesAsync();
        }

        return NoContent();
    }
}