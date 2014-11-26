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

            Establish context = () =>
            {
                var location = new Location(1, 1);
                _robot = new Robot(location, "N");
            };
        }

        [Subject(typeof (Robot))]
        public class When_the_robot_moves : Context
        {
            Because of = () => _robot.Move();

            It should_stay_on_X = () => _robot.Location.X.ShouldEqual(1);
            It should_move_on_Y = () => _robot.Location.Y.ShouldEqual(2);
        }

    }
}