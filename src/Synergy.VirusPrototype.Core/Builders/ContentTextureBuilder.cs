using Synergy.VirusPrototype.Core.Builders.Abstract;

namespace Synergy.VirusPrototype.Core.Builders
{
	public class ContentTextureBuilder : IContentTextureBuilder
	{
		private readonly IGridBuilder _gridBuilder;

		public ContentTextureBuilder(IGridBuilder gridBuilder)
		{
			_gridBuilder = gridBuilder;
		}

		public IGridBuilder GetGridBuilder()
			=> _gridBuilder;
	}
}
