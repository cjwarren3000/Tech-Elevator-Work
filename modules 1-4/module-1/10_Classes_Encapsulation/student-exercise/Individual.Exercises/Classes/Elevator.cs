namespace Individual.Exercises.Classes
{
    public class Elevator
    {
       public Elevator (int numberOfLevels)
        {
            NumberOfLevels = numberOfLevels;
            CurrentLevel = 1;
            DoorIsOpen = false;
        }

        public int NumberOfLevels
        {
            get;
        }

        public int CurrentLevel
        {
            get; private set;
        }

        public bool DoorIsOpen
        {
            get; private set;
        }

        public void OpenDoor()
        {
            DoorIsOpen = true;
        }

        public void CloseDoor()
        {
            DoorIsOpen = false;
        }

        public void GoUp(int desiredFloor)
        {
            if(DoorIsOpen == false && desiredFloor <= NumberOfLevels && desiredFloor > CurrentLevel)
            {
                CurrentLevel = desiredFloor;
            }
        }

        public void GoDown(int desiredFloor)
        {
            if (DoorIsOpen == false && desiredFloor >= 1 && desiredFloor < CurrentLevel)
            {
                CurrentLevel = desiredFloor;
            }
        }
    }

}
