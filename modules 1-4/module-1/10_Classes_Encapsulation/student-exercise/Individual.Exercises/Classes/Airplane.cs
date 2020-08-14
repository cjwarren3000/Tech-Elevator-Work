namespace Individual.Exercises.Classes
{
    public class Airplane
    {
       public Airplane(string planeNumber, int totalFirstClassSeats, int totalCoachSeats)
        {
            PlaneNumber = planeNumber;
            TotalFirstClassSeats = totalFirstClassSeats;
            TotalCoachSeats = totalCoachSeats;
        }

        public string PlaneNumber
        {
            get; 
        }

        public int TotalFirstClassSeats
        {
            get;
        }

        public int BookedFirstClassSeats
        {
            get; private set;
        }
        
        public int AvailableFirstClassSeats
        {
            get
            {
                return TotalFirstClassSeats - BookedFirstClassSeats;
                
            }
        }

        public int TotalCoachSeats
        {
            get;
        }

        public int BookedCoachSeats
        {
            get; private set;
        }

        public int AvailableCoachSeats
        {
            get
            {
                return TotalCoachSeats - BookedCoachSeats;
            }
        }

        public bool ReserveSeats(bool forFirstClass, int totalNumberOfSeats)
        {
            if (forFirstClass && TotalFirstClassSeats >= totalNumberOfSeats)
            {
                BookedFirstClassSeats += totalNumberOfSeats;
                return true;
            }
            else if (forFirstClass == false && TotalCoachSeats >= totalNumberOfSeats)
            {
                BookedCoachSeats += totalNumberOfSeats;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
