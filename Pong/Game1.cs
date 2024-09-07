using System;
using System.Collections.Generic;
using System.Drawing;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pong.GameObjects;
using Color = Microsoft.Xna.Framework.Color;
using IDrawable = Pong.GameObjects.IDrawable;
using Point = Microsoft.Xna.Framework.Point;

namespace Pong
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private List<IDrawable> drawables;

        private GameObject leftPaddle;
        private GameObject rightPaddle;
        private GameObject ball;

        private Point ballVelocity = new();

        private int paddleSpeed = 5;

        public Game1()
        {
            drawables = new();

            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            var width = GraphicsDevice.Viewport.Width;
            var height = GraphicsDevice.Viewport.Height;

            leftPaddle = CreateSquare(new Point(25, 200));
            leftPaddle.Position = new Point(10, height / 2 - 100);

            rightPaddle = CreateSquare(new Point(25, 200));
            rightPaddle.Position = new Point(width - 35, height / 2 - 100);

            ball = CreateSquare(new Point(25, 25));
            ball.Position = new Point(width / 2 - 12, height / 2 - 12);

            ballVelocity = new Point(5, 2);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            var state = Keyboard.GetState();

            CheckForPaddleInput(state, leftPaddle, Keys.W, Keys.S, paddleSpeed);
            CheckForPaddleInput(state, rightPaddle, Keys.Up, Keys.Down, paddleSpeed);

            ball.Position += ballVelocity;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            
            _spriteBatch.Begin();

            foreach (var drawable in drawables)
            {
                drawable.Draw(_spriteBatch);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        protected GameObject CreateSquare(Point size)
        {
            var texture = new Texture2D(GraphicsDevice,  1,1);
            texture.SetData(new Color[] { Color.White });
            var square = new GameObject(texture, size);

            drawables.Add(square);

            return square;
        }

        private static void CheckForPaddleInput(KeyboardState state, GameObject go, Keys up, Keys down, int speed)
        {
            if (state.IsKeyDown(up))
            {
                go.Position = new Point(go.Position.X, go.Position.Y - speed);
            }
            else if (state.IsKeyDown(down))
            {
                go.Position = new Point(go.Position.X, go.Position.Y + speed);
            }
        }
    }
}
