namespace InterviewZen
{
    public class OddPair
    {
        public readonly int First;
        public readonly int Second;

        public OddPair(int first,
                       int second)
        {
            First = first;
            Second = second;
        }

        protected bool Equals(OddPair other)
        {
            return (First == other.First && Second == other.Second) ||
                   (First == other.Second && Second == other.First);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((OddPair) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (First*397) ^ Second;
            }
        }

        public override string ToString()
        {
            return "[" + First + "," + Second + "]";
        }
    }
}