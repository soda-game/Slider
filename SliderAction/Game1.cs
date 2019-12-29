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
        Title title;
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
            title = new Title();
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
        void SliderInit()
        {
            slideGame = new SlideGame(camera, imageVo, soundVo.Reco, WIN_SIZE);
        }
        void ResultInit()
        {
            resultManager = new ResultManager(imageVo);
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
                case Scene.TITL:
                    if (titleManager.Main() != (int)OtherValue.MainTyep.NEXT) break;
                    TutoInit();
                    scene = Scene.TUTO;
                    break;
                case Scene.TUTO:
                    if (tutorialManager.Main() != (int)OtherValue.MainTyep.NEXT) break;
                        SliderInit();
                        scene = Scene.READY;
                    break;
                case Scene.READY:
                    if (!slideGame.ReadyAnime((int)ReadyUI.Type.READY)) break;
                    if (!slideGame.ReadyAnime((int)ReadyUI.Type.GO)) break;
                    scene = Scene.GAME;
                    break;
                case Scene.GAME:
                    int mgType = slideGame.Main();
                    if (mgType == (int)SlideGame.MainGameType.OVER) scene = Scene.OUT;
                    else if (mgType == (int)SlideGame.MainGameType.CLEAR) scene = Scene.GOAL;
                    break;
                case Scene.GOAL:
                    if (!slideGame.ReadyAnime((int)ReadyUI.Type.GOAL)) break;
                        scene = Scene.RESU;
                        ResultInit();
                    break;
                case Scene.OUT:
                    if (!slideGame.ReadyAnime((int)ReadyUI.Type.OUT)) break;
                        scene = Scene.READY;
                        SliderInit();
                    break;
                case Scene.RESU:
                    if (resultManager.Main() != (int)OtherValue.MainTyep.NEXT) break;
                        TitleInit();
                        scene = Scene.TITL;
                    break;
                default:
                    break;
>>>>>>> Stashed changes
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
                    title.Draw(spriteBatch);
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
