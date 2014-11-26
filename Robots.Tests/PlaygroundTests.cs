using Machine.Specifications;

namespace Robots
{
    public class PlaygroundTests
    {
        [Subject("Playgroud")]
        public class When_the_ground_is_created
        {
            private static Ground _ground;
            private static int _width = 5;
            private static int _height = 5;
            
            Because of = () => _ground = new Ground(_width, _height);

            It should_have_set_the_correct_width = () => _ground.Width.ShouldEqual(_width);
            It should_have_set_the_correct_height = () => _ground.Width.ShouldEqual(_height);
        }
    }

}