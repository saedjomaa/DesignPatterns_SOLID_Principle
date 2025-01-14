using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype_DP
{
    public class TheAddress : ICloneable
    {
        public readonly string StreetName;
        public int HouseNumber;

        public TheAddress(string streetName, int houseNumber)
        {
            StreetName = streetName;
            HouseNumber = houseNumber;
        }

        public override string ToString()
        {
            return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
        }

        public object Clone()
        {
            return new TheAddress(StreetName, HouseNumber);
        }
    }

    public class Person : ICloneable
    {
        public readonly string[] TheNames;
        public readonly TheAddress TheAddress;

        public Person(string[] TheNames, TheAddress TheAddress)
        {
            this.TheNames = TheNames;
            this.TheAddress = TheAddress;
        }

        public override string ToString()
        {
            return $"{nameof(TheNames)}: {string.Join(",", TheNames)}, {nameof(TheAddress)}: {TheAddress}";
        }

        public object Clone()
        {
            return new Person(TheNames, TheAddress);
        }
    }
}
