using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Blockchain.First.Utils
{
    class HashSha256 : StringHandle
    {
        public override string Hash(string strInput)
        {
            try
            {
                var crypt = new System.Security.Cryptography.SHA256Managed();
                var hash = new System.Text.StringBuilder();
                byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(strInput));
                foreach (byte theByte in crypto)
                {
                    hash.Append(theByte.ToString("x2"));
                }
                return hash.ToString();
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }
    }
}
