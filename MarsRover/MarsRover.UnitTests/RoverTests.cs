using FluentAssertions;
using MarsRover.Abstractions;
using MarsRover.Models;

namespace MarsRover.UnitTests;

public class RoverTests
{
    [Fact]
    public void RoverGetStateMethod_Should_ReturnState()
    {
        // Arrange
        var expectedRoverState = new RoverState(0, 0, DirectionType.N);
        var rover = new Rover();

        //Act
        var actualRoverState = rover.GetState();
        
        //Assert
        actualRoverState.Should().BeEquivalentTo(expectedRoverState);
    }
    
    [Fact]
    public void RoverTurnLeftMethod_Should_TurnLeft_WhenCommandReceived()
    {
        // Arrange
        var expectedRoverState = new RoverState(0, 0, DirectionType.W);
        var rover = new Rover();
        
        //Act
        rover.TurnLeft();
        var actualRoverState = rover.GetState();

        //Assert
        actualRoverState.Should().BeEquivalentTo(expectedRoverState);
    }
    
    [Fact]
    public void RoverTurnRightMethod_Should_TurnRight_WhenCommandReceived()
    {
        // Arrange
        var expectedRoverState = new RoverState(0, 0, DirectionType.E);
        var rover = new Rover();
        
        //Act
        rover.TurnRight();
        var actualRoverState = rover.GetState();

        //Assert
        actualRoverState.Should().BeEquivalentTo(expectedRoverState);
    }
    
    [Theory]
    [InlineData(DirectionType.N, DirectionType.W)]
    [InlineData(DirectionType.W, DirectionType.S)]
    [InlineData(DirectionType.S, DirectionType.E)]
    [InlineData(DirectionType.E, DirectionType.N)]
    public void RoverTurnLeftMethod_Should_TurnLeftAccordingWithLatestDirection_WhenCommandReceived(DirectionType actualDirection, DirectionType expectedDirection)
    {
        // Arrange
        var rover = new Rover(new RoverState(0, 0, actualDirection));
        var expectedRoverState = new RoverState(0, 0, expectedDirection);

        //Act
        rover.TurnLeft();
        var actualRoverState =  rover.GetState();

        //Assert
        actualRoverState.Should().BeEquivalentTo(expectedRoverState);
    }
    
    [Theory]
    [InlineData(DirectionType.N, DirectionType.E)]
    [InlineData(DirectionType.E, DirectionType.S)]
    [InlineData(DirectionType.S, DirectionType.W)]
    [InlineData(DirectionType.W, DirectionType.N)]
    public void RoverTurnRightMethod_Should_TurnRightAccordingWithLatestDirection_WhenCommandReceived(DirectionType actualDirection, DirectionType expectedDirection)
    {
        // Arrange
        var rover = new Rover(new RoverState(0, 0, actualDirection));
        var expectedRoverState = new RoverState(0, 0, expectedDirection);

        //Act
        rover.TurnRight();
        var actualRoverState =  rover.GetState();

        //Assert
        actualRoverState.Should().BeEquivalentTo(expectedRoverState);
    }
    
    [Fact]
    public void RoverMoveMethod_Should_MoveOneStepInLongitudeIncreasingLatestLongitude_WhenCommandReceived_AndDirectionIsNorth()
    {
        // Arrange
        var expectedRoverState = new RoverState(0, 2, DirectionType.N);
        var rover = new Rover();

        //Act
        rover.Move();
        rover.Move();
        var actualRoverState = rover.GetState();

        //Assert
        actualRoverState.Should().BeEquivalentTo(expectedRoverState);
    }
    
    [Fact]
    public void RoverMoveMethod_Should_MoveOneStepInLongitude_WhenCommandReceived_AndDirectionIsNorth()
    {
        // Arrange
        var expectedRoverState = new RoverState(0, 1, DirectionType.N);
        var rover = new Rover();

        //Act
        rover.Move();
        var actualRoverState = rover.GetState();

        //Assert
        actualRoverState.Should().BeEquivalentTo(expectedRoverState);
    }
    
    [Fact]
    public void RoverMoveMethod_Should_MoveOneStepInLatitude_WhenCommandReceived_AndDirectionIsEast()
    {
        // Arrange
        var expectedRoverState = new RoverState(1, 0, DirectionType.E);
        var rover = new Rover();

        //Act
        rover.TurnRight();
        rover.Move();
        var actualRoverState = rover.GetState();

        //Assert
        actualRoverState.Should().BeEquivalentTo(expectedRoverState);
    }
    
    [Theory]
    [InlineData(0,1, DirectionType.E)]
    [InlineData(1, 0, DirectionType.W)]
    [InlineData(10, 10, DirectionType.E)]
    [InlineData(0, 0, DirectionType.W)]
    [InlineData(9, 10, DirectionType.E)]
    [InlineData(5, 4, DirectionType.W)]
    public void RoverMoveMethod_Should_MoveOneStepIncreasingOrDecreasingLatitudeAccordingWithDirection_WhenCommandReceived(int initialLatitude, int expectedLatitude, DirectionType direction)
    {
        // Arrange
        var rover = new Rover(new RoverState(initialLatitude, 0, direction));
        var expectedRoverState = new RoverState(expectedLatitude, 0, direction);

        //Act
        rover.Move();
        var actualRoverState = rover.GetState();

        //Assert
        actualRoverState.Should().BeEquivalentTo(expectedRoverState);
    }
    
    [Theory]
    [InlineData(0,1, DirectionType.N)]
    [InlineData(1, 0, DirectionType.S)]
    [InlineData(10, 10, DirectionType.N)]
    [InlineData(0, 0, DirectionType.S)]
    [InlineData(9, 10, DirectionType.N)]
    [InlineData(5, 4, DirectionType.S)]
    public void RoverMoveMethod_Should_MoveOneStepIncreasingOrDecreasingLongitudeAccordingWithDirection_WhenCommandReceived(int initialLongitude, int expectedLongitude, DirectionType direction)
    {
        // Arrange
        var rover = new Rover(new RoverState(0, initialLongitude, direction));
        var expectedRoverState = new RoverState(0, expectedLongitude, direction);

        //Act
        rover.Move();
        var actualRoverState = rover.GetState();

        //Assert
        actualRoverState.Should().BeEquivalentTo(expectedRoverState);
    }
}