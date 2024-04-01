using System;

/// <summary>
/// Nested SINGLETON CLASS via Class Nesting
/// A fully lazy instantiation of Singleton Objects
/// </summary>
public sealed class Singleton
{
    private Singleton()
    {
    }

    public static Singleton Instance { get { return Nested.instance; } }

    private class Nested
    {
        // Explicit static constructor
        static Nested()
        {
        }

        internal static readonly Singleton instance = new Singleton();
    }
}