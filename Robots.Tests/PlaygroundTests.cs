using Machine.Specifications;
using Robots.Contracts;

namespace Robots
{
    public class PlaygroundTests
    {
        public class Context
        {
            protected static IArena _arena;
        }

        [Subject("Playgroud")]
        public class When_the_ground_is_created : Context
        {
            private static int _width = 5;
            private static int _height = 5;
            
            Because of = () => _arena = new Arena(_width, _height);

            It should_have_set_the_correct_width = () => _arena.Right.ShouldEqual(_width);
            It should_have_set_the_correct_height = () => _arena.Right.ShouldEqual(_height);
        }
    }

}