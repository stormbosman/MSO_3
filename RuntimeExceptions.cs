using System;

namespace mso_2
{
    // Thrown when attempting to move into an occupied/blocked cell
    public class BlockedCellException : Exception
    {
        public BlockedCellException() { }
        public BlockedCellException(string message) : base(message) { }
        public BlockedCellException(string message, Exception inner) : base(message, inner) { }
    }

    // Thrown when attempting to move outside the grid bounds
    public class OutOfBoundsException : Exception
    {
        public OutOfBoundsException() { }
        public OutOfBoundsException(string message) : base(message) { }
        public OutOfBoundsException(string message, Exception inner) : base(message, inner) { }
    }
}
