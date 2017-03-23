namespace PatientService.TestUtils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text;

    public static class Extensions
    {
        public static readonly Random random = new Random((int)DateTime.Now.Ticks);

        public static T RandomElement<T>(this IList<T> list)
        {
            return list[random.Next(list.Count)];
        }

        public static T RandomElement<T>(this T[] array)
        {
            return array[random.Next(array.Length)];
        }

        public static string CreateRandomString(int stringLength)
        {

            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < stringLength; i++)
            {
                ch = Convert.ToChar(random.Next(0x41, 0x5A));
                builder.Append(ch);
            }
            return builder.ToString().ToLower();
        }
        public static string CreateRandomInt(int intLength)
        {

            StringBuilder builder = new StringBuilder();
            int ch;
            for (int i = 0; i < intLength; i++)
            {
                ch = Convert.ToInt32(random.Next(0, 9));
                builder.Append(ch);
            }
            return builder.ToString().ToLower();
        }

        public static byte GetByteFromString(string text)
        {
            var textItems = text.Split('.');

            var textString = textItems.Aggregate(string.Empty, (current, item) => current + item);

            var byte1 = Encoding.ASCII.GetBytes(textString);

            return byte1.RandomElement();
        }
    }
}
