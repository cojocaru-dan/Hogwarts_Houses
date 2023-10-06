using System;
using System.Linq;
using System.Text.Json;
using HogwartsHouses.Models;
using HogwartsHouses.Services;
using Microsoft.AspNetCore.Hosting.StaticWebAssets;
using Microsoft.AspNetCore.Mvc;


namespace HogwartsHouses.Controllers;
[ApiController]
public class RoomController : ControllerBase
{
    private readonly IRoomService _roomService;
    public RoomController(IRoomService roomService)
    {
        _roomService = roomService;
    }
    [HttpGet("/rooms")]
    public IActionResult GetAllRooms()
    {
        var allRooms = _roomService.GetAllRooms();
        if (!allRooms.Any()) return NotFound();
        return Ok(allRooms);
    }

    [HttpPost("/rooms")]
    public IActionResult PostRoom([FromBody] Room room)
    {
        _roomService.AddRoom(room);
        return Ok($"The room {room} was added successfully!");
    }

    [HttpGet("/rooms/{roomId}")]
    public IActionResult GetRoomById(int roomId)
    {
        Room roomById = _roomService.GetRoomById(roomId);
        if (roomById == null) return NotFound();
        return Ok(roomById);
    }

    [HttpDelete("/rooms/{roomId}")]
    public IActionResult DeleteRoomById(int roomId)
    {
        int deletedRooms = _roomService.DeleteRoomById(roomId);
        if (deletedRooms == 0) return NotFound();
        return Ok($"{deletedRooms} room{(deletedRooms > 1 ? "s" : "")} {(deletedRooms > 1 ? "were" : "was")} deleted with Id: {roomId}");
    }

    [HttpPut("/rooms/{roomId}")]
    public IActionResult UpdateRoomById(int roomId, [FromBody] Room newRoom)
    {
        if (roomId != newRoom.Id) 
        {
            throw new Exception("The id from the path must be equal to the id from the body!");
        }
        bool roomWasUpdated = _roomService.UpdateRoom(roomId, newRoom);
        if (!roomWasUpdated) return BadRequest($"Update operation failed! Check your data and try again!");
        return Ok($"The room with Id: {roomId} was updated successfully!");
    }

    [HttpGet("/rooms/available")]
    public IActionResult GetAvailableRooms()
    {
        var availableRooms = _roomService.GetAvailableRooms();
        if (availableRooms.Count == 0) return NotFound("There are no rooms available!");
        return Ok(availableRooms);
    }

    [HttpGet("/rooms/rat-owners")]
    public IActionResult GetSafeRooms()
    {
        var safeRooms = _roomService.GetSafeRooms();
        if (safeRooms.Count == 0) return NotFound("There are no safe rooms now!");
        return Ok(safeRooms);
    }
}