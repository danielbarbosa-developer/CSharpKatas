using MarsRover.Models;

namespace MarsRover.Abstractions;

public interface IRover
{
    RoverState GetState();
    void TurnLeft();
    void TurnRight();
    void Move();
}