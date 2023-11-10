using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ZooObjektorienteretProgram
{
    public class GameWorld : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Player _player;

        private AnimalBoundaries animalFence;
        private List<AnimalBoundaries> fences = new();
        private Vector2 fencePosition;
        private int moveAmount = 45;

        private static Vector2 screenSize;
        public static Vector2 ScreenSize { get => screenSize; }

        public GameWorld()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            

            _graphics.PreferredBackBufferWidth = 1200;
            _graphics.PreferredBackBufferHeight = 800;

            screenSize = new Vector2(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);

            fencePosition.X = -250;
            fencePosition.Y = -250;
        }



        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _player = new Player(Content, _spriteBatch);
            base.Initialize();
<<<<<<< Updated upstream
=======

            
        }

        public void GenerateAnimalBoundaries(int boundarySizeX, int boundarySizeY, Vector2 position)
        {
            for (int i = 0; i < boundarySizeY - 1; i++)
            {
                AnimalBoundaries fence = new AnimalBoundaries(2, "fenceY1" + (1 + i), 0, -5 + moveAmount);
                fences.Add(fence);
                moveAmount += 48;
            }

            moveAmount = 0;

            for (int i = 0; i < boundarySizeX - 1; i++)
            {
                AnimalBoundaries fence = new AnimalBoundaries(3, "fenceX1" + (1 + i), moveAmount + 48, 0);
                fences.Add(fence);
                moveAmount += 48;
            }

            AnimalBoundaries fenceCorner1 = new AnimalBoundaries(1, "TopRightCorner", 230, 0);
            fences.Add(fenceCorner1);

            moveAmount = 40;

            for (int i = 0; i < boundarySizeY - 1; i++)
            {
                AnimalBoundaries fence = new AnimalBoundaries(2, "fenceY2" + (1 + i), 233, moveAmount);
                fences.Add(fence);
                moveAmount += 48;
            }

            AnimalBoundaries fenceCorner2 = new AnimalBoundaries(4, "DownRightCorner", 230, 230);
            fences.Add(fenceCorner2);

            moveAmount = 44;

            for (int i = 0; i < boundarySizeX - 1; i++)
            {
                AnimalBoundaries fence = new AnimalBoundaries(3, "fenceX1" + (1 + i), moveAmount, 233);
                fences.Add(fence);
                moveAmount += 48;
            }

            AnimalBoundaries fenceCorner3 = new AnimalBoundaries(5, "DownLeftCorner", 6, 230);
            fences.Add(fenceCorner3);

>>>>>>> Stashed changes
        }

        public void GenerateAnimalBoundaries(int boundarySizeX, int boundarySizeY, Vector2 position)
        {
            //De hardcodede værdier som f.eks "position.y + 5" er fordi at sprite billederne er forskellige pixel størrelser, så skal rykke dem lidt så de liner op.


            animalFence = new AnimalBoundaries(0, "TopLeftCorner", position.X + 5, position.Y + 0);
            fences.Add(animalFence);

            int tempPos3 = boundarySizeY * 48;
            int tempPos2 = boundarySizeX * 48;

            for (int i = 0; i < boundarySizeY - 1; i++)
            {
                AnimalBoundaries fence = new AnimalBoundaries(2, "fenceY1" + (1 + i), position.X, position.Y + -5f + moveAmount);
                fences.Add(fence);
                moveAmount += 48;
            }

            moveAmount = 0;

            for (int i = 0; i < boundarySizeX - 1; i++)
            {
                AnimalBoundaries fence = new AnimalBoundaries(3, "fenceX1" + (1 + i), position.X + moveAmount + 48, position.Y);
                fences.Add(fence);
                moveAmount += 48;
            }

            AnimalBoundaries fenceCorner1 = new AnimalBoundaries(1, "TopRightCorner", position.X + tempPos2 - 6, position.Y);
            fences.Add(fenceCorner1);

            moveAmount = 40;

            for (int i = 0; i < boundarySizeY - 1; i++)
            {
                AnimalBoundaries fence = new AnimalBoundaries(2, "fenceY2" + (1 + i),position.X + tempPos2 - 3, position.Y + moveAmount );
                fences.Add(fence);
                moveAmount += 48;
            }

            AnimalBoundaries fenceCorner2 = new AnimalBoundaries(4, "DownRightCorner", position.X + tempPos2 - 6, position.Y + tempPos3);
            fences.Add(fenceCorner2);

            moveAmount = 44;

            for (int i = 0; i < boundarySizeX - 1; i++)
            {
                AnimalBoundaries fence = new AnimalBoundaries(3, "fenceX1" + (1 + i), position.X + moveAmount + 4, position.Y + tempPos3 + 3);
                fences.Add(fence);
                moveAmount += 48;
            }

            AnimalBoundaries fenceCorner3 = new AnimalBoundaries(5, "DownLeftCorner", position.X + 6, position.Y + tempPos3);
            fences.Add(fenceCorner3);
        }


        protected override void LoadContent()
        {
            

           GenerateAnimalBoundaries( 5, 5, fencePosition);

            foreach (var fence in fences) 
            {
                fence.LoadContent(Content);
            }

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            _player.MouseUpdate();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);

            //animalFence.Draw(_spriteBatch);
            
            foreach (var fence in fences)
            {
                fence.Draw(_spriteBatch);
            }
            
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}