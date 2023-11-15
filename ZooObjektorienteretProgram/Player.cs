using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ZooObjektorienteretProgram
{
    internal class Player
    {
        private Texture2D buttonSprite;
        private Point mousePosition;
        private MouseState mouseState;
        private bool pressed;
        private ContentManager content;
        GraphicsDeviceManager graphicsDeviceManager;
        AnimalSpawner AnimalSpawner;

        private Button testButton;



        public List<Button> penButtons = new List<Button>(); 
   

        public Player(ContentManager content, SpriteBatch spriteBatch, AnimalSpawner animalSpawner)
        {
            this.content = content;
            this.AnimalSpawner = animalSpawner;

            //Test Button
            testButton = new Button(content);
            testButton.rect = new Rectangle(100,100,testButton.rect.Width, testButton.rect.Height);

            Random rnd = new Random();
            for (int i = 0; i < 8; i++)
            {
                penButtons.Add(new SpawnButton(content, i + 1, animalSpawner));
                penButtons[penButtons.Count - 1].rect = new Rectangle(rnd.Next(100, 750), rnd.Next(100, 700), penButtons[penButtons.Count - 1].rect.Width, penButtons[penButtons.Count - 1].rect.Height);
            }
            
            
        }

        public void MouseUpdate()
        {
            mouseState = Mouse.GetState();
            mousePosition = new Point(mouseState.X, mouseState.Y);


            foreach (SpawnButton button in penButtons)
            {
                if (button.rect.Contains(mousePosition) == true && mouseState.LeftButton == ButtonState.Pressed && button.pressed == false)
                {

                    button.Spawn(new Vector2(250, 250));
                    button.pressed = true;

                }
                else if (mouseState.LeftButton == ButtonState.Released)
                {
                    button.pressed = false;



                }
            }
        }
        public void DrawButtons(SpriteBatch spriteBatch) 
        {
            foreach (var item in penButtons)
            {
                item.Draw(spriteBatch);
            }
        }

        public void Load(ContentManager content)
        {
            buttonSprite = content.Load<Texture2D>("Button");
            foreach (SpawnButton item in penButtons)
            {
                item.SetSprite(buttonSprite);
            }
        }
    }
}
