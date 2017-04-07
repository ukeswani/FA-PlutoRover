using System;

namespace PlutoRover
{
    public class Orientation : IOrientation
    {        
        public Orientation
                (
                     string name                    
                )
        {
            Name = name;
        }

        public String Name
        {
            private set;
            get;
        }

        public IOrientation Left
        {
            get;
            set;
        }

        public IOrientation Right
        {
            get;
            set;
        }
    }
}
