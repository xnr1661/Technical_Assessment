namespace Tests.UnitTests;

using Technical_Assessment.Application.Services.Abstractions;
using Technical_Assessment.Application.Services;
using Technical_Assessment.Application.Strategies.Abstractions;
using Technical_Assessment.Domain.Entities;
using Technical_Assessment.Domain.Enums;
using Moq;

public class RoverServiceTests
{
    private readonly Mock<IMovementStrategy> _forwardMovementStrategyMock = new Mock<IMovementStrategy>();
    private readonly Mock<IMovementStrategy> _backwardMovementStrategyMock = new Mock<IMovementStrategy>();
    private readonly Mock<IRotationStrategy> _leftRotationStrategyMock = new Mock<IRotationStrategy>();
    private readonly Mock<IRotationStrategy> _rightRotationStrategyMock = new Mock<IRotationStrategy>();

    private readonly IRoverService _roverService;

    public RoverServiceTests()
    {
        Setup();

        _roverService = new RoverService(
            [_forwardMovementStrategyMock.Object, _backwardMovementStrategyMock.Object],
            [_leftRotationStrategyMock.Object, _rightRotationStrategyMock.Object]);
    }

    [Theory]
    [InlineData("L")]
    [InlineData("R")]
    [InlineData("F")]
    [InlineData("B")]
    [InlineData("RBLFF")]
    public void RoverService_OnCommandExecution_ShouldCallStrategiesSpecificNumberOfTimes(string commands)
    {
        var rover = new Rover(0, 0, Direction.North);

        _roverService.ExecuteCommands(rover, commands);

        var commandCharsWithAmount = commands.ToCharArray().GroupBy(x => x);
        foreach (var command in commandCharsWithAmount)
        {
            switch (command.Key)
            {
                case 'L':
                    _leftRotationStrategyMock.Verify(strategy => strategy.IsApplicable(Movement.TurnLeft), Times.Exactly(command.Count()));
                    break;
                case 'R':
                    _rightRotationStrategyMock.Verify(strategy => strategy.IsApplicable(Movement.TurnRight), Times.Exactly(command.Count()));
                    break;
                case 'F':
                    _forwardMovementStrategyMock.Verify(strategy => strategy.IsApplicable(Movement.Forward), Times.Exactly(command.Count()));
                    break;
                case 'B':
                    _backwardMovementStrategyMock.Verify(strategy => strategy.IsApplicable(Movement.Backward), Times.Exactly(command.Count()));
                    break;
            }
        }
    }

    private void Setup()
    {
        _forwardMovementStrategyMock.Setup(strategy => strategy.IsApplicable(Movement.Forward)).Returns(true);
        _forwardMovementStrategyMock.Setup(strategy => strategy.IsApplicable(It.IsIn(Movement.TurnRight, Movement.TurnLeft, Movement.Backward))).Returns(false);

        _backwardMovementStrategyMock.Setup(strategy => strategy.IsApplicable(Movement.Backward)).Returns(true);
        _backwardMovementStrategyMock.Setup(strategy => strategy.IsApplicable(It.IsIn(Movement.TurnRight, Movement.TurnLeft, Movement.Forward))).Returns(false);

        _leftRotationStrategyMock.Setup(strategy => strategy.IsApplicable(Movement.TurnLeft)).Returns(true);
        _leftRotationStrategyMock.Setup(strategy => strategy.IsApplicable(It.IsIn(Movement.TurnRight, Movement.Forward, Movement.Backward))).Returns(false);

        _rightRotationStrategyMock.Setup(strategy => strategy.IsApplicable(Movement.TurnRight)).Returns(true);
        _rightRotationStrategyMock.Setup(strategy => strategy.IsApplicable(It.IsIn(Movement.Forward, Movement.TurnLeft, Movement.Backward))).Returns(false);
    }
}
