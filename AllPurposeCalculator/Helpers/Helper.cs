using AllPurposeCalculator.Entities;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllPurposeCalculator.Helpers
{
    public static class Helper
    {
        public static int GetSelectedOption<T>(string selectionStatement) where T : Enum
        {
            List<IdText> options = new List<IdText>();

            foreach (var item in Enum.GetValues(typeof(T)))
            {
                options.Add(new IdText
                {
                    Id = (int)item,
                    Text = ((Enum)item).GetDescription(),
                });
            }

            return GetSelectedOption(selectionStatement, options);
        }

        public static int GetSelectedOption(string selectionStatement, List<IdText> options)
        {
            foreach (var option in options)
            {
                Console.WriteLine($"{option.Text}: {option.Id}");
            }

            var isValid = false;
            int selectedOption = 0;

            Console.WriteLine(selectionStatement);

            while (!isValid)
            {
                var input = Console.ReadLine();

                if (int.TryParse(input, out selectedOption) && options.Select(x => x.Id).Contains(selectedOption))
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("Not a valid entry. Please select one of the entries above:");
                }
            }

            return selectedOption;
        }

        public static T Getinput<T>(string selectionStatement)
        {
            var isValid = false;
            var converter = TypeDescriptor.GetConverter(typeof(T));

            Console.WriteLine(selectionStatement);

            while (!isValid)
            {
                var input = Console.ReadLine();

                try
                {
                    if (converter != null)
                    {
                        return (T)converter.ConvertFromString(input);
                    }

                    Console.WriteLine("Not a valid entry. Please enter a valid value:");
                }
                catch (Exception)
                {
                    Console.WriteLine("Not a valid entry. Please enter a valid value:");
                }
            }

            return default(T);
        }

        public static List<string> GetEnumNames<T>() where T : Enum
        {
            List<string> names = new List<string>();

            foreach (string name in Enum.GetNames(typeof(T)))
            {
                names.Add(name);
            }

            return names;
        }

        public static List<int> GetEnumIds<T>() where T : Enum
        {
            List<int> values = new List<int>();

            foreach (int value in Enum.GetValues(typeof(T)))
            {
                values.Add(value);
            }

            return values;
        }
    }
}
