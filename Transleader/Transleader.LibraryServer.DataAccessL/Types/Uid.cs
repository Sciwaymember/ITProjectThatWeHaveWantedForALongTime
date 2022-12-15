using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Transleader.LibraryServer.DataAccessL.Types
{
    public readonly struct Uid
    {
        private Uid(string value)
        {
            if(Guid.TryParse(value, out Guid resultGuid) || int.TryParse(value, out int resultInt))
            {
                Value = value;
            }
            else
            {
                throw new FormatException("Uid can be guid or int");
            }
        }

        public Uid(Guid value)
        {
            Value = value.ToString();
        }

        public Uid(int value)
        {
            Value = value.ToString();
        }

        public readonly string Value { get; init; }

        public static Uid NewGuid()
        {
            return Parse(Guid.NewGuid());
        }

        public static Uid Parse(string input)
        {
            try
            {
                return new Uid(input);
            }
            catch
            {
                throw new FormatException();
            }
        }

        public static Uid Parse(int input)
        {
            return new Uid(input);
        }

        public static Uid Parse(Guid input)
        {
            return new Uid(input);
        }

        public override string ToString()
        {
            return Value;
        }

        public int ToInt()
        {
            try
            { 
                return Convert.ToInt32(Value);
            }
            catch
            {
                throw new FormatException();
            }
        }

        public Guid ToGuid()
        {
            try
            {
                return Guid.Parse(Value);
            }
            catch
            {
                throw new FormatException();
            }
        }
    }
}
