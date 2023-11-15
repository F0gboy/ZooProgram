
﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
﻿using ZooObjektorienteretProgram.States;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using Microsoft.Xna.Framework.Media;


namespace ZooObjektorienteretProgram
{

    public class GameWorld : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Money moneyManager;
        public SpriteFont moneyFont;
        private float elapsedSeconds;
        private float drainInterval = 1f;

        private Player _player;
        private AnimalSpawner _spawner;
        private Random rnd = new Random();
        private Money cash;

        private Food___Water foodWaterObject;
        
        private Rectangle tempRec;
        private Rectangle tempRec2;

        private AnimalBoundaries animalFence;
        private List<List<AnimalBoundaries>> fenceLists = new List<List<AnimalBoundaries>>();
        private List<AnimalBoundaries> allFences = new();
        public List<Rectangle> fenceRecs = new List<Rectangle>();
        public Texture2D whiteRectangle;
        private List<Food___Water> foodAndWaterObjects = new List<Food___Water>();

        int s = 0;

        private Vector2 fencePosition;
        private Vector2 fencePositionTemp;
        private int moveAmount = 45;

        private static Vector2 screenSize;
        public static Vector2 ScreenSize { get => screenSize; }

        private State _currentState;
        private State _nextState;
        public bool gameStarted = false;

        private Texture2D _backgroundMenuTexture;
        private Texture2D _backgroundTexture;
        private Vector2 _backgroundPosition;


        public GameWorld()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            cash = new Money(Content);

            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;
            //_graphics.IsFullScreen = true;

            screenSize = new Vector2(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);

            fencePosition.X = -850;
            fencePosition.Y = -400;

            for (int i = 0; i < 9; i++)
            {
                Rectangle fence1Rec = new Rectangle();
                fenceRecs.Add(fence1Rec);

                List<AnimalBoundaries> fenceTemp = new();
                fenceLists.Add(fenceTemp);
            }
        }
          
        public void ChangeState(State state)
        {
            _nextState = state;
        }

        protected override void Initialize()
        {

            for (int i = 0; i < 9; i++)
            {
                foodWaterObject = new Food___Water(tempRec);
                foodAndWaterObjects.Add(foodWaterObject);
            }
            

            // TODO: Add your initialization logic here

            //_graphics.IsFullScreen = true;
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _spawner = new AnimalSpawner(Content, cash);
            _player = new Player(Content, _spriteBatch, _spawner, cash, moneyFont, fenceRecs);

            IsMouseVisible = true;
            
            base.Initialize();
        }

        public void GenerateAnimalBoundaries(int boundarySizeX, int boundarySizeY, Vector2 position, int s)
        {
            //De hardcodede værdier som f.eks "position.y + 5" er fordi at sprite billederne er forskellige pixel størrelser, så skal rykke dem lidt så de liner op.

            //sætter inital fence, top venstre hjørne, og tilføjer til animalFence list.
            animalFence = new AnimalBoundaries(0, "TopLeftCorner", position.X + 5, position.Y + 0);
            allFences.Add(animalFence);
            fenceLists[s].Add(animalFence);

            int tempPos3 = boundarySizeY * 48;
            int tempPos2 = boundarySizeX * 48;

            moveAmount = 48;

            //laver den første side af fences

            for (int i = 0; i < boundarySizeY - 1; i++)
            {
                AnimalBoundaries fence = new AnimalBoundaries(2, "fenceY1" + (1 + i), position.X, position.Y + -5f + moveAmount);
                allFences.Add(fence);
                fenceLists[s].Add(fence);

                moveAmount += 48;
            }

            moveAmount = 0;

            //laver den næste side af fences

            for (int i = 0; i < boundarySizeX - 1; i++)
            {
                AnimalBoundaries fence = new AnimalBoundaries(3, "fenceX1" + (1 + i), position.X + moveAmount + 48, position.Y);
                allFences.Add(fence);
                fenceLists[s].Add(fence);
                moveAmount += 48;
            }

            //sætter næste corner fence

            AnimalBoundaries fenceCorner1 = new AnimalBoundaries(1, "TopRightCorner", position.X + tempPos2 - 6, position.Y);
            allFences.Add(fenceCorner1);
            fenceLists[s].Add(fenceCorner1);

            moveAmount = 40;

            //laver næste side af fences

            for (int i = 0; i < boundarySizeY - 1; i++)
            {
                AnimalBoundaries fence = new AnimalBoundaries(2, "fenceY2" + (1 + i),position.X + tempPos2 - 3, position.Y + moveAmount );
                allFences.Add(fence);
                fenceLists[s].Add(fence);
                moveAmount += 48;
            }

            //laver næste corner fence

            AnimalBoundaries fenceCorner2 = new AnimalBoundaries(4, "DownRightCorner", position.X + tempPos2 - 6, position.Y + tempPos3);
            allFences.Add(fenceCorner2);
            fenceLists[s].Add(fenceCorner2);

            moveAmount = 44;

            //laver sidste side af fences

            for (int i = 0; i < boundarySizeX - 1; i++)
            {
                AnimalBoundaries fence = new AnimalBoundaries(3, "fenceX1" + (1 + i), position.X + moveAmount + 4, position.Y + tempPos3 + 3);
                allFences.Add(fence);
                fenceLists[s].Add(fence);
                moveAmount += 48;
            }

            //laver sidste corner for at afslutte indhegningen.

            AnimalBoundaries fenceCorner3 = new AnimalBoundaries(5, "DownLeftCorner", position.X + 6, position.Y + tempPos3);
            allFences.Add(fenceCorner3);
            fenceLists[s].Add(fenceCorner3);

        }

        public void SpawnNextFence()
        {
            //Tjekker om fence positionen er ude fra skærmen, hvis den er, sæt den tilbage til start positionen, og ryk den en gang ned.
            //Hvis den ikke er ude fra skærmen, ryk den en gang til højre.

            s++;

            if (fencePosition.X > 500)
            {
                fencePosition.X = -650;
                tempRec.Y += 425;
                tempRec.X = 370;
                fenceRecs[s] = tempRec;
                fencePosition.Y += 425;
                tempRec2 = tempRec;
                tempRec2.X -= 45;

                GenerateAnimalBoundaries(6, 5, fencePosition, s);

                foodAndWaterObjects[s].rectangle = new Rectangle(tempRec2.X, tempRec2.Y - 60, (int)(tempRec2.Width / 1.5f), (int)(tempRec2.Height / 1.5f));
                foodAndWaterObjects[s].rectangle1 = new Rectangle(tempRec2.X + 155, tempRec2.Y - 60, (int)(tempRec2.Width / 1.5f), (int)(tempRec2.Height / 1.5f));

                for (int i = 0; i < 15; i++)
                {
                    _spawner.SpawnAnimal(s, fenceRecs);
                    _spawner.animals[i].rectangle = new Rectangle(tempRec.X, tempRec.Y, _spawner.animals[i].rectangle.Width, _spawner.animals[i].rectangle.Height);
                }
            }
            else
            {
                tempRec.X += 350;
                fenceRecs[s] = tempRec;

                tempRec2 = tempRec;
                tempRec2.Y -= 60;
                tempRec2.X -= 50;

                fencePosition.X += 350;
                GenerateAnimalBoundaries(6, 5, fencePosition, s);

                foodAndWaterObjects[s].rectangle = new Rectangle(tempRec2.X, tempRec2.Y , (int)(tempRec2.Width / 1.5f), (int)(tempRec2.Height / 1.5f));
                foodAndWaterObjects[s].rectangle1 = new Rectangle(tempRec2.X + 155, tempRec2.Y , (int)(tempRec2.Width / 1.5f), (int)(tempRec2.Height / 1.5f));

                for (int i = 0; i < 15; i++)
                {
                    _spawner.SpawnAnimal(s, fenceRecs);
                    _spawner.animals[i].rectangle = new Rectangle(tempRec.X, tempRec.Y, _spawner.animals[i].rectangle.Width, _spawner.animals[i].rectangle.Height);
                }
            }   
        }

        protected override void LoadContent()
        {
            moneyFont = Content.Load<SpriteFont>("Money");

            foreach (var foodAndWater in foodAndWaterObjects)
            {
                foodAndWater.LoadContent(Content);
            }

            GenerateAnimalBoundaries( 6, 5, fencePosition, s);


            tempRec.X = fenceRecs[0].X + 175;
            tempRec.Y = fenceRecs[0].Y + 200;
            tempRec.Width = 160;
            tempRec.Height = 120;
            fenceRecs[0] = tempRec;
            tempRec2 = tempRec;
            tempRec2.X -= 50;
            tempRec2.Y -= 60;

            foodAndWaterObjects[0].rectangle = new Rectangle(tempRec2.X, tempRec2.Y, (int)(tempRec2.Width / 1.5f), (int)(tempRec2.Height / 1.5f));
            foodAndWaterObjects[0].rectangle1 = new Rectangle(tempRec2.X + 155, tempRec2.Y, (int)(tempRec2.Width / 1.5f), (int)(tempRec2.Height / 1.5f));


            for (int i = 0; i < 15; i++)
            {
                _spawner.SpawnAnimal(0, fenceRecs);
                _spawner.animals[i].rectangle = new Rectangle(220, 220, _spawner.animals[i].rectangle.Width, _spawner.animals[i].rectangle.Height);
            }

            SpawnNextFence();
            SpawnNextFence();
            SpawnNextFence();
            SpawnNextFence();
            SpawnNextFence();
            SpawnNextFence();
            SpawnNextFence();
            SpawnNextFence();

            foreach (var fence in allFences) 
            {
                fence.LoadContent(Content);
            }
            foodWaterObject.LoadContent(Content);
            moneyFont = Content.Load<SpriteFont>("Money");
            _player.font = moneyFont;
            _player.Load(Content);
            _backgroundTexture = Content.Load<Texture2D>("GrassBackground");
            _backgroundMenuTexture = Content.Load<Texture2D>("ZooMenu");

            _currentState = new MenuState(this, _graphics.GraphicsDevice, Content, this);
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
           
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
			if (gameStarted == true)
            {
	            _player.MouseUpdate();
	            _spawner.AnimalUpdate();
            
	            elapsedSeconds += (float)gameTime.ElapsedGameTime.TotalSeconds;
	
	            foreach (var foodAndWater in foodAndWaterObjects)
	            {
	                foodAndWater.Update();
	            }

	            if (elapsedSeconds >= drainInterval)
	            {
	                foreach (var foodAndWater in foodAndWaterObjects)
	                {
	                    foodAndWater.Drain();
	                }
	                elapsedSeconds = 0; // Reset the elapsed time
	           	}
            }

            if (_nextState != null)
            {
                _currentState = _nextState;
                _nextState = null;
            }

            _currentState.Update(gameTime);
            _currentState.PostUpdate(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);

            Texture2D rect = new Texture2D(_graphics.GraphicsDevice, 150, 150);
            Color[] data = new Color[150 * 150];
            for (int i = 0; i < data.Length; ++i) data[i] = Color.Chocolate;
            rect.SetData(data);
            _spriteBatch.Draw(_backgroundMenuTexture, _backgroundPosition, Color.White);

            if (gameStarted == true)
            {
                _spriteBatch.Draw(_backgroundTexture, _backgroundPosition, Color.White);

                foreach (var fence in allFences)
                {
                    fence.Draw(_spriteBatch);
                }

                foreach (var foodAndWater in foodAndWaterObjects)
                {
                    foodAndWater.Draw(_spriteBatch);
                }

                _spawner.AnimalDraw(_spriteBatch);

                _spriteBatch.DrawString(moneyFont, $"Money: {cash.moneyCount}$", new Vector2(50, 50), Color.Gold);

                _player.DrawButtons(_spriteBatch);

            }
            _spriteBatch.End();


            _currentState.Draw(_spriteBatch);

            base.Draw(gameTime);

        }
    }
}