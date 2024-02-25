using System;
using System.Threading;

namespace Singleton
{
    // "Double Check Lock" Singleton implementation
    // Save in multithreaded environments
    // provides lazy initialization
    class Singleton
    {
        #region SINGLETON
        /// <summary>
        /// Constructor Singleton instance
        /// </summary>
        private Singleton() { }

        /// <summary>
        /// Singleton instance 
        /// must be static & private
        /// </summary>
        private static Singleton _instance;

        // Lock object
        private static readonly object _lock = new object();

        public static Singleton GetInstance(string value)
        {
            // prevent threads from creating new instance when one was already created
            if (_instance == null)
            {
                // when no Singleton instance is yet created, multiple threads can
                // simultaneously pass the previous conditional and reach this
                // point almost at the same time. The first of them will acquire
                // lock and will proceed further, while the rest will wait here.
                lock (_lock)
                {
                    // The first thread to acquire the lock, reaches this
                    // conditional, goes inside and creates the Singleton
                    // instance. Once it leaves the lock block, a thread that
                    // might have been waiting for the lock release may then
                    // enter this section. But since the Singleton field is
                    // already initialized, the thread won't create a new
                    // object.
                    if (_instance == null)
                    {
                        _instance = new Singleton();
                        _instance.Value = value;
                    }
                }
            }
            return _instance;
        }

        /// <summary>
        /// public value, which can be changed
        /// to show that Singleton works correctly
        /// </summary> 
        public string Value { get; set; }
        #endregion 
    }

    class Example
    {
        static void Main(string[] args)
        {
            //Creation of two Threads which init a Singleton
            Thread processOne = new Thread(() =>
            {
                ExampleSingleton("One");
            });
            Thread processTwo = new Thread(() =>
            {
                ExampleSingleton("Two");
            });

            processOne.Start();
            processTwo.Start();

            process1.Join();
            processOne.Join();
        }

        //Example Singleton Initialization 
        public static void ExampleSingleton(string value)
        {
            Singleton singleton = Singleton.GetInstance(value);
            Console.WriteLine(singleton.Value);
        }
    }
}