﻿using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ZooObjektorienteretProgram
{
    internal class Money
    {
        private SoundEffect moneySound;
        public double moneyCount = 10;
        public int baseMoney = 10;
        public double MoneyCount { get => moneyCount; set => moneyCount = value; }


        public Money(ContentManager content)
        {
            

        }

        //add money
        public void AddMoney(float money)
        {
            moneyCount += money;
            //moneySound.Play();
        }

        //spend money
        public void SpendMoney(float money)
        {
            moneyCount -= money;
        }
    }
}
