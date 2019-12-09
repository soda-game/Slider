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
        AssetVo assetVo;
        TitleManager titleManager;
        TutorialManager tutorialManager;
        SlideGame slideGame;
        ResultManager resultManager;

        enum Scene
        { TITL, TUTO, GAME, RESU }
        Scene scene;

        Song bgm;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
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
            Window.Title = "すらいだー ver0.8";
            graphics.PreferredBackBufferWidth = WIN_SIZE;
            graphics.PreferredBackBufferHeight = WIN_SIZE;

            MediaPlayer.IsRepeating = true;
            scene = Scene.TITL;

            base.Initialize();
        }

        void TitleInit()
        {
            camera = new Camera(WIN_SIZE, WIN_SIZE);
            titleManager = new TitleManager(assetVo);
            tutorialManager = new TutorialManager(assetVo);
            slideGame = new SlideGame(camera);
            resultManager = new ResultManager(assetVo);
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
            assetVo = new AssetVo(Content);
            slideGame.Load(Content);
            //bgm = Content.Load<Song>("BGM");
            //MediaPlayer.Play(bgm);
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
                if (titleManager.Main() == (int)OtherValue.MainTyep.NEXT)
                    scene = Scene.TUTO; //ここで次のinitを呼ぶ
            }
            if (scene == Scene.TUTO)
            {
                if (tutorialManager.Main() == (int)OtherValue.MainTyep.NEXT)
                    scene = Scene.GAME;
            }
            if (scene == Scene.GAME)
            {
                int mgType = slideGame.Main();
                if (mgType == (int)SlideGame.MainGameType.OVER) slideGame.Init();
                else if (mgType == (int)SlideGame.MainGameType.CLEAR) scene = Scene.RESU;
            }
            if (scene == Scene.RESU)
            {
                if (resultManager.Main() == (int)OtherValue.MainTyep.NEXT)
                    scene = Scene.TITL;
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
                    titleManager.Draw(spriteBatch, camera.localDiff);
                    break;
                case Scene.TUTO:
                    tutorialManager.Draw(spriteBatch, camera.localDiff);
                    break;
                case Scene.GAME:
                    slideGame.Draw(spriteBatch, camera.localDiff);
                    break;
                case Scene.RESU:
                    resultManager.Draw(spriteBatch, camera.localDiff);
                    break;
            }


            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
