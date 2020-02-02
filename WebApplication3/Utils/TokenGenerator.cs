using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Utils
{
    public class TokenGenerator
    {
        public static string generateToken()
        {
            byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
            byte[] key = Guid.NewGuid().ToByteArray();
            string token = Convert.ToBase64String(time.Concat(key).ToArray());
            return token;
        }

        public static bool checkIfTokenIsUpToDate(String token) {
            
            byte[] data = Convert.FromBase64String(token);
            DateTime when = DateTime.FromBinary(BitConverter.ToInt64(data, 0));
            if (when < DateTime.UtcNow.AddHours(-2))
            {
                return false;
            } else
            {
                return true;
            }
        }

        public static int getIdFromToken(string token) {
            return int.Parse(token.Substring(token.IndexOf("d2d")).Substring(3));
        }

        public static string getTokenWithoutId(string token)
        {
            return token.Substring(0, token.IndexOf("d2d"));
        }

       
    }
}
