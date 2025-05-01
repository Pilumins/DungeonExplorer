using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonExplorer;

public class GameMap
{
    private Dictionary<string, Room> rooms;
    public GameMap()
    {
        rooms = new Dictionary<string, Room>();
    }

    public void AddRoom(string name, Room room)
    {
        rooms[name] = room;
    }
    public Room GetRoom(string name)
    {
        return rooms.ContainsKey(name) ? rooms[name] : null;
    }
    public IEnumerable<string> ListRoomNames()
    {
        return rooms.Keys;
    }
}