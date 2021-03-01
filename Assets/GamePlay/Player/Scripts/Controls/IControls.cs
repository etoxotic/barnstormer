namespace Player.Controls
{
    interface IControls
    {
        float roll { get;}
        float yaw { get;}
        float pitch { get;}
        float thrust { get;}
        bool gearsOut { get;}
        bool brake { get; }
    }
}
