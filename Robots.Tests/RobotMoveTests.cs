using Machine.Specifications;
using Robots.Contracts;
using Robots.Domains;
using Robots.Services;

namespace Robots
{
    public class RobotMoveTests
    {
        public class Context
        {
            protected static Robot _robot;
            protected static Arena _arena;
            protected static int _startX;
            protected static int _startY;
            protected static Location _location;
            protected static IMove _mover;
            protected static ITurn _turner;
            protected static IHandleInstructions _instructionsHandler;

            Establish context = () =>
            {
                _arena = new Arena(5, 5);
                _startX = 2;
                _startY = 2;
                _location = new Location(_startX, _startY);
                _mover = new Mover();
                _turner = new Turner();
                _instructionsHandler = new InstructionsHandler();
            };

        }

        [Subject(typeof (Robot))]
        public class When_the_robot_moves_to_north : Context
        {
            Establish context = () =>
            {
                _robot = new Robot(_arena, _location, "N", _mover, _turner, _instructionsHandler);
            };

            Because of = () => _robot.Move();

            It should_move_to = () => _robot.Location.ShouldEqual(new Location(_startX, _startY + 1));
        }

        [Subject(typeof (Robot))]
        public class When_the_robot_moves_to_south : Context
        {
            Establish context = () =>
            {
                _robot = new Robot(_arena, _location, "S", _mover, _turner, _instructionsHandler);
            };

            Because of = () => _robot.Move();

            It should_move_to = () => _robot.Location.ShouldEqual(new Location(_startX, _startY - 1));
        }

        [Subject(typeof (Robot))]
        public class When_the_robot_moves_to_east : Context
        {
            Establish context = () =>
            {
                _robot = new Robot(_arena, _location, "E", _mover, _turner, _instructionsHandler);
            };

            Because of = () => _robot.Move();

            It should_move_to = () => _robot.Location.ShouldEqual(new Location(_startX + 1, _startY));
        }

        [Subject(typeof (Robot))]
        public class When_the_robot_moves_to_wast : Context
        {
            Establish context = () =>
            {
                _robot = new Robot(_arena, _location, "W", _mover, _turner, _instructionsHandler);
            };

            Because of = () => _robot.Move();

            It should_move_to = () => _robot.Location.ShouldEqual(new Location(_startX - 1, _startY));
        }


    }
}