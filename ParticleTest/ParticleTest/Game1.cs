using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace ParticleTest
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont Font;
        Texture2D Pixel_tx;
        Util.FPS_METER FPS_METER = new Util.FPS_METER();
        ParticleGenerator Generator;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Font = Content.Load<SpriteFont>("Font");
            Pixel_tx = Content.Load<Texture2D>("Particle");
            Generator = new ParticleGenerator(Pixel_tx, new Vector2(200, 200), new Vector2(0, -2),2, 0.00001f,15);
            Generator.Event_Dodaj += ObjectMenager.Add;
            Generator.Event_Usun += ObjectMenager.Usun;
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            Generator.Update(gameTime);
            foreach (Particle obj in ObjectMenager.Obiekty)
            {
                obj.Update(gameTime);
            }
            ObjectMenager.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            Util.INPUT.Update();
            FPS_METER.Count();
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            foreach (Particle obj in ObjectMenager.Obiekty)
            {
                obj.Draw(spriteBatch);
            }
            spriteBatch.DrawString(Font, "FPS:" + FPS_METER.Get_Fps(), new Vector2(0, 0), Color.Black);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
