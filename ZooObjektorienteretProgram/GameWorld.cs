using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace ZooObjektorienteretProgram
{
    public class GameWorld : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Money moneyManager;
        public SpriteFont moneyFont;
        private Money cash;
        private float elapsedSeconds;
        private float drainInterval = 1f;
        private Food___Water foodWaterObject;
        public GameWorld()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            cash = new Money(Content);
        }

        protected override void Initialize()
        {
            foodWaterObject = new Food___Water();
            // TODO: Add your initialization logic here
            
            



            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            moneyFont = Content.Load<SpriteFont>("Money");
            foodWaterObject.LoadContent(Content);
            //for (int i = 0; i < foodAndWater.Count; i++)
            //{
            //    foodAndWater[i].LoadContent(Content);

            //}

            //foreach (var foodandwater in foodAndWater)
            //{
            //    foodandwater.LoadContent(Content);
            //}

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            cash.AddMoney();
            cash.SpendMoney();
            // TODO: Add your update logic here
            elapsedSeconds += (float)gameTime.ElapsedGameTime.TotalSeconds;

            foodWaterObject.Update();

            if (elapsedSeconds >= drainInterval)
            {
                foodWaterObject.Drain();
                elapsedSeconds = 0; // Reset the elapsed time
            }
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            _spriteBatch.DrawString(moneyFont, $"Money: {cash.moneyCount}", Vector2.Zero, Color.Gold);

            
            
                foodWaterObject.Draw(gameTime, _spriteBatch);
            

            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
        
    }
}