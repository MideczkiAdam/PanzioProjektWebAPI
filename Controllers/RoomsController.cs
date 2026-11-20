using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PanzioProjektWebAPI.Data;
using PanzioProjektWebAPI.DTOs;
using PanzioProjektWebAPI.Models;
using System.Linq.Expressions;

[Route("api/[controller]")]
[ApiController]
public class RoomsController : ControllerBase
{
    private readonly PanzioDbContext _context;
    public RoomsController(PanzioDbContext context)
    {
        _context = context;
    }
    private static readonly Expression<Func<Room, GetRoomDTO>> ToDto = r => new GetRoomDTO
    {
        Id = r.Id,
        Number = r.Number,
        Floor = r.Floor,
        IsActive = r.IsActive,
        RoomTypeId = r.RoomTypeId,
        RoomTypeName = r.RoomType.Name,
        Capacity = r.RoomType.Capacity,
        PricePerNight = r.RoomType.PricePerNight
    };

    private static IQueryable<Room> ApplySort(IQueryable<Room> query, string? sortBy, bool desc)
    {
        switch (sortBy?.ToLower())
        {
            case "floor":
                return desc ? query.OrderByDescending(r => r.Floor).ThenBy(r => r.Number)
                            : query.OrderBy(r => r.Floor).ThenBy(r => r.Number);
            case "capacity":
                return desc ? query.OrderByDescending(r => r.RoomType.Capacity).ThenBy(r => r.Number)
                            : query.OrderBy(r => r.RoomType.Capacity).ThenBy(r => r.Number);
            case "price":
                return desc ? query.OrderByDescending(r => r.RoomType.PricePerNight).ThenBy(r => r.Number)
                            : query.OrderBy(r => r.RoomType.PricePerNight).ThenBy(r => r.Number);
            default:
                return desc ? query.OrderByDescending(r => r.Number)
                            : query.OrderBy(r => r.Number);
        }
    }

    // GET: api/Room
    [HttpGet]
    public async Task<ActionResult<PagedResult<GetRoomDTO>>> GetRooms(
        [FromQuery] int Page = 1,
        [FromQuery] int PageSize = 10,
        [FromQuery] int? Floor = null,
        [FromQuery] string? RoomTypeName = null,
        [FromQuery] bool? IsActive = null,
        [FromQuery] DateTime? CheckIn = null,
        [FromQuery] DateTime? CheckOut = null,
        [FromQuery] int? Guests = null,
        [FromQuery] string? SortBy = null,
        [FromQuery] bool SortDesc = false
        )
    {
        if ((CheckIn == null) != (CheckOut == null))
        {
            return BadRequest("Szabad szoba kereséséhez az érkezés és a távozás napját is meg kell adni.");
        }

        var query = _context.Rooms.AsNoTracking().AsQueryable();

        if (Floor != null)
            query = query.Where(r => r.Floor == Floor);
        if (RoomTypeName != null)
            query = query.Where(r => r.RoomType.Name.ToLower() == RoomTypeName.ToLower());
        if (IsActive != null)
            query = query.Where(r => r.IsActive == IsActive);
        if (Guests != null)
            query = query.Where(r => r.RoomType.Capacity >= Guests);

        if (CheckIn != null && CheckOut != null)
        {
            var checkIn = CheckIn.Value;
            var checkOut = CheckOut.Value;

            if (checkOut <= checkIn)
            {
                return BadRequest("A távozás napjának az érkezés napja utáni napnak kell lennie.");
            }

            // Szabad időszakra csak aktív szoba kereshető, amire nincs átfedő, nem lemondott foglalás
            query = query
                .Where(r => r.IsActive)
                .Where(r => !r.Bookings.Any(b =>
                    b.Status != BookingStatus.Cancelled &&
                    b.CheckIn < checkOut &&
                    b.CheckOut > checkIn));
        }

        query = ApplySort(query, SortBy, SortDesc);

        var totalCount = await query.CountAsync();
        var items = await query
            .Skip((Page - 1) * PageSize)
            .Take(PageSize)
            .Select(ToDto)
            .ToListAsync();

        return new PagedResult<GetRoomDTO>
        {
            Items = items,
            TotalCount = totalCount,
            Page = Page,
            PageSize = PageSize
        };
    }

    // GET: api/Room/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Room>> GetRoom(int id)
    {
        var room = await _context.Rooms.FindAsync(id);

        if (room == null)
        {
            return NotFound();
        }

        return room;
    }

    // PUT: api/Room/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutRoom(int? id, Room room)
    {
        if (id != room.Id)
        {
            return BadRequest();
        }

        _context.Entry(room).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!RoomExists(id))
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

    // POST: api/Room
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Room>> PostRoom(Room room)
    {
        _context.Rooms.Add(room);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetRoom", new { id = room.Id }, room);
    }

    // DELETE: api/Room/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRoom(int? id)
    {
        var room = await _context.Rooms.FindAsync(id);
        if (room == null)
        {
            return NotFound();
        }

        _context.Rooms.Remove(room);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool RoomExists(int? id)
    {
        return _context.Rooms.Any(e => e.Id == id);
    }
}
