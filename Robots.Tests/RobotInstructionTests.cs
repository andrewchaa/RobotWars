using Machine.Specifications;
using Robots.Contracts;

namespace Robots.Tests
{
    public class RobotInstructionTests
    {
        [Subject("Instruction")]
        public class Robot_1
        {
            private static IArena _arena;
            private static IRobot _robot;

            Establish context = () =>
            {
                _arena = new Arena(5, 5);
                _robot = new Robot(_arena, new Location(1, 2), "N");
            };

            Because of = () => _robot.Instructions("LMLMLMLMM");

            It should_move_to = () => _robot.Location.ShouldEqual(new Location(1, 3));
            It houlsd_head_to = () => _robot.Heading.ShouldEqual("N");
        }

        [Subject("Instruction")]
        public class Robot_2
        {
            private static IArena _arena;
            private static IRobot _robot;

            Establish context = () =>
            {
                _arena = new Arena(5, 5);
                _robot = new Robot(_arena, new Location(3, 3), "E");
            };

            Because of = () => _robot.Instructions("MMRMMRMRRM");

            It should_move_to = () => _robot.Location.ShouldEqual(new Location(5, 1));
            It houlsd_head_to = () => _robot.Heading.ShouldEqual("E");
        }


    }
}
