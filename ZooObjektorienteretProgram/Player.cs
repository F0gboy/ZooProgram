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
        private GraphicsDeviceManager graphicsDeviceManager;
        private AnimalSpawner AnimalSpawner;
        private Money cash;
        public SpriteFont font;
        private Button testButton;
        public List<Rectangle> rects;

        public List<Button> penButtons = new List<Button>(); 
   

        public Player(ContentManager content, SpriteBatch spriteBatch, AnimalSpawner animalSpawner, Money cash, SpriteFont font, List<Rectangle> Rects)
        {
            this.content = content;
            this.AnimalSpawner = animalSpawner;
            this.cash = cash;
            this.font = font;
            this.rects = Rects;
            //Test Button
            testButton = new Button(content);
            testButton.rect = new Rectangle(100,100,testButton.rect.Width, testButton.rect.Height);

            Random rnd = new Random();
            for (int i = 0; i < 9; i++)
            {
                string text = "";
                switch (i)
                {
                    case 0:
                        text = "Sheep - 5$";
                        break;

                        case 1:
                        text = "Pig - 10$";

                        break;

                        case 2:
                        text = "Cow - 15$";

                        break;


                        case 3:
                        text = "Chicken - 20$";

                        break; 
                    
                    case 4:
                        text = "Horse - 25$";
                        break; 
                    
                    case 5:
                        text = "Bunny - 30$";
                        break; 
                    
                    case 6: 
                        text = "Bull - 35$";

                        break;
                    
                    case 7:
                        text = "Fish - 40$";

                        break;
                    
                    case 8: 
                        text = "Duck - 50$";

                        break;
                    default:
                        break;
                }
                penButtons.Add(new SpawnButton(content, i, animalSpawner, cash, this, text, rects));
                penButtons[penButtons.Count - 1].rect = new Rectangle(rnd.Next(100, 750), rnd.Next(100, 700), penButtons[penButtons.Count - 1].rect.Width, penButtons[penButtons.Count - 1].rect.Height);
                
            }
            
            
        }

        public void MouseUpdate()
        {
            mouseState = Mouse.GetState();
            mousePosition = new Point(mouseState.X, mouseState.Y);


            foreach (SpawnButton button in penButtons)
            {
                if (button.rect.Contains(mousePosition) == true)
                {
                    button.color = Color.LightGray;
                    if (mouseState.LeftButton == ButtonState.Pressed && button.pressed == false)
                    {
                        button.Spawn(new Vector2(250, 250));
                        button.pressed = true;

                    }

                }
                else
                {
                    button.color = Color.White;
                }
                if (mouseState.LeftButton == ButtonState.Released)
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
