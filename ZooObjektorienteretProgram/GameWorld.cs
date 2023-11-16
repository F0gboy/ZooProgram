
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


            //instantiates Money class
            cash = new Money(Content);

            //Sets the screen options.
            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;
            _graphics.IsFullScreen = true;

            screenSize = new Vector2(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);

            //Sets the first fence position
            fencePosition.X = -850;
            fencePosition.Y = -400;

            //Creates 9 new rectangles and adds to FenceRecs list, so it can be used later.
            //Creates 9 new lists of fences, so fences can be sorted easier.
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
            //Creates 9 new Food And Water objects, and saves them in a list.
            for (int i = 0; i < 9; i++)
            {
                foodWaterObject = new Food___Water(tempRec, cash);
                foodAndWaterObjects.Add(foodWaterObject);
            }
            
            //Instantiates SpriteBatch, AnimalSpawner, and Player class.
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _spawner = new AnimalSpawner(Content, cash);
            _player = new Player(Content, _spriteBatch, _spawner, cash, moneyFont, fenceRecs);

            IsMouseVisible = true;
            
            base.Initialize();
        }

        public void GenerateAnimalBoundaries(int boundarySizeX, int boundarySizeY, Vector2 position, int s)
        {
            //The hardcodede values as "position.Y + 5" is because the sprite textures are different pixel sizes, so it has to be moved abit so they line up when drawn.

            //Sets initial fence, top left corner, and adds it to allFence list, and that particular pens fence list.
            animalFence = new AnimalBoundaries(0, "TopLeftCorner", position.X + 5, position.Y + 0);
            allFences.Add(animalFence);
            fenceLists[s].Add(animalFence);

            int tempPos3 = boundarySizeY * 48;
            int tempPos2 = boundarySizeX * 48;

            moveAmount = 48;

            //Creates the first side of fences.
            for (int i = 0; i < boundarySizeY - 1; i++)
            {
                AnimalBoundaries fence = new AnimalBoundaries(2, "fenceY1" + (1 + i), position.X, position.Y + -5f + moveAmount);
                allFences.Add(fence);
                fenceLists[s].Add(fence);

                moveAmount += 48;
            }

            moveAmount = 0;

            //Sets the next side of fences
            for (int i = 0; i < boundarySizeX - 1; i++)
            {
                AnimalBoundaries fence = new AnimalBoundaries(3, "fenceX1" + (1 + i), position.X + moveAmount + 48, position.Y);
                allFences.Add(fence);
                fenceLists[s].Add(fence);
                moveAmount += 48;
            }

            //Sets TopRightCorner fence.
            AnimalBoundaries fenceCorner1 = new AnimalBoundaries(1, "TopRightCorner", position.X + tempPos2 - 6, position.Y);
            allFences.Add(fenceCorner1);
            fenceLists[s].Add(fenceCorner1);

            moveAmount = 40;

            //Creates next side of fences
            for (int i = 0; i < boundarySizeY - 1; i++)
            {
                AnimalBoundaries fence = new AnimalBoundaries(2, "fenceY2" + (1 + i),position.X + tempPos2 - 3, position.Y + moveAmount );
                allFences.Add(fence);
                fenceLists[s].Add(fence);
                moveAmount += 48;
            }

            //Creates DownRightCorner fence.
            AnimalBoundaries fenceCorner2 = new AnimalBoundaries(4, "DownRightCorner", position.X + tempPos2 - 6, position.Y + tempPos3);
            allFences.Add(fenceCorner2);
            fenceLists[s].Add(fenceCorner2);

            moveAmount = 44;

            //Creates next side of fences
            for (int i = 0; i < boundarySizeX - 1; i++)
            {
                AnimalBoundaries fence = new AnimalBoundaries(3, "fenceX1" + (1 + i), position.X + moveAmount + 4, position.Y + tempPos3 + 3);
                allFences.Add(fence);
                fenceLists[s].Add(fence);
                moveAmount += 48;
            }

            //Creates Last DownLeftCorner to end the fence.
            AnimalBoundaries fenceCorner3 = new AnimalBoundaries(5, "DownLeftCorner", position.X + 6, position.Y + tempPos3);
            allFences.Add(fenceCorner3);
            fenceLists[s].Add(fenceCorner3);

        }

        public void SpawnNextFence()
        {
            //Checks if the fence position is outside of the screen, if it is, set its position back to the start position, and move it down to the next row of pens
            //If it isn't outside of the screen, move the fence right.

            //creates iteration value, so we can iterate through lists, and add a new position to the next thing in the list, based on the last value.
            s++;

            if (fencePosition.X > 500)
            {
                
                //Bit of a mess here, but essentially determines and keeps track of how much the object given should be moved to the right, or down.    
                //Keeps track of fence movement.
                fencePosition.X = -650;
                tempRec.Y += 425;
                tempRec.X = 370;

                //keeps track of fence collider/rectangle movement.
                fenceRecs[s] = tempRec;
                fencePosition.Y += 425;

                //keeps track of foodAndWater movement.
                tempRec2 = tempRec;
                tempRec2.X -= 45;

                //Sets the position of animal buy buttons.
                _player.penButtons[s].rect = new Rectangle(tempRec.X - 50,tempRec.Y + 225, tempRec2.Width,tempRec2.Height);

                //Generates next animal pen.
                GenerateAnimalBoundaries(6, 5, fencePosition, s);

                //Sets the position of food and water objects.
                foodAndWaterObjects[s].rectangle = new Rectangle(tempRec2.X, tempRec2.Y - 60, (int)(tempRec2.Width / 1.5f), (int)(tempRec2.Height / 1.5f));
                foodAndWaterObjects[s].rectangle1 = new Rectangle(tempRec2.X + 155, tempRec2.Y - 60, (int)(tempRec2.Width / 1.5f), (int)(tempRec2.Height / 1.5f));

            }
            else
            {
                //Keeps track of fence movement.
                tempRec.X += 350;
                fenceRecs[s] = tempRec;

                //Keeps track of foodAndWater movement.
                tempRec2 = tempRec;
                tempRec2.Y -= 60;
                tempRec2.X -= 50;

                fencePosition.X += 350;
                GenerateAnimalBoundaries(6, 5, fencePosition, s);

                //Sets the position of animal buy buttons.
                _player.penButtons[s].rect = new Rectangle(tempRec.X - 50, tempRec.Y + 225, tempRec2.Width, tempRec2.Height);

                //Sets the position of food and water objects.
                foodAndWaterObjects[s].rectangle = new Rectangle(tempRec2.X, tempRec2.Y , (int)(tempRec2.Width / 1.5f), (int)(tempRec2.Height / 1.5f));
                foodAndWaterObjects[s].rectangle1 = new Rectangle(tempRec2.X + 155, tempRec2.Y , (int)(tempRec2.Width / 1.5f), (int)(tempRec2.Height / 1.5f));

            }   
        }

        protected override void LoadContent()
        {
            //Loads the money font, and loads the food and water objects.
            moneyFont = Content.Load<SpriteFont>("Money");

            foreach (var foodAndWater in foodAndWaterObjects)
            {
                foodAndWater.LoadContent(Content);
            }

            GenerateAnimalBoundaries( 6, 5, fencePosition, s);

            //Sets the position of the first fence, and sets the position of the first food and water objects.
            tempRec.X = fenceRecs[0].X + 175;
            tempRec.Y = fenceRecs[0].Y + 200;
            tempRec.Width = 160;
            tempRec.Height = 120;
            fenceRecs[0] = tempRec;
            tempRec2 = tempRec;
            tempRec2.X -= 50;
            tempRec2.Y -= 60;

            //Sets the position of the first animal buy buttons.
            _player.penButtons[0].rect = new Rectangle(tempRec.X - 50, tempRec.Y + 225, tempRec2.Width, tempRec2.Height);

            //Sets the position of the first food and water objects.
            foodAndWaterObjects[0].rectangle = new Rectangle(tempRec2.X, tempRec2.Y, (int)(tempRec2.Width / 1.5f), (int)(tempRec2.Height / 1.5f));
            foodAndWaterObjects[0].rectangle1 = new Rectangle(tempRec2.X + 155, tempRec2.Y, (int)(tempRec2.Width / 1.5f), (int)(tempRec2.Height / 1.5f));

            //Spawns the 8 other fence pens, since the first one is set manually.
            for (int i = 0; i < 8; i++)
            {
                SpawnNextFence();
            }
            
            //Runs loadContent on Classes/Objects.
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
            
        }

        protected override void Update(GameTime gameTime)
        {
           
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //Checks if the game has started, if it has, run the game, if not, run the menu.
			if (gameStarted == true)
            {
	            _player.MouseUpdate();
	            _spawner.AnimalUpdate();
            
	            elapsedSeconds += (float)gameTime.ElapsedGameTime.TotalSeconds;
	
                //Updates the food and water objects.
	            foreach (var foodAndWater in foodAndWaterObjects)
	            {
	                foodAndWater.Update();
	            }

                //Drains the food and water objects.
	            if (elapsedSeconds >= drainInterval)
	            {
	                foreach (var foodAndWater in foodAndWaterObjects)
	                {
	                    foodAndWater.Drain(_spawner.animals);
	                }
                    foreach (Animal animal in _spawner.animals)
                    {
                        animal.Grow();
                    }
	                elapsedSeconds = 0; // Reset the elapsed time
	           	}

                //if the animal is too far away from its pen, move it back to the pen.
                foreach (Animal animal in _spawner.animals)
                {
                    if (Math.Abs(animal.center.X - animal.rectangle.X) > 260 || Math.Abs(animal.center.Y - animal.rectangle.Y) > 260)
                    {
                        animal.rectangle = new Rectangle(animal.center.X+(animal.center.Width/2)+rnd.Next(-60, 61), animal.center.Y+(animal.center.Height / 2)+rnd.Next(-60,61), animal.rectangle.Width, animal.rectangle.Height);
                    }
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

            _spriteBatch.Draw(_backgroundMenuTexture, _backgroundPosition, Color.White);

            //Draws the menu if the game hasn't started, if it has, draw the game and game background.
            if (gameStarted == true)
            {
                _spriteBatch.Draw(_backgroundTexture, _backgroundPosition, Color.White);

                //Draws all Fences, and all food and water objects.
                foreach (var fence in allFences)
                {
                    fence.Draw(_spriteBatch);
                }
                foreach (var foodAndWater in foodAndWaterObjects)
                {
                    foodAndWater.Draw(_spriteBatch);
                }

                _spawner.AnimalDraw(_spriteBatch);

                if (cash.moneyCount >= 0)
                {
                    _spriteBatch.DrawString(moneyFont, $"Money: {(int)cash.moneyCount}$", new Vector2(50, 50), Color.Gold);
                }
                else
                {
                    _spriteBatch.DrawString(moneyFont, $"Money: {(int)cash.moneyCount}$", new Vector2(50, 50), Color.Red);
                    if (cash.moneyCount < -500)
                    {
                        Exit();
                    }
                }
                

                _player.DrawButtons(_spriteBatch);

            }
            _spriteBatch.End();


            _currentState.Draw(_spriteBatch);

            base.Draw(gameTime);

        }
    }
}