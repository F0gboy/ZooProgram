using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ZooObjektorienteretProgram.Controls;

namespace ZooObjektorienteretProgram.States
{
    public class MenuState : State
    {
        private List<Component> _components;
        private GameWorld _world;
        public MenuState(GameWorld game, GraphicsDevice graphicsDevice, ContentManager content, GameWorld world)
          : base(game, graphicsDevice, content)
        {
            var buttonTexture = _content.Load<Texture2D>("Button");
            var buttonFont = _content.Load<SpriteFont>("Font");
            _world = world;
            var newGameButton = new MenuButton(buttonTexture, buttonFont)
            {
                Position = new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width/2-75, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height/2-50 + 300),
                Text = "New Game",
            };

            newGameButton.Click += NewGameButton_Click;

            var loadGameButton = new MenuButton(buttonTexture, buttonFont)
            {
                Position = new Vector2(30000, 25000),
                Text = "Load Game",
            };

            loadGameButton.Click += LoadGameButton_Click;

            var quitGameButton = new MenuButton(buttonTexture, buttonFont)
            {
                Position = new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2 - 75, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2 + 50 + 300),
                Text = "Quit Game",
            };

            quitGameButton.Click += QuitGameButton_Click;

            _components = new List<Component>()
            {
                newGameButton,
                loadGameButton,
                quitGameButton,
            };
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            foreach (var component in _components)
                component.Draw(spriteBatch);

            spriteBatch.End();
        }

        private void LoadGameButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Load Game");
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            _world.gameStarted = true;
            _game.ChangeState(new GameState(_game, _graphicsDevice, _content));
            
        }

        public override void PostUpdate(GameTime gameTime)
        {
            // remove sprites if they're not needed
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in _components)
                component.Update(gameTime);
        }

        private void QuitGameButton_Click(object sender, EventArgs e)
        {
            _game.Exit();
        }
    }
}
