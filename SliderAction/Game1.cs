using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

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
        TitleManager titleManager;
        Tutorial tutorial;
        SlideGame slideGame;
        Result result;

        enum Scene
        { TITL, TUTO, GAME, RESU }
        Scene scene;

        Song bgm;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = WIN_SIZE;
            graphics.PreferredBackBufferHeight = WIN_SIZE;
            Content.RootDirectory = "Content";
            Window.Title = "すらいだー ver0.8";
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
            titleManager = new TitleManager();
            tutorial = new Tutorial();
            slideGame = new SlideGame();
            result = new Result();
            Init();
            MediaPlayer.IsRepeating = true;
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
            titleManager.Load(Content);

            tutorial.Load(Content);
            slideGame.Loads(Content);
            result.Load(Content);
            bgm = Content.Load<Song>("BGM");
            MediaPlayer.Play(bgm);
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

                if (titleManager.Main()) scene = Scene.TUTO; //ここで次のinitを呼ぶ
            }
            if (scene == Scene.TUTO)
            {
                if (tutorial.PushKey()) scene = Scene.GAME;
            }
            if (scene == Scene.GAME)
            {
                int i = slideGame.Main();
                if (i == 1) { Init(); }
                else if (i == 0)
                {
                    Init();
                    scene = Scene.RESU;
                }
            }
            if (scene == Scene.RESU)
            {
                if (result.PushKey()) scene = Scene.TITL;
            }


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

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
                    titleManager.Draw(spriteBatch,Vector2.Zero);
                    break;
                case Scene.TUTO:
                    tutorial.Draw(spriteBatch);
                    break;
                case Scene.GAME:
                    slideGame.Draw(spriteBatch);
                    break;
                case Scene.RESU:
                    result.Draw(spriteBatch);
                    break;
            }


            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
