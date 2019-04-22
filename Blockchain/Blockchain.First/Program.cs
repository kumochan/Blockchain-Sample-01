using Blockchain.First.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * author: thaotrinh.info
 * blockchain simple example 
 */
namespace Blockchain.First
{
    class Program
    {
        public static List<Block> blockchain = new List<Block>();
        public static int difficulty = 5;

        static void Main(string[] args)
        {

            blockchain.Add(new Block("Hi im the first block", "0"));
            Console.WriteLine("Trying to Mine block 1... ");
            blockchain.ElementAt(0).MineBlock(difficulty);

            blockchain.Add(new Block("Yo im the second block", blockchain.ElementAt(blockchain.Count - 1).hash));
            Console.WriteLine("Trying to Mine block 2... ");
            blockchain.ElementAt(blockchain.Count - 1).MineBlock(difficulty);

            blockchain.Add(new Block("Hey im the third block", blockchain.ElementAt(blockchain.Count - 1).hash));
            Console.WriteLine("Trying to Mine block 3... ");
            blockchain.ElementAt(blockchain.Count - 1).MineBlock(difficulty);

            Console.WriteLine("\nBlockchain is Valid: " + IsChainValid());

            string printBlockChain = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(blockchain);
            Console.WriteLine(printBlockChain);

            Console.ReadLine();
        }


        public static Boolean IsChainValid()
        {
            Block currentBlock;
            Block previousBlock;

            //loop through blockchain to check hashes:
            for (int i = 1; i < blockchain.Count; i++)
            {
                currentBlock = blockchain.ElementAt(i);
                previousBlock = blockchain.ElementAt(i - 1);

                //compare registered hash and calculated hash:
                if (!currentBlock.hash.Equals(currentBlock.CalculateHash()))
                {
                    Console.WriteLine("Current Hashes not equal");
                    return false;
                }

                //compare previous hash and registered previous hash
                if (!previousBlock.hash.Equals(currentBlock.previousHash))
                {
                    Console.WriteLine("Previous Hashes not equal");
                    return false;
                }
            }
            return true;
        }

    }
}
