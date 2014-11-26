using Machine.Specifications;

namespace Robots
{
    public class RobotDirectionTests
    {
        public class Context
        {
            protected static Robot _robot;

            Establish context = () =>
            {
                _robot = new Robot(new Ground(5, 5), new Location(1, 1), "N");
            };
        }

        [Subject(typeof(Robot))]
        public class When_the_robot_is_created : Context
        {
            It should_set_the_position_x = () => _robot.Location.X.ShouldEqual(1);
            It should_set_the_position_Y = () => _robot.Location.X.ShouldEqual(1);
            It should_set_the_facing = () => _robot.Direction.ShouldEqual("N");
        }

        [Subject(typeof(Robot))]
        public class When_the_robot_turns_to_left : Context
        {
            Because of = () => _robot.Turn("L");

            It should_turn_to_East = () => _robot.Direction.ShouldEqual("W");
        }

        [Subject(typeof(Robot))]
        public class When_the_robot_turns_to_right : Context
        {
            Because of = () => _robot.Turn("R");

            It should_turn_to_East = () => _robot.Direction.ShouldEqual("E");
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