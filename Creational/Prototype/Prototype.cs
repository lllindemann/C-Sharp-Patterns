using System;

namespace DesignPatterns.Prototype.Conceptual
{
    public class Prototype
    {
        public int Age;
        public DateTime BirthDate;
        public string Name;
        public IdInfo IdInfo;

        // reference values like IdNumber will change 
        // according to changes in Prototype Instance
        // a shallow copy creates a obj, but it does not create new copies of the elements within the obj. 
        // Instead, it points to the same elements as the original obj.
        public Prototype ShallowCopy()
        {
            return (Prototype) this.MemberwiseClone();
        }

        // Deep Copy will create a completely independent copy
        // A deep copy, creates a completely independent copy of both the object and its data. 
        // It does not share any data with the original obj.
        public Prototype DeepCopy()
        {
            Prototype clone = (Prototype) this.MemberwiseClone();
            clone.IdInfo = new IdInfo(IdInfo.IdNumber);
            clone.Name = String.Copy(Name);
            return clone;
        }
    }

    public class IdInfo
    {
        public int IdNumber;

        public IdInfo(int idNumber)
        {
            this.IdNumber = idNumber;
        }
    }

    class Example
    {
        static void Main(string[] args)
        {
            Prototype firstQuacker = new Prototype();
            firstQuacker.Age = 4;
            firstQuacker.BirthDate = Convert.ToDateTime("2020-06-01");
            firstQuacker.Name = "Mak Quack";
            firstQuacker.IdInfo = new IdInfo(100);

            // Perform a shallow copy offirstQuacker and assign it to firstQuackerCopy.
            Prototype firstQuackerCopy = firstQuacker.ShallowCopy();
            // Make a deep copy of firstQuacker and assign it to secondQuackerCopy.
            Prototype secondQuackerCopy = firstQuacker.DeepCopy();

            // Change the value of firstQuacker properties
            // Caused change of reference values of the ShallowCopy Instance firstQuackerCopy
            //IdNumber of firstQuackerCopy will change according to firstQuacker IdNumber
            // the DeepCopy Instance will not change
            firstQuacker.Age = 5;
            firstQuacker.BirthDate = Convert.ToDateTime("2019-07-01");
            firstQuacker.Name = "Maki";
            firstQuacker.IdInfo.IdNumber = 7878;
        }

    
    }
}