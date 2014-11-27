using Machine.Specifications;
using Robots.Domains;

namespace Robots.Tests
{
    public class ArenaTests
    {
        [Subject(typeof(Arena))]
        public class When_the_ground_is_created
        {
            private static Arena _arena;
            private static int _top = 5;
            private static int _right = 5;
            
            Because of = () => _arena = new Arena(_top, _right);

            It should_have_set_the_correct_top = () => _arena.Top.ShouldEqual(_top);
            It should_have_set_the_correct_bottom = () => _arena.Bottom.ShouldEqual(0);
            It should_have_set_the_correct_Right = () => _arena.Right.ShouldEqual(_right);
            It should_have_set_the_correct_Left = () => _arena.Left.ShouldEqual(0);
        }
    }

}