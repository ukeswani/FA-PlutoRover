namespace PlutoRover.Interfaces
{
    public interface ILocationManager
    {
        void MoveForward();

        void MoveBackward();

        string GetCurrentLocation();
    }
}
