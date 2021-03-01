namespace Player.Gears
{
    interface IGears
    {
        bool gearsOut { set; }
        bool brakes { set; }
        bool thrust { set; }
        float turn { set; }
    }
}