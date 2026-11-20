using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PanzioProjektWebAPI.Data;
using PanzioProjektWebAPI.DTOs;
using PanzioProjektWebAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class RoomTypesController : ControllerBase
{
    private readonly PanzioDbContext _context;
    public RoomTypesController(PanzioDbContext context)
    {
        _context = context;
    }

    // GET: api/RoomType
    [HttpGet]
    public async Task<PagedResult<GetRoomTypeDTO>> GetRoomType(
        [FromQuery] int Page = 1,
        [FromQuery] int PageSize = 10,
        [FromQuery] string? SortBy = null,
        [FromQuery] bool SortDesc = false
        )
    {
        var query = _context.RoomTypes.AsQueryable();

        if (SortBy?.ToLower() == "capacity")
            query = SortDesc ? query.OrderByDescending(r => r.Capacity) : query.OrderBy(r => r.Capacity);
        else if (SortBy?.ToLower() == "price")
            query = SortDesc ? query.OrderByDescending(r => r.PricePerNight) : query.OrderBy(r => r.PricePerNight);
        else
            query = SortDesc ? query.OrderByDescending(r => r.Name) : query.OrderBy(r => r.Name);

        var totalCount = await query.CountAsync();

        var items = await query 
            .Skip((Page - 1) * PageSize)
            .Take(PageSize)
            .Select(r => new GetRoomTypeDTO
            {
                Id = r.Id,
                Name = r.Name,
                Capacity = r.Capacity,
                PricePerNight = r.PricePerNight,
                Description = r.Description
            })
            .ToListAsync();

        return new PagedResult<GetRoomTypeDTO>
        {
            TotalCount = totalCount,
            Page = Page,
            PageSize = PageSize,
            Items = items
        };
    }

    // GET: api/RoomType/5
    [HttpGet("{id}")]
    public async Task<ActionResult<GetRoomTypeDTO>> GetRoomType(int id)
    {
        var roomtype = await _context.RoomTypes.Include(r => r.Rooms).FirstOrDefaultAsync(r => r.Id == id);

        var roomTypeDTO = new GetRoomTypeDTO
        {
            Id = roomtype.Id,
            Name = roomtype.Name,
            Capacity = roomtype.Capacity,
            PricePerNight = roomtype.PricePerNight,
            Description = roomtype.Description,
            Rooms = roomtype.Rooms.Select(r => new GetRoomDTO
            {
                Id = r.Id,
                Number = r.Number,
                Floor = r.Floor,
                RoomTypeId = r.RoomTypeId,
                IsActive = r.IsActive
            }).ToList()
        };

        if (roomtype == null)
        {
            return NotFound($"A(z) {id} azonosítójú szobatípus nem létezik.");
        }

        return roomTypeDTO;
    }

    // PUT: api/RoomType/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutRoomType(int? id, PutRoomTypeDTO roomtype)
    {
        if (id != roomtype.Id)
        {
            return BadRequest();
        }

        var existingRoomType = await _context.RoomTypes.FindAsync(id);

        if (existingRoomType == null)
        {
            return NotFound($"A(z) {id} azonosítójú szobatípus nem létezik.");
        }

        var name = roomtype.Name.Trim();

        if (await _context.RoomTypes.AnyAsync(r => r.Name == name && r.Id != id))
        {
            return Conflict($"Már létezik '{name}' nevű szobatípus.");
        }

        existingRoomType.Name = name;
        existingRoomType.Capacity = roomtype.Capacity;
        existingRoomType.PricePerNight = roomtype.PricePerNight;
        existingRoomType.Description = roomtype.Description;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!RoomTypeExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/RoomType
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<RoomType>> PostRoomType(PostRoomTypeDTO roomtype)
    {
        var name = roomtype.Name.Trim();

        if (await _context.RoomTypes.AnyAsync(r => r.Name == name))
        {
            return Conflict($"Már létezik '{name}' nevű szobatípus.");
        }

        var newRoomType = new RoomType
        {
            Name = name,
            Capacity = roomtype.Capacity,
            PricePerNight = roomtype.PricePerNight,
            Description = roomtype.Description
        };

        _context.RoomTypes.Add(newRoomType);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetRoomType", new { id = newRoomType.Id }, newRoomType);
    }

    // DELETE: api/RoomType/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRoomType(int? id)
    {
        var roomtype = await _context.RoomTypes.FindAsync(id);
        if (roomtype == null)
        {
            return NotFound();
        }

        _context.RoomTypes.Remove(roomtype);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool RoomTypeExists(int? id)
    {
        return _context.RoomTypes.Any(e => e.Id == id);
    }
}
