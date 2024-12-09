using System; 
namespace PolskiPolakPL.Utils
{
    /// <summary>
    /// Timer class from tutorial extended by PolskiPolakPL. Tutorial link: 
    /// <seealso href="https://youtu.be/pRjTM3pzqDw"></seealso>
    /// </summary>
    public class Timer
    {
        /// <summary>
        /// Remaning time in seconds.
        /// </summary>
        public float RemaningSeconds { get; private set; }



        /// <summary>
        /// Time passed in seconds.
        /// </summary>
        public float SecondsPassed { get; private set; } = 0;



        private bool isLooping = false;

        /// <summary>
        /// Public getter of 'isLooping' boolean.
        /// </summary>
        public bool IsLooping
        {
            get { return isLooping; }
            set { isLooping = value; }
        }



        /// <summary>
        /// Timer Action Event invoked at the end of counting time.
        /// </summary>
        public event Action OnTimerEnd;



        private float duration;



        /// <param name="duration">Duration of the timer in seconds</param>
        public Timer(float duration)
        {
            this.duration = duration;
            RemaningSeconds = duration;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="duration">Duration of the timer in seconds</param>
        /// <param name="isLooping">Does timer loop over time?</param>
        public Timer(float duration, bool isLooping)
        {
            this.duration = duration;
            RemaningSeconds = duration;
            this.isLooping = isLooping;
        }



        /// <summary>
        /// Method used to move time one tick. Recommended use in <c>Update()</c> or <c>FixedUpdate()</c> methods.
        /// </summary>
        /// <param name="deltaTime">time difference between ticks</param>
        public void Tick(float deltaTime)
        {
            if(RemaningSeconds == 0)
            {
                if (isLooping)
                    RemaningSeconds = duration;
                return;
            }
            RemaningSeconds -= deltaTime;
            SecondsPassed += deltaTime;
            CheckForTimerEnd();
        }

        private void CheckForTimerEnd()
        {
            if(RemaningSeconds > 0)
                return;
            RemaningSeconds = 0;
            OnTimerEnd?.Invoke();
        }
    }
}
