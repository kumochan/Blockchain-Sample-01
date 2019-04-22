using Blockchain.First.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blockchain.First
{
    class Block
    {
        public String hash;
        public String previousHash;
        private String data; //our data will be a simple message.
        private long timeStamp; //as number of milliseconds since 1/1/1970.
        private int nonce = 0;

        //Block Constructor.
        public Block(String data, String previousHash)
        {
            this.data = data;
            this.previousHash = previousHash;
            this.timeStamp = DatetimeHandle.GetTime();
            this.hash = CalculateHash();
        }


        public String CalculateHash()
        {
            HashSha256 sha256 = new HashSha256();
            String calculatedhash = sha256.Hash(
                    previousHash +
                    timeStamp.ToString() +
                    nonce.ToString() + 
                    data);
            return calculatedhash;
        }

        public void MineBlock(int difficulty)
        {
            var str = new String(new char[difficulty]);
            String target = new String(new char[difficulty]).Replace('\0', '0'); //Create a string with difficulty * "0" 
            while (!hash.Substring(0, difficulty).Equals(target))
            {
                nonce++;
                hash = CalculateHash();
            }
            Console.WriteLine("Block Mined!!! : " + hash);
        }

    }
}
