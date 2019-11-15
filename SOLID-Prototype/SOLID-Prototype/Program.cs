using System;
using System.Collections.Generic;
using static System.Console;

namespace SOLID_Prototype
{
    public class Person : ICloneable
    { 
        public string[] Names;
        public Address Address;

        public Person(string[] names, Address address)
        {
            if (names == null)
            {
                throw new ArgumentNullException(paramName: nameof(names));
            }
            if (address == null)
            {
                throw new ArgumentNullException(paramName: nameof(address));
            }
            Names = names;
            Address = address;
        }
        public override string ToString()
        {
            return $"{nameof(Names)}: {string.Join(" ", Names)}, {nameof(Address)}: {Address}";
        }

        public object Clone()
        {
            return new Person(Names,(Address) Address.Clone());
        }
    }
    public class Address : ICloneable
    {
        public string StreetName;
        public int HouseNumber;

        public Address(string streetName, int houseNumber)
        {
            if (StreetName == null)
            {
                throw new ArgumentNullException(paramName: nameof(streetName));
            }
            StreetName = streetName;
            HouseNumber = houseNumber;
        }
        public override string ToString()
        {
            return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
        }

        public object Clone()
        {
            return new Address(StreetName, HouseNumber);
        }
    }

    static class Program
    { 
        static void Main(string[] args)
        {
            var john = new Person(new[] { "John", "Smith" },
                new Address("London Road", 123));
            WriteLine(john);
        }
    }
}
