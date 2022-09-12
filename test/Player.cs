using System;
using System.Timers;

namespace test
{
    public class Player
    {
        private static Texture2D rect;
        private int width;
        private int height;
        public int posX { get; set; }
        public int posY { get; set; }

        private int speedX = 0;
        private int speedY = 0;
        private int moveSpeedPerTick = 16;

        public MovingDir movingDir = MovingDir.IDLE;

        public Player(int posX, int posY, int width, int height)
        {
            this.posX = posX;
            this.posY = posY;
            this.height = height;
            this.width = width;

            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 100;
            aTimer.Enabled = true;
        }

        public void Draw(SpriteBatch batch, GraphicsDevice graphicsDevice) {

            if (rect == null)
            {
                rect = new Texture2D(graphicsDevice, 1, 1);
                rect.SetData(new[] { Color.White });
            }

            batch.Draw(rect, new Rectangle(posX, posY, width, height), Color.White);
	    }

        public void move(MovingDir movingDir) {

            switch(movingDir) {
                case MovingDir.LEFT:

                    if (this.movingDir != MovingDir.RIGHT)
                    {
                        this.movingDir = MovingDir.LEFT;
                    }

                    break;
                case MovingDir.RIGHT:
                    if (this.movingDir != MovingDir.LEFT)
                    {
                        this.movingDir = MovingDir.RIGHT;
                    }

                    break;
                case MovingDir.UP:

                    if (this.movingDir != MovingDir.DOWN)
                    {
                        this.movingDir = MovingDir.UP;
                    }

                    break;
                case MovingDir.DOWN:

                    if (this.movingDir != MovingDir.UP)
                    {
                        this.movingDir = MovingDir.DOWN;
                    }

                    break;
	        }
        }

        public void Update() {
            speedX = 0;
            speedY = 0;

            switch(movingDir) {
                case MovingDir.LEFT:
                    speedX = -moveSpeedPerTick;
                    break;
                case MovingDir.RIGHT:
                    speedX = moveSpeedPerTick;
                    break;
                case MovingDir.UP:
                    speedY = -moveSpeedPerTick;
                    break;
                case MovingDir.DOWN:
                    speedY = moveSpeedPerTick;
                    break;
	        }

            posX += speedX;
            posY += speedY;

            //Wrap player around screen

            if(posX > GameConf.SCREEN_WIDTH) {
                posX = 0;
	        }

            if(posX < 0)
            {
                posX = GameConf.SCREEN_WIDTH - width;
	        }

            if(posY > GameConf.SCREEN_HEIGHT) {
                posY = 0;
	        }

            if(posY < 0) {
                posY = GameConf.SCREEN_HEIGHT - height;
	        }
	    }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Console.WriteLine("Hello World!");
            Update();
        }
    }

    public enum MovingDir {
        LEFT, 
        RIGHT,
        UP,
        DOWN,
        IDLE
    }
}

