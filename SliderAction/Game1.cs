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
        ImageVo imageVo;
        SoundVo soundVo;
        TitleManager titleManager;
        TutorialManager tutorialManager;
        SlideGame slideGame;
        ResultManager resultManager;

        enum Scene
        { TITL, TUTO, READY, GAME, GOAL, OUT, RESU }
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
            Window.Title = "すらいだー ver0.8";

            MediaPlayer.IsRepeating = true;

            base.Initialize();
        }

        void TitleInit()
        {
            camera = new Camera(WIN_SIZE, WIN_SIZE);
            titleManager = new TitleManager(imageVo);
        }
        void TutoInit()
        {
            tutorialManager = new TutorialManager(imageVo);
        }
        void SliderInit()
        {
            slideGame = new SlideGame(camera, imageVo, soundVo.Reco,WIN_SIZE);
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
            imageVo = new ImageVo(Content);
            soundVo = new SoundVo(Content);
            TitleInit();
            MediaPlayer.Play(soundVo.Bgm);
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

            switch (scene)
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
                    if (resultManager.Main() == (int)OtherValue.MainTyep.NEXT)
                        TitleInit();
                    scene = Scene.TITL;
                    break;
                default:
                    break;
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
                    titleManager.MainDraw(spriteBatch, camera.localDiff);
                    break;
                case Scene.TUTO:
                    tutorialManager.MainDraw(spriteBatch, camera.localDiff);
                    break;
                case Scene.READY:
                case Scene.GOAL:
                case Scene.OUT:
                    slideGame.MainDraw(spriteBatch, camera.localDiff);
                    slideGame.ReadyDraw(spriteBatch, camera.localDiff);
                    break;
                case Scene.GAME:
                    slideGame.MainDraw(spriteBatch, camera.localDiff);
                    break;
                case Scene.RESU:
                    resultManager.MainDraw(spriteBatch, camera.localDiff);
                    break;
            }


            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
