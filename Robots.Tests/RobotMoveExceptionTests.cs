using System;
using Machine.Specifications;
using Robots.Domains;
using Robots.Infrastructure;
using Robots.Services;

namespace Robots.Tests
{
    public class RobotMoveExceptionTests
    {
        public class Context
        {
            protected static Robot _robot;
            protected static Exception _exception;
            
        }

        [Subject(typeof(EndOfArenaException))]
        public class When_the_robot_reaches_the_top_end : Context
        {
            Establish context = () =>
            {
                _robot = new Robot(new Arena(5, 5), new Location(5, 5), "N", new Mover(), new Turner(), new InstructionsHandler());
            };

            Because of = () => _exception = Catch.Exception(() => _robot.Move());

            It should_raise_end_of_area_exception = () => _exception.ShouldBeAssignableTo<EndOfArenaException>();
        }

        [Subject(typeof(EndOfArenaException))]
        public class When_the_robot_reaches_the_bottom_end : Context
        {
            Establish context = () =>
            {
                _robot = new Robot(new Arena(5, 5), new Location(5, 0), "S", new Mover(), new Turner(), new InstructionsHandler());
            };

            Because of = () => _exception = Catch.Exception(() => _robot.Move());

            It should_raise_end_of_area_exception = () => _exception.ShouldBeAssignableTo<EndOfArenaException>();
        }
    
        [Subject(typeof(EndOfArenaException))]
        public class When_the_robot_reaches_the_left_end : Context
        {
            Establish context = () =>
            {
                _robot = new Robot(new Arena(5, 5), new Location(0, 1), "W", new Mover(), new Turner(), new InstructionsHandler());
            };

            Because of = () => _exception = Catch.Exception(() => _robot.Move());

            It should_raise_end_of_area_exception = () => _exception.ShouldBeAssignableTo<EndOfArenaException>();
        }

        [Subject(typeof(EndOfArenaException))]
        public class When_the_robot_reaches_the_right_end : Context
        {
            Establish context = () =>
            {
                _robot = new Robot(new Arena(5, 5), new Location(5, 1), "E", new Mover(), new Turner(), new InstructionsHandler());
            };

            Because of = () => _exception = Catch.Exception(() => _robot.Move());

            It should_raise_end_of_area_exception = () => _exception.ShouldBeAssignableTo<EndOfArenaException>();
        }

    }
}
