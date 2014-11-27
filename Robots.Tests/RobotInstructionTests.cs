using Machine.Specifications;

namespace Robots.Tests
{
    public class RobotInstructionTests
    {
        [Subject("Instruction")]
        public class Robot_1
        {
            private static Arena _arena;
            private static Robot _robot;

            Establish context = () =>
            {
                _arena = new Arena(5, 5);
                _robot = new Robot(_arena, 1, 2, "N");
            };

            Because of = () => _robot.Instructions("LMLMLMLMM");

            It should_move_to_X_of = () => _robot.Location.X.ShouldEqual(1);
            It should_move_to_Y_of = () => _robot.Location.Y.ShouldEqual(3);
            It houlsd_head_to = () => _robot.Heading.ShouldEqual("N");
        }

        [Subject("Instruction")]
        public class Robot_2
        {
            private static Arena _arena;
            private static Robot _robot;

            Establish context = () =>
            {
                _arena = new Arena(5, 5);
                _robot = new Robot(_arena, 3, 3, "E");
            };

            Because of = () => _robot.Instructions("MMRMMRMRRM");

            It should_move_to_X_of = () => _robot.Location.X.ShouldEqual(5);
            It should_move_to_Y_of = () => _robot.Location.Y.ShouldEqual(1);
            It houlsd_head_to = () => _robot.Heading.ShouldEqual("E");
        }


    }
}
