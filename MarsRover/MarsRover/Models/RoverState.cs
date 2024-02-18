namespace MarsRover.Models;

public class RoverState
{
    public RoverState(int latitude, int longitude, DirectionType direction)
    {
        Latitude = latitude;
        Longitude = longitude;
        Direction = direction;
    }
    
    public int Latitude { get; set; }
    public int Longitude { get; set; }
    public DirectionType Direction { get; set; }
}