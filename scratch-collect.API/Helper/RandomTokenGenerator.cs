using scratch_collect.Model.Enums;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace scratch_collect.API.Helper
{
    public class RandomTokenGenerator
    {
        internal static readonly char[] chars =
            "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();

        public string GetUniqueKey(int size)
        {
            byte[] data = new byte[4 * size];

            using (var crypto = RandomNumberGenerator.Create())
            {
                crypto.GetBytes(data);
            }

            StringBuilder result = new StringBuilder(size);

            for (int i = 0; i < size; i++)
            {
                var rnd = BitConverter.ToUInt32(data, i * 4);
                var idx = rnd % chars.Length;

                result.Append(chars[idx]);
            }

            return result.ToString();
        }

        public int GetRandomCouponValue()
        {
            Random random = new Random();

            var enumValues = Enum.GetValues(typeof(CouponValues))
            .Cast<CouponValues>()
            .Select(v => (int)v)
            .ToList();
            int randomIndex = random.Next(0, enumValues.Count);

            var value = enumValues[randomIndex];

            return value;
        }
    }
}