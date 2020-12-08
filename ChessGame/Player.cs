namespace Chess
{
    public interface IPlayer
    {
        Color Color { get; }
    }
    
    public class WhitePlayer : IPlayer
    {
        public WhitePlayer()
        {
            Color = Color.White;
        }

        public Color Color { get; }
    }
    
    public class BlackPlayer : IPlayer
    {
        public BlackPlayer()
        {
            Color = Color.Black;
        }

        public Color Color { get; }

    }
    
}