using System;

namespace iQuest.TheUniverse.Infrastructure
{
    public class Either<TLeft, TRight>
    {
        private readonly TLeft _left;
        private readonly TRight _right;
        private readonly bool _isLeft;

        public Either(TLeft left)
        {
            _left = left;
            _isLeft = true;
        }

        public Either(TRight right)
        {
            _right = right;
            _isLeft = false;
        }
        
        public static implicit operator Either<TLeft, TRight>(TLeft left) => 
            new Either<TLeft, TRight>(left);

        public static implicit operator Either<TLeft, TRight>(TRight right) => 
            new Either<TLeft, TRight>(right);
        
        public T Match<T>(Func<TLeft, T> leftFunc, Func<TRight, T> rightFunc)
            => _isLeft ? leftFunc(_left) : rightFunc(_right);
    }
}