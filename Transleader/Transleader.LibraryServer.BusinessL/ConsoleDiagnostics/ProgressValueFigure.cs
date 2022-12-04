using Azure.Core;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transleader.LibraryServer.BusinessL.ConsoleDiagnostics
{
    public struct ProgressValueFigure
    {
        public string Field { get; set; }

        public string? Value { get; set; }

        public (int Left, int Top) Location { get; set; }

        public (int Left, int Top) ValueLocation { get; set; } = (0, 0);

        public int Size { get; set; }

        private string? clearField = "";

        public ProgressValueFigure(string field, in string? value, (int left, int top) location, int size)
        {
            Field = field;
            Value = value;
            Location = location;
            Size = size;
            Draw(Field + " :", (Location.Left, Location.Top));
            ValueLocation = Console.GetCursorPosition();
            Console.WriteLine("");
            DrawValue();
        }

        public void DrawValue()
        {
            (int left, int top) startCursorPosition = Console.GetCursorPosition();
            Draw(Value, (ValueLocation.Left, ValueLocation.Top));
            Console.SetCursorPosition(startCursorPosition.left, startCursorPosition.top);
        }

        private void Draw(string value, (int left, int top) location)
        {
            Console.SetCursorPosition(location.left, location.top);
            Console.Write(ClearField);
            Console.SetCursorPosition(location.left, location.top);
            Console.Write($" {value}");
        }

        private string ClearField
        {
            get
            {
                clearField = "";

                for (int i = 0; i < Size; i++)
                {
                    clearField += " ";
                }

                return clearField;
            }
        }
    }
}
