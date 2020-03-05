using System;
using Newtonsoft.Json;
using System.IO;
using System.Windows.Media;


namespace RadioWPFApp
{
    public class Radio
    {
        private bool _on = false;
        private int _channel = 1;
        private string path = @"C:\Users\TECH-W024-BIRM\Desktop\lyrics\radiostate3.json";
        private int _volume = 50;
        MediaPlayer medp = new MediaPlayer();
        Uri path1 = new Uri(@"C:\Users\TECH-W024-BIRM\Desktop\mp3s\Tchaikovsky_Nocturne__orch.mp3");
        Uri path2 = new Uri(@"C:\Users\TECH-W024-BIRM\Desktop\mp3s\Haydn_Adagio.mp3");
        Uri path3 = new Uri(@"C:\Users\TECH-W024-BIRM\Desktop\mp3s\Bloch_Prayer.mp3");
        Uri path4 = new Uri(@"C:\Users\TECH-W024-BIRM\Desktop\mp3s\Beethoven_12_Variation.mp3");


        public int SavedChannel
        {
            get { return _channel; }
            set
            {
                    if (value > 0 && value <= 4)
                    {
                        _channel = value;
                    }
            }
        }



        public void Songs( int song)
        {
            if(song == 1 && _on)
            {
                medp.Open(path1);
                medp.Play();
            }
            if (song == 2 && _on)
            {
                medp.Open(path2);
                medp.Play();
            }
            if (song == 3 && _on)
            {
                medp.Open(path3);
                medp.Play();
            }
            if (song == 4 && _on)
            {
                medp.Open(path4);
                medp.Play();
            }
        }




        public int Channel { get { return _channel; }
            set
            {
                if (_on)
                {
                    if (value > 0 && value <= 4)
                    {
                        _channel = value;
                    }
                }
            }
        }

        public int SavedVolume
        {
            get { return _volume; }
            set
            {
        
                    _volume = value;
                
            }

        }

        public int Volume
        {
            get { return _volume; }
            set
            {
                if (_on && _volume > -1 && _volume < 101)
                {
                    _volume = value;
                }
                if(_volume == -1)
                {
                    _volume++;
                }
                if (_volume == 101)
                {
                    _volume--;
                }
            }
        }

        public void Write()
        {
            _channel = Channel;
            _volume = Volume;
            string output = JsonConvert.SerializeObject(this);

            File.WriteAllText(path, output);
        }

        public int Read()
        {
            string jsonFile = File.ReadAllText(path);
            Radio getInfo = JsonConvert.DeserializeObject<Radio>(jsonFile);
            SavedChannel = getInfo.Channel;
            SavedVolume = getInfo.Volume;
            return getInfo.Channel;
        }


        public void TurnOn()
        {
            _on = !_on;
            if(_on == false)
            {
                medp.Pause();
            }
            else
            {
                medp.Play();
            }
        }

        public string Play()
        {
            if (_on) return $"Playing channel {Channel}";
            else return "Radio is off";
        }

        public string VolPlay()
        {
            if (_on) return $"Volume {Volume}";
            else return "";
        }

        public void TurnOff()
        {
            _on = false;
        }
    }
 
}