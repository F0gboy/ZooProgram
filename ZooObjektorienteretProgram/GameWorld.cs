using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ZooObjektorienteretProgram
{
    public class GameWorld : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Player _player;

        public GameWorld()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
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

        protected override void LoadContent()
        {
            

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
            _spriteBatch.Begin(samplerState: SamplerState.PointWrap);

            _player.DrawButtons(_spriteBatch);

            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}