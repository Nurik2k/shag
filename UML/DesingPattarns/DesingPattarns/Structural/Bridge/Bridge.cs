using System;
using System.Collections.Generic;
using System.Text;

namespace DesingPattarns.Structural.Bridge
{
    abstract class VideoDriver
    {
        public abstract void BrightnessUp();
        public abstract void BrightnessDown();
    }
    abstract class VideoControllerBridge
    {
        protected VideoDriver _imp;
        protected uint _light;
        public VideoControllerBridge()
        {
            _light = 0;
        }
        public abstract void BrightnessUp();
        public abstract void BrightnessDown();
    }
    class VideoDriverVer1_0 : VideoDriver
    {
        private readonly string vCardID = "Z6GH24#GJLW972GD";
        public override void BrightnessDown()
        {
            Console.WriteLine("Яркость снижена.");
        }
        public override void BrightnessUp()
        {
            Console.WriteLine("Яркость увеличилась.");
        }
        public string GetVersion()
        {
            return "Driver version 1.0, ID: " + vCardID;
        }
    }
    class VideoDriverVer1_1 : VideoDriver
    {
        private readonly string vCardID = "Z6GH24#GJLW972GD";
        private readonly string _version = "version 1.1";
        public override void BrightnessDown()
        {
            Console.WriteLine("Яркость снижена.");
        }
        public override void BrightnessUp()
        {
            Console.WriteLine("Яркость увеличилась.");
        }
        public string GetVersion()
        {
            return "Driver " + _version + ", ID: " + vCardID;
        }
    }
    class VideoController : VideoControllerBridge
    {
        public VideoController(VideoDriver obj)
        {
            base._imp = obj;
        }
        public override void BrightnessDown()
        {
            base._imp.BrightnessDown();
            --base._light;
        }
        public override void BrightnessUp()
        {
            base._imp.BrightnessUp();
            ++base._light;
        }
    }
    class Video
    {
        private VideoController _controller;
        public Video()
        {
            _controller = new VideoController(new VideoDriverVer1_0());
        }
        public void Light(uint value)
        {
           
            if (value > 0)
            {
                _controller.BrightnessUp();
            }
            else if (value < 0)
            {
                _controller.BrightnessDown();
            }
        }
    }
}
