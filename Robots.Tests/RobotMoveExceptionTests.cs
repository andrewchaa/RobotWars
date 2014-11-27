using System;
using Machine.Specifications;
using Robots.Contracts;
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
            protected static IMove _mover;
            protected static ITurn _turner;
            protected static IHandleInstructions _instructionsHandler;
            protected static Arena _arena;

            Establish context = () =>
            {
                _mover = new Mover();
                _turner = new Turner();
                _instructionsHandler = new InstructionsHandler();
                _arena = new Arena(5, 5);
            };

        }

        [Subject(typeof(EndOfArenaException))]
        public class When_the_robot_reaches_the_top_end : Context
        {
            Establish context = () =>
            {
                _robot = new Robot(_arena, new Location(5, 5), "N", _mover, _turner, _instructionsHandler);
            };

            Because of = () => _exception = Catch.Exception(() => _robot.Move());

            It should_raise_end_of_area_exception = () => _exception.ShouldBeAssignableTo<EndOfArenaException>();
        }

        [Subject(typeof(EndOfArenaException))]
        public class When_the_robot_reaches_the_bottom_end : Context
        {
            Establish context = () =>
            {
                _robot = new Robot(_arena, new Location(5, 0), "S", _mover, _turner, _instructionsHandler);
            };

            Because of = () => _exception = Catch.Exception(() => _robot.Move());

            It should_raise_end_of_area_exception = () => _exception.ShouldBeAssignableTo<EndOfArenaException>();
        }
    
        [Subject(typeof(EndOfArenaException))]
        public class When_the_robot_reaches_the_left_end : Context
        {
            Establish context = () =>
            {
                _robot = new Robot(_arena, new Location(0, 1), "W", _mover, _turner, _instructionsHandler);
            };

            Because of = () => _exception = Catch.Exception(() => _robot.Move());

            It should_raise_end_of_area_exception = () => _exception.ShouldBeAssignableTo<EndOfArenaException>();
        }

        [Subject(typeof(EndOfArenaException))]
        public class When_the_robot_reaches_the_right_end : Context
        {
            Establish context = () =>
            {
                _robot = new Robot(_arena, new Location(5, 1), "E", _mover, _turner, _instructionsHandler);
            };

            Because of = () => _exception = Catch.Exception(() => _robot.Move());

            It should_raise_end_of_area_exception = () => _exception.ShouldBeAssignableTo<EndOfArenaException>();
        }

    }
}
