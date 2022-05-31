using System;
using System.Security.Cryptography;
using System.Text;

namespace scratch_collect.API.Helper
{
    public class Password
    {
        public static string GenerateSalt()
        {
            var buf = new byte[16];
            new RNGCryptoServiceProvider().GetBytes(buf);

            return Convert.ToBase64String(buf);
        }

        public static string GenerateHash(string salt, string password)
        {
            var src = Convert.FromBase64String(salt);
            var bytes = Encoding.Unicode.GetBytes(password);
            var dst = new byte[src.Length + bytes.Length];

            Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            var algorithm = HashAlgorithm.Create("SHA1");
            if (algorithm == null) return null;

            var inArray = algorithm.ComputeHash(dst);

            return Convert.ToBase64String(inArray);
        }
    }
}