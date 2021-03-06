﻿using Machine.Specifications;
using Robots.Domains;
using Robots.Services;

namespace Robots
{
    public class RobotDirectionTests
    {
        public class Context
        {
            protected static Robot _robot;

            Establish context = () =>
            {
                _robot = new Robot(new Arena(5, 5), new Location(1, 1), "N", new Mover(), new Turner(), new InstructionsHandler());
            };
        }

        [Subject(typeof(Robot))]
        public class When_the_robot_is_created : Context
        {
            It should_set_the_initial_position_correctly = () => _robot.Location.ShouldEqual(new Location(1, 1));
            It should_set_the_heading_correctly = () => _robot.Heading.ShouldEqual("N");
        }

        [Subject(typeof(Robot))]
        public class When_the_robot_turns_to_left : Context
        {
            Because of = () => _robot.Turn("L");

            It should_turn_to_East = () => _robot.Heading.ShouldEqual("W");
        }

        [Subject(typeof(Robot))]
        public class When_the_robot_turns_to_right : Context
        {
            Because of = () => _robot.Turn("R");

            It should_turn_to_East = () => _robot.Heading.ShouldEqual("E");
        }

    }
}