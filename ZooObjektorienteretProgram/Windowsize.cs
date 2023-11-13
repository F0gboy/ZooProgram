using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace ZooObjektorienteretProgram
{
    public class Windowsize : GameWorld
    {
        private GraphicsDeviceManager _deviceMNG;

        public Windowsize()
        {
            _deviceMNG = new GraphicsDeviceManager(this);
        }


        protected override void Initialize()

        {
            base.Initialize();


            _deviceMNG.PreferredBackBufferWidth = 1920;
            _deviceMNG.PreferredBackBufferHeight = 1280;
            _deviceMNG.IsFullScreen = false;
            _deviceMNG.ApplyChanges();


        }
    }
}