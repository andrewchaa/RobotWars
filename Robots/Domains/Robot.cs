﻿using Robots.Contracts;

namespace Robots.Domains
{
    public class Robot
    {
        public Location Location { get; set; }
        public string Heading { get; set; }

        private readonly Arena _arena;
        private readonly IMove _mover;
        private readonly ITurn _turner;
        private readonly IHandleInstructions _instructionHandler;

        public Robot(Arena arena, Location location, string heading, IMove mover, ITurn turner, 
            IHandleInstructions instructionHandler)
        {
            Location = new Location(location);
            Heading = heading;

            _arena = arena;
            _mover = mover;
            _turner = turner;
            _instructionHandler = instructionHandler;
        }

        public void Turn(string to)
        {
            Heading = _turner.Turn(Heading, to);
        }

        public void Move()
        {
            Location = new Location(_mover.Move(Heading, Location, _arena));
        }

        public void Handle(string commandString)
        {
            _instructionHandler.Handle(this, commandString);
        }
    }

}