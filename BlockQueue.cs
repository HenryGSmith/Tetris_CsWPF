using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_WPF
{
	internal class BlockQueue
	{
		private readonly Block[] blocks = new Block[]
		{
			new IBlock(),
			new JBlock(),
			new LBlock(),
			new OBlock(),
			new SBlock(),
			new TBlock(),
			new ZBlock()
		};

		private readonly Random random = new Random();

		public Block NextBlock { get; private set; }

		public BlockQueue()
		{
			NextBlock = RandomBlock();
		}

		// create array for next few blocks and display them?

		private Block RandomBlock()
		{
			return blocks[random.Next(blocks.Length)];
		}

		public Block GetAndUpdate()
		{
			Block block = NextBlock;
			// do not return same block twice in a row
			do
			{
				NextBlock = RandomBlock();
			}
			while(block.Id == NextBlock.Id);

			return block;
		}
	}
}
