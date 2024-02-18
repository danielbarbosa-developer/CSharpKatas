using MarsRover.Abstractions;
using MarsRover.Models;

namespace MarsRover;

public class Rover : IRover
{
    private RoverState _roverState;

    public Rover()
    {
        _roverState = new RoverState(0, 0, DirectionType.N);
    }

    public Rover(RoverState roverState)
    {
        _roverState = roverState;
    }
    public RoverState GetState() => _roverState;

    public void TurnLeft()
    {
        _roverState.Direction = _roverState.Direction switch
        {
            DirectionType.N => DirectionType.W,
            DirectionType.W => DirectionType.S,
            DirectionType.S => DirectionType.E,
            DirectionType.E => DirectionType.N,
            _ => DirectionType.N
        };
    }

    public void TurnRight()
    {
        _roverState.Direction = _roverState.Direction switch
        {
            DirectionType.N => DirectionType.E,
            DirectionType.E => DirectionType.S,
            DirectionType.S => DirectionType.W,
            DirectionType.W => DirectionType.N,
            _ => DirectionType.N
        };
    }

    public void Move()
    {
        if (_roverState.Direction == DirectionType.N)
            IncreaseLongitude();
        else if (_roverState.Direction == DirectionType.S)
            DecreaseLongitude();
        else if(_roverState.Direction == DirectionType.E)
            IncreaseLatitude();
        else if (_roverState.Direction == DirectionType.W)
            DecreaseLatitude();
        
    }
    
    private void IncreaseLongitude()
    {
        if(_roverState.Longitude == 10)
            return;
        
        _roverState.Longitude += 1;
    }

    private void DecreaseLongitude()
    {
        if(_roverState.Longitude == 0)
            return;
        
        _roverState.Longitude -= 1;
    }

    private void IncreaseLatitude()
    {
        if(_roverState.Latitude == 10)
            return;
        
        _roverState.Latitude += 1;
    }
    
    private void DecreaseLatitude()
    {
        if(_roverState.Latitude == 0)
            return;
        
        _roverState.Latitude -= 1;
    }
    
}