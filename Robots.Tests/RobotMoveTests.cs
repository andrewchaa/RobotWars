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

            Establish context = () =>
            {
                _ground = new Ground(5, 5);
            };
        }

        [Subject(typeof (Robot))]
        public class When_the_robot_moves : Context
        {
            Establish context = () =>
            {
                var location = new Location(1, 1);
                _robot = new Robot(_ground, location, "N");
            };

            Because of = () => _robot.Move();

            It should_stay_on_X = () => _robot.Location.X.ShouldEqual(1);
            It should_move_on_Y = () => _robot.Location.Y.ShouldEqual(2);
        }

        [Subject(typeof (Robot))]
        public class When_the_robot_reached_the_end_of_the_ground_Y : Context
        {
            Establish context = () =>
            {
                var location = new Location(1, 5);
                _robot = new Robot(_ground, location, "N");
            };

            Because of = () => _robot.Move();

            It should_stay_on_X = () => _robot.Location.X.ShouldEqual(1);
            It should_come_to_the_starting_location_on_Y = () => _robot.Location.Y.ShouldEqual(1);
        }

        [Subject(typeof (Robot))]
        public class When_the_robot_reached_the_end_of_the_ground_X : Context
        {
            Establish context = () =>
            {
                var location = new Location(5, 3);
                _robot = new Robot(_ground, location, "E");
            };

            Because of = () => _robot.Move();

            It should_stay_on_X = () => _robot.Location.X.ShouldEqual(1);
            It should_come_to_the_starting_location_on_Y = () => _robot.Location.Y.ShouldEqual(3);
        }

        [Subject(typeof (Robot))]   
        public class When_the_robot_reached_the_start_of_the_ground_X : Context
        {
            Establish context = () =>
            {
                var location = new Location(1, 3);
                _robot = new Robot(_ground, location, "W");
            };

            Because of = () => _robot.Move();

            It should_go_to_the_end_of_the_ground_X = () => _robot.Location.X.ShouldEqual(5);
            It should_stay_the_same_on_Y = () => _robot.Location.Y.ShouldEqual(3);
        }

        [Subject(typeof (Robot))]   
        public class When_the_robot_reached_the_start_of_the_ground_Y : Context
        {
            Establish context = () =>
            {
                var location = new Location(2, 1);
                _robot = new Robot(_ground, location, "S");
            };

            Because of = () => _robot.Move();

            It should_stay_the_same_on_X = () => _robot.Location.X.ShouldEqual(2);
            It should_go_the_the_end_of_Y = () => _robot.Location.Y.ShouldEqual(5);
        }



    }
}