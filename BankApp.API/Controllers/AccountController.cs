using BankApp.Domain.Entities;
using BankApp.Persistence.Contexts;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

[ApiController]
[Route("api/[controller]")]
public class AccountsController : ControllerBase
{
    private readonly MongoDbContext _context;

    public AccountsController(MongoDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Account>>> Get()
    {
        return await _context.Accounts.Find(account => true).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Account>> Get(ObjectId Id)
    {
        var account = await _context.Accounts.Find<Account>(account => account.Id == Id).FirstOrDefaultAsync();
        if (account == null)
        {
            return NotFound();
        }
        return account;
    }

    [HttpPost]
    public async Task<ActionResult<Account>> Post(Account account)
    {
        await _context.Accounts.InsertOneAsync(account);    
        return CreatedAtAction(nameof(Get), new { id = account.Id }, account);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(ObjectId Id , Account accountIn)
    {
        var account = await _context.Accounts.Find<Account>(account => account.Id == Id).FirstOrDefaultAsync();
        if (account == null)
        {
            return NotFound();
        }

        await _context.Accounts.ReplaceOneAsync(account => account.Id == Id, accountIn);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(ObjectId Id)
    {
        var account = await _context.Accounts.Find<Account>(account => account.Id == Id).FirstOrDefaultAsync();
        if (account == null)
        {
            return NotFound();
        }

        await _context.Accounts.DeleteOneAsync(account => account.Id == Id);
        return NoContent();
    }
}
