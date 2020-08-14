namespace Individual.Exercises.Classes
{
    public class Television
    {
        bool isOn = false;
        int currentChannel = 3;
        int currentVolume = 2;

       public Television()
        {
            IsOn = isOn;
            CurrentChannel = currentChannel;
            CurrentVolume = currentVolume;
            
        }

        public bool IsOn
        {
            get; private set;
        }

        public int CurrentChannel
        {
            get; private set;
        }

        public int CurrentVolume
        {
            get; private set;
        }

        public void TurnOff()
        {
            if (IsOn)
            {
                IsOn = false;
            }

        }

        public void TurnOn()
        {
            if(IsOn == false)
            {
                IsOn = true;
            }
        }

        public void ChangeChannel(int newChannel)
        {
            if(IsOn && newChannel >= 3 && newChannel <= 18)
            {
                CurrentChannel = newChannel;
            }
            else
            {

            }
        }

        public void ChannelUp()
        {
            if (IsOn && CurrentChannel < 18)
            {
                CurrentChannel++;
            }
            else if(IsOn && CurrentChannel == 18)
            {
                CurrentChannel = 3;
            }
        }

        public void ChannelDown()
        {
            if(IsOn && CurrentChannel > 3)
            {
                CurrentChannel--;
            }
            else if(IsOn && CurrentChannel == 3)
            {
                CurrentChannel = 18;
            }
        }

        public void RaiseVolume()
        {
            if(IsOn && CurrentVolume < 10)
            {
                CurrentVolume++;
            }
        }

        public void LowerVolume()
        {
            if(IsOn && CurrentVolume > 0)
            {
                CurrentVolume--;
            }
        }

    }
}
