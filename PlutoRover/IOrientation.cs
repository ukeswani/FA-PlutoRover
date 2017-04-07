namespace PlutoRover
{
    public interface IOrientation
    {
        string Name
        {
            get;
        }

        IOrientation Left
        {
            get;
            set;
        }

        IOrientation Right
        {
            get;
            set;
        }
    }
}
