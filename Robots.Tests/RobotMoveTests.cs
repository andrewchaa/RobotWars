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
            protected static Ground _ground;
            protected static Location _start;

            Establish context = () =>
            {
                _ground = new Ground(5, 5);
                _start = new Location(2, 2);
            };

        }

        [Subject(typeof (Robot))]
        public class When_the_robot_moves_to_north : Context
        {
            Establish context = () =>
            {
                _robot = new Robot(_ground, _start, "N");
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
                _robot = new Robot(_ground, _start, "S");
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
                _robot = new Robot(_ground, _start, "E");
            };

            Because of = () => _robot.Move();

            It should_move_on_X = () => _robot.Location.X.ShouldEqual(_start.X + 1);
            It should_stay_on_Y = () => _robot.Location.Y.ShouldEqual(_start.Y);
        }


    }
}