using System;

namespace mcq_backend.Helper.Exception
{
    public class MatchmakingException : System.Exception
    {
        public MatchmakingState State { get; }
        public MatchmakingException(MatchmakingState state, string msg = "") : base(msg)
        {
            State = state;
        }
    }

    public enum MatchmakingState
    {
        JOIN_POOL,
        EMPTY_POOL,
        FIND_GAME,
    }
}