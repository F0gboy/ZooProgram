using ZooObjektorienteretProgram.States;
using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ZooObjektorienteretProgram
{

    public class GameWorld : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Player _player;
        private AnimalSpawner _spawner;
        private Random rnd = new Random();
        

        private AnimalBoundaries animalFence;
        private List<AnimalBoundaries> fences = new();
        private Vector2 fencePosition;
        private Vector2 fencePositionTemp;
        private int moveAmount = 45;

        private static Vector2 screenSize;
        public static Vector2 ScreenSize { get => screenSize; }

        private State _currentState;
        private State _nextState;
        
        public GameWorld()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;
            //_graphics.IsFullScreen = true;

            screenSize = new Vector2(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);

            fencePosition.X = -550;
            fencePosition.Y = -450;
        }

        public void ChangeState(State state)
        {
            _nextState = state;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            //_graphics.IsFullScreen = true;
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _player = new Player(Content, _spriteBatch);_spawner = new AnimalSpawner(Content);

            for (int i = 0; i < rnd.Next(10,25); i++)
            {
                _spawner.SpawnAnimal(rnd.Next(1, 10));
            }

            IsMouseVisible = true;
            
            base.Initialize();
        }

        public void GenerateAnimalBoundaries(int boundarySizeX, int boundarySizeY, Vector2 position)
        {
            //De hardcodede værdier som f.eks "position.y + 5" er fordi at sprite billederne er forskellige pixel størrelser, så skal rykke dem lidt så de liner op.

            //sætter inital fence, top venstre hjørne, og tilføjer til animalFence list.
            animalFence = new AnimalBoundaries(0, "TopLeftCorner", position.X + 5, position.Y + 0);
            fences.Add(animalFence);

            int tempPos3 = boundarySizeY * 48;
            int tempPos2 = boundarySizeX * 48;

            moveAmount = 48;

            //laver den første side af fences.

            for (int i = 0; i < boundarySizeY - 1; i++)
            {
                AnimalBoundaries fence = new AnimalBoundaries(2, "fenceY1" + (1 + i), position.X, position.Y + -5f + moveAmount);
                fences.Add(fence);
                moveAmount += 48;
            }

            moveAmount = 0;

            //laver den næste side af fences

            for (int i = 0; i < boundarySizeX - 1; i++)
            {
                AnimalBoundaries fence = new AnimalBoundaries(3, "fenceX1" + (1 + i), position.X + moveAmount + 48, position.Y);
                fences.Add(fence);
                moveAmount += 48;
            }

            //sætter næste corner fence

            AnimalBoundaries fenceCorner1 = new AnimalBoundaries(1, "TopRightCorner", position.X + tempPos2 - 6, position.Y);
            fences.Add(fenceCorner1);

            moveAmount = 40;

            //laver næste side af fences

            for (int i = 0; i < boundarySizeY - 1; i++)
            {
                AnimalBoundaries fence = new AnimalBoundaries(2, "fenceY2" + (1 + i),position.X + tempPos2 - 3, position.Y + moveAmount );
                fences.Add(fence);
                moveAmount += 48;
            }

            //laver næste corner fence

            AnimalBoundaries fenceCorner2 = new AnimalBoundaries(4, "DownRightCorner", position.X + tempPos2 - 6, position.Y + tempPos3);
            fences.Add(fenceCorner2);

            moveAmount = 44;

            //laver sidste side af fences

            for (int i = 0; i < boundarySizeX - 1; i++)
            {
                AnimalBoundaries fence = new AnimalBoundaries(3, "fenceX1" + (1 + i), position.X + moveAmount + 4, position.Y + tempPos3 + 3);
                fences.Add(fence);
                moveAmount += 48;
            }

            //laver sidste corner for at afslutte indhegningen.

            AnimalBoundaries fenceCorner3 = new AnimalBoundaries(5, "DownLeftCorner", position.X + 6, position.Y + tempPos3);
            fences.Add(fenceCorner3);
        }

        public void SpawnNextFence()
        {
            //Tjekker om fence positionen er ude fra skærmen, hvis den er, sæt den tilbage til start positionen, og ryk den en gang ned.
            //Hvis den ikke er ude fra skærmen, ryk den en gang til højre.

            if (fencePosition.X > 200)
            {
                fencePosition.X = -550;
                fencePosition.Y += 325;
                GenerateAnimalBoundaries(6, 5, fencePosition);
            }
            else
            {
                fencePosition.X += 400;
                GenerateAnimalBoundaries(6, 5, fencePosition);
            }
        }


        protected override void LoadContent()
        {
            GenerateAnimalBoundaries( 6, 5, fencePosition);

            foreach (var fence in fences) 
            {
                fence.LoadContent(Content);
            }
            //_backgroundTexture = Content.Load<Texture2D>("GrassBackground");

            _currentState = new MenuState(this, _graphics.GraphicsDevice, Content);
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            _player.MouseUpdate();
            _spawner.AnimalUpdate();
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

            _currentState.Draw(gameTime, _spriteBatch);

            // TODO: Add your drawing code here
            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);

            //animalFence.Draw(_spriteBatch);
            
            foreach (var fence in fences)
            {
                fence.Draw(_spriteBatch);
            }
            
            _spriteBatch.End();

            _spawner.AnimalDraw(_spriteBatch);

            base.Draw(gameTime);
        }
    }
}