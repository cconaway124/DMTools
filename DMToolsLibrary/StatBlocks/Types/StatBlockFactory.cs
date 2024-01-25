// <copyright file="StatBlockFactory.cs" company="Chase Conaway">
// No Copyright yet
// </copyright>

using System.Reflection;

namespace DMToolsLibrary.StatBlocks.Types
{
    /// <summary>
    /// The factory to create statblocks from using <see cref="FromJsonStatBlock"/>.
    /// </summary>
    public class StatBlockFactory
    {
        /// <summary>
        /// The dictionary that holds the types of stat blocks.
        /// </summary>
        private Dictionary<string, Type> statBlockTypes = new Dictionary<string, Type>();

		/// <summary>
		/// Initializes a new instance of the <see cref="StatBlockFactory"/> class.
		/// </summary>
		public StatBlockFactory()
        {
            this.TraverseAvailableBlocks((block, type) => this.statBlockTypes.Add(block, type));
        }

        /// <summary>
        /// The delegate type for the traversing and adding types to the dict.
        /// </summary>
        /// <param name="block"> The string representation of the block. </param>
        /// <param name="type"> The type of the block. </param>
        private delegate void OnBlockType(string block, Type type);

        /// <summary>
        /// Creates and returns a statbliock of the correct type.
        /// </summary>
        /// <param name="blockType"> The type of the block to create. </param>
        /// <param name="jsonStatBlock"> The json stat block to convert. </param>
        /// <returns> The stat block of the appropriate type. </returns>
        internal StatBlock? CreateStatBlock(string blockType, string jsonStatBlock)
        {
            if (this.statBlockTypes.TryGetValue(blockType, out var type))
            {
                object statBlockObject = Activator.CreateInstance(type);
                if (statBlockObject is Monster monster)
                {
                    return monster;
                }
            }

            return null;
        }

        /// <summary>
        /// Uses reflection to get the available types and then adds those to the dictionary of available types.
        /// </summary>
        /// <param name="onBlockType"> The function to add the type to the dictionary. </param>
        private void TraverseAvailableBlocks(OnBlockType onBlockType)
        {
            // get the type declaration of StatBlock
            Type blockType = typeof(StatBlock);

            // Iterate over all loaded assemblies:
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                // Get all types that inherit from our OperatorNode class using LINQ
                IEnumerable<Type> blockTypes =
                assembly.GetTypes().Where(type => type.IsSubclassOf(blockType));

                // Iterate over those subclasses of OperatorNode
                foreach (var type in blockTypes)
                {
                    // for each subclass, retrieve the Operator property
                    PropertyInfo blockProp = type.GetProperty("BlockType", BindingFlags.NonPublic | BindingFlags.Static);
                    if (blockProp != null)
                    {
                        // Get the character of the Operator
                        object value = blockProp.GetValue(type);

                        // If “Operator” property is not static, you will need to create
                        // an instance first and use the following code instead (or similar):
                        // object value = operatorField.GetValue(Activator.CreateInstance(type,
                        // new ConstantNode(0)));
                        if (value is string blockString)
                        {
                            // And invoke the function passed as parameter
                            // with the operator symbol and the operator class
                            onBlockType(blockString, type);
                        }
                    }
                }
            }
        }
    }
}
