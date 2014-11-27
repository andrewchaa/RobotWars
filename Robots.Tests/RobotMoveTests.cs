using System.CodeDom;
using System.Security.Cryptography.X509Certificates;
using Machine.Specifications;

namespace Robots
{
    public class RobotMoveTests
    {
        public class Context
        {
            protected static Robot _robot;
            protected static Arena _arena;
            protected static Location _start;

            Establish context = () =>
            {
                _arena = new Arena(5, 5);
                _start = new Location(2, 2);
            };

        }

        [Subject(typeof (Robot))]
        public class When_the_robot_moves_to_north : Context
        {
            Establish context = () =>
            {
                _robot = new Robot(_arena, 2, 2, "N");
            };

            Because of = () => _robot.Move();

            It should_stay_on_X = () => _robot.Location.X.ShouldEqual(_start.X);
            It should_move_on_Y = () => _robot.Location.Y.ShouldEqual(_start.Y + 1);
        }

        [Subject(typeof (Robot))]
        public class When_the_robot_moves_to_south : Context
        {
            Establish context = () =>
            {
                _robot = new Robot(_arena, 2, 2, "S");
            };

            Because of = () => _robot.Move();

            It should_stay_on_X = () => _robot.Location.X.ShouldEqual(_start.X);
            It should_move_on_Y = () => _robot.Location.Y.ShouldEqual(_start.Y - 1);
        }

        [Subject(typeof (Robot))]
        public class When_the_robot_moves_to_east : Context
        {
            Establish context = () =>
            {
                _robot = new Robot(_arena, 2, 2, "E");
            };

            Because of = () => _robot.Move();

            It should_move_on_X = () => _robot.Location.X.ShouldEqual(_start.X + 1);
            It should_stay_on_Y = () => _robot.Location.Y.ShouldEqual(_start.Y);
        }


    }
}