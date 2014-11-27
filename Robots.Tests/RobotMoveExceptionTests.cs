using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Machine.Specifications;
using Robots.Contracts;

namespace Robots.Tests
{
    public class RobotMoveExceptionTests
    {
        [Subject(typeof(EndOfArenaException))]
        public class When_the_robot_reaches_the_top_end
        {
            private static Robot _robot;
            private static Exception _exception;

            Establish context = () =>
            {
                var arena = new Arena(5, 5);
                var location = new Location(5, 5);
                string heading = "N";

                _robot = new Robot(arena, location, heading);
            };

            Because of = () => _exception = Catch.Exception(() => _robot.Move());

            It should_raise_end_of_area_exception = () => _exception.ShouldBeAssignableTo<EndOfArenaException>();
        }
    }
}
