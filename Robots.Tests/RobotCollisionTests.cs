using System;
using System.Runtime.InteropServices;
using Machine.Specifications;
using Robots.Domains;
using Robots.Infrastructure;
using Robots.Services;

namespace Robots.Tests
{
    public class RobotCollisionTests
    {
        public class When_robots_collide_with_each_other
        {
            Establish context = () =>
            {
                var arena = new Arena(5, 5);
                _robot1 = new Robot(arena, new Location(1, 1), "N", new Mover(), new Turner(), new InstructionsHandler());
                _robot2 = new Robot(arena, new Location(2, 2), "W", new Mover(), new Turner(), new InstructionsHandler());
            };

            Because of = () =>
            {
                _robot1.Move();
                _exception = Catch.Exception(() => _robot2.Move());
            };

            It should_throw_collision_exception = () => _exception.ShouldBeOfExactType<RobotCollisionException>();

            private static Robot _robot1;
            private static Robot _robot2;
            private static Exception _exception;
        }
    }
}