﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SliderAction
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        const int WIN_SIZE = 700;

        //クラス
        Camera camera;
        Title title;
        SlideGame slideGame;

        enum Scene
        { TITL, TUTO, GAME, RESU }
        Scene scene;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = WIN_SIZE;
            graphics.PreferredBackBufferHeight = WIN_SIZE;
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            camera = new Camera();
            title = new Title();
            slideGame = new SlideGame();
            Init();
            scene = Scene.TITL;
            base.Initialize();
        }
        void Init()
        {
            camera.Init(WIN_SIZE, WIN_SIZE);
            slideGame.Init(camera);
        }
        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            title.Load(Content);
            slideGame.Loads(Content);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            if (scene == Scene.TITL)
            {
                if (title.PushKey()) scene = Scene.GAME;
            }
            if (scene == Scene.TUTO)
            {

            }
            if (scene == Scene.GAME)
            {
                if (slideGame.Main()) { Init(); }
            }
            if (scene == Scene.RESU)
            {

            }


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin(SpriteSortMode.Deferred,
                              BlendState.AlphaBlend,
                              SamplerState.LinearClamp,
                              DepthStencilState.None,
                              RasterizerState.CullCounterClockwise,
                              null,
                              camera.GetMatrix());
            switch (scene)
            {
                case Scene.TITL:
                    title.Draw(spriteBatch);
                    break;
                case Scene.TUTO:
                    break;
                case Scene.GAME:
                    slideGame.Draw(spriteBatch);
                    break;
                case Scene.RESU:
                    break;
            }


            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
