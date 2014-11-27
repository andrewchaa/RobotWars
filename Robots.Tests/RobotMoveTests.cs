using Machine.Specifications;
using Robots.Contracts;

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


            Establish context = () =>
            {
                _arena = new Arena(5, 5);
                _startX = 2;
                _startY = 2;
            };

        }

        [Subject(typeof (Robot))]
        public class When_the_robot_moves_to_north : Context
        {
            Establish context = () =>
            {
                _robot = new Robot(_arena, new Location(_startX, _startY), "N");
            };

            Because of = () => _robot.Move();

            It should_move_to = () => _robot.Location.ShouldEqual(new Location(_startX, _startY + 1));
        }

        [Subject(typeof (Robot))]
        public class When_the_robot_moves_to_south : Context
        {
            Establish context = () =>
            {
                _robot = new Robot(_arena, new Location(_startX, _startY), "S");
            };

            Because of = () => _robot.Move();

            It should_move_to = () => _robot.Location.ShouldEqual(new Location(_startX, _startY - 1));
        }

        [Subject(typeof (Robot))]
        public class When_the_robot_moves_to_east : Context
        {
            Establish context = () =>
            {
                _robot = new Robot(_arena, new Location(_startX, _startY), "E");
            };

            Because of = () => _robot.Move();

            It should_move_to = () => _robot.Location.ShouldEqual(new Location(_startX + 1, _startY));
        }


    }
}