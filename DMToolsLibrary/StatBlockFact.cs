// <copyright file="StatBlockFact.cs" company="Chase Conaway">
// No Copyright yet
// </copyright>

using DMToolsLibrary.StatBlocks.Types;

namespace DMToolsLibrary
{
    /// <summary>
    /// The class for testing the statblock creator.
    /// </summary>
    public class StatBlockFact
    {
        StatBlockFactory sbFact = new StatBlockFactory();

        public StatBlockFact(string jsonStatBlock)
        {
            this.sbFact.CreateStatBlock("Monster", jsonStatBlock);
        }
    }
}
